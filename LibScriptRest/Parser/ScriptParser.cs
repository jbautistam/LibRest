using System;
using System.Collections.Generic;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibRest.Messages;

namespace Bau.Libraries.LibScriptRest.Parser
{
	/// <summary>
	///		Parser de instrucciones Rest
	/// </summary>
	internal class ScriptParser
	{ // Constantes privadas con los errores básicos
			private const string cnstStrErrorTooParameters = "Demasiados parámetros en la instrucción";
			private const string cnstStrErrorExistsInstruction = "No existe ninguna instrucción abierta";
		// Constantes privadas con las instrucciones
			private const string cnstStrInstructionProxy = "PROXY";
			private const string cnstStrInstructionUserAgent = "USERAGENT";
			private const string cnstStrInstructionTimeOut = "TIMEOUT";
			private const string cnstStrInstructionCertificate = "CERTIFICATE";
			private const string cnstStrInstructionPlainAuth = "PLAINAUTH";
			private const string cnstStrInstructionOAuth = "OAUTH";
			private const string cnstStrInstructionStart = "START";
			private const string cnstStrInstructionSend = "SEND";
			private const string cnstStrInstructionContentType = "CONTENTTYPE";
			private const string cnstStrInstructionAttachemnt = "ATTACHMENT";
			private const string cnstStrInstructionStartBody = "STARTBODY";
			private const string cnstStrInstructionEndBody = "ENDBODY";
			private const string cnstStrInstructionUrlParameter = "URLPARAMETER";
			private const string cnstStrInstructionQueryParameter = "QUERYPARAMETER";
			private const string cnstStrInstructionHeader = "HEADER";
			
		internal ScriptParser(ScriptRestProcessor objProcessor)
		{ Processor = objProcessor;
		}

		/// <summary>
		///		Interpreta las instrucciones de un texto
		/// </summary>
		internal void Parse(string strProgram)
		{ if (!strProgram.IsEmpty())
				{ List<string> objColLines = strProgram.SplitByString(Environment.NewLine);

						// Interpreta las líneas
							for (int intLine = 0; intLine < objColLines.Count; intLine++)
								{ string strLine = objColLines[intLine].TrimIgnoreNull();

										if (IsParsingBody || (!strLine.IsEmpty() && !strLine.StartsWith("//")))
											ParseLine(intLine, strLine);
								}
						// Añade la última instrucción que se puede haber quedado abierta
							AddLastInstruction();
						// Comprueba si aún se está interpretando un cuerpo
							if (IsParsingBody)
								AddError(objColLines.Count, "StartBody", "No se ha encontrado el final del cuerpo del mensaje");
				}
			else
				AddError(0, "", "No existe ninguna instrucción");
		}

		/// <summary>
		///		Interpreta una línea
		/// </summary>
		private void ParseLine(int intLine, string strLine)
		{ if (IsParsingBody && !strLine.EqualsIgnoreCase(cnstStrInstructionEndBody))
				LastBody += strLine + Environment.NewLine;
			else
				{ string strParameters;
					string strHeader = strLine.Cut(" ", out strParameters);
					string strError = "";
					List<string> objColParameters = strParameters.SplitByString(",");

						// Interpreta los parámetros
							switch (strHeader.TrimIgnoreNull().ToUpper())
								{	case cnstStrInstructionProxy:
											ParseProxy(objColParameters, ref strError);
										break;
									case cnstStrInstructionUserAgent:
											ParseUserAgent(objColParameters, ref strError);
										break;
									case cnstStrInstructionTimeOut:
											ParseTimeOut(objColParameters, ref strError);
										break;
									case cnstStrInstructionCertificate:
											ParseCertificate(objColParameters, ref strError);
										break;
									case cnstStrInstructionPlainAuth:
											ParsePlainAuth(objColParameters, ref strError);
										break;
									case cnstStrInstructionOAuth:
											ParseOAuth(objColParameters, ref strError);
										break;
									case cnstStrInstructionStart:
											ParseStartInstruction(objColParameters, ref strError);
										break;
									case cnstStrInstructionSend:
											ParseSendInstruction(objColParameters, ref strError);
										break;
									case cnstStrInstructionContentType:
											ParseContentType(objColParameters, ref strError);
										break;
									case cnstStrInstructionUrlParameter:
									case cnstStrInstructionQueryParameter:
									case cnstStrInstructionHeader:
											ParseMessageParameters(strHeader.TrimIgnoreNull().ToUpper(), objColParameters, ref strError);
										break;
									case cnstStrInstructionAttachemnt:
											ParseAttachment(objColParameters, ref strError);
										break;
									case cnstStrInstructionStartBody:
											ParseBody(objColParameters, ref strError);
										break;
									case cnstStrInstructionEndBody:
											ParseEndBody(objColParameters, ref strError);
										break;
									default:
											strError = "No se reconoce la cabecera de la instrucción: " + strHeader;
										break;
								}
						// Añade el error
							if (!strError.IsEmpty())
								AddError(intLine, strLine, strError);
				}
		}

		/// <summary>
		///		Interpreta los datos del proxy
		/// </summary>
		private void ParseProxy(List<string> objColParameters, ref string strError)
		{ string strAddress, strUser, strPassword;
			int intPort;
			bool blnMustBypassLocal = false, blnEnabled = true;

				// Interpreta los datos
					strAddress = GetParameter(objColParameters, 0);
					intPort = GetParameter(objColParameters, 1).GetInt(-1);
					strUser = GetParameter(objColParameters, 2);
					strPassword = GetParameter(objColParameters, 3);
					blnMustBypassLocal = GetParameter(objColParameters, 4).GetBool(false);
					blnEnabled = GetParameter(objColParameters, 5).GetBool(true);
				// Genera el proxy
					if (objColParameters.Count > 6)
						strError = cnstStrErrorTooParameters;
					else if (strAddress.IsEmpty())
						strError = "Falta la dirección del proxy";
					else if (intPort < 1)
						strError = "No se reconoce el número de puerto";
					else
						Processor.Program.Context.Proxy = new LibRest.Proxies.ProxyData(strAddress, intPort, strUser, strPassword, blnMustBypassLocal, blnEnabled);
		}

		/// <summary>
		///		Interpreta el agente
		/// </summary>
		private void ParseUserAgent(List<string> objColParameters, ref string strError)
		{ string strAgent = GetParameter(objColParameters, 0);

				// Ejecuta la instrucción
					if (objColParameters.Count > 1)
						strError = cnstStrErrorTooParameters;
					else if (strAgent.IsEmpty())
						strError = "No se ha definido el texto del agente";
					else
						Processor.Program.Context.UserAgent = strAgent;
		}

		/// <summary>
		///		Interpreta el timeout
		/// </summary>
		private void ParseTimeOut(List<string> objColParameters, ref string strError)
		{ int intTimeOut = GetParameter(objColParameters, 1).GetInt(-1);

				// Ejecuta la instrucción
					if (objColParameters.Count > 1)
						strError = cnstStrErrorTooParameters;
					else if (intTimeOut < 0)
						strError = "El valor del tiempo de espera debe ser superior a 0";
					else
						Processor.Program.Context.TimeOut = intTimeOut;
		}

		/// <summary>
		///		Interpreta los datos de un certificado
		/// </summary>
		private void ParseCertificate(List<string> objColParameters, ref string strError)
		{ string strFileName = GetParameter(objColParameters, 1);

				// Ejecuta la instrucción
					if (objColParameters.Count > 1)
						strError = cnstStrErrorTooParameters;
					else if (strFileName.IsEmpty())
						strError = "Falta el nombre del archivo de certificado";
					else if (!System.IO.File.Exists(strFileName))
						strError = "No se encuentra el archivo de certificado";
					else
						try
							{	Processor.Program.Context.Certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(strFileName);
							}
						catch (Exception objException)
							{ strError = "Error al cargar el certificado: " + objException.Message;
							}
		}

		/// <summary>
		///		Interpreta los datos de autentificación en plano
		/// </summary>
		private void ParsePlainAuth(List<string> objColParameters, ref string strError)
		{ string strUser = GetParameter(objColParameters, 0);
			string strPassword = GetParameter(objColParameters, 1);

				// Ejecuta la instrucción
					if (objColParameters.Count > 2)
						strError = cnstStrErrorTooParameters;
					else if (strUser.IsEmpty())
						strError = "No se encuentra el código de usuario";
					else
						Processor.Program.Authenticator = new LibRest.Authentication.PlainAuthenticator(strUser, strPassword);
		}

		/// <summary>
		///		Interpreta los datos de autentificación oAuth
		/// </summary>
		private void ParseOAuth(List<string> objColParameters, ref string strError)
		{ string strConsumerKey = GetParameter(objColParameters, 0);
			string strConsumerSecret = GetParameter(objColParameters, 1);
			string strAccessToken = GetParameter(objColParameters, 2);
			string strAccessTokenSecret = GetParameter(objColParameters, 3);

				// Ejecuta la instrucción
					if (objColParameters.Count > 4)
						strError = cnstStrErrorTooParameters;
					else if (strConsumerKey.IsEmpty() || strConsumerSecret.IsEmpty() || strAccessToken.IsEmpty() || strAccessTokenSecret.IsEmpty())
						strError = "Faltan parámetros";
					else
						Processor.Program.Authenticator = new LibRest.Authentication.Oauth.oAuthAuthenticator(strConsumerKey, strConsumerSecret, 
																																																	strAccessToken, strAccessTokenSecret);
		}

		/// <summary>
		///		Interpreta el comiendo de una instrucción
		/// </summary>
		private void ParseStartInstruction(List<string> objColParameters, ref string strError)
		{ RequestMessage.MethodType? intMethod = ConvertMethod(GetParameter(objColParameters, 0));
			string strUrl = GetParameter(objColParameters, 1);

				// Añade la última instrucción al proyecto
					AddLastInstruction();
				// Ejecuta la instrucción
					if (objColParameters.Count > 2)
						strError = cnstStrErrorTooParameters;
					else if (intMethod == null)
						strError = "No se reconoce el método";
					else
						LastInstruction = Processor.Program.Instructions.Add(intMethod ?? RequestMessage.MethodType.Get, strUrl);
		}

		/// <summary>
		///		Interpreta la instrucción de envío (cierra la intrucción actual)
		/// </summary>
		private void ParseSendInstruction(List<string> objColParameters, ref string strError)
		{ // Añade la instrucción al proyecto
				if (objColParameters.Count > 0)
					strError = cnstStrErrorTooParameters;
				else if (LastInstruction == null)
					strError = "No existe ninguna instrucción abierta";
			// Siempre añade la última instrucción
				AddLastInstruction();
		}

		private void AddLastInstruction()
		{ if (LastInstruction != null)	
				{	Processor.Program.Instructions.Add(LastInstruction);
					LastInstruction = null;
				}
		}

		/// <summary>
		///		Interpreta el content/type de la instrucción
		/// </summary>
		private void ParseContentType(List<string> objColParameters, ref string strError)
		{ string strContent = GetParameter(objColParameters, 0);

				// Interpreta la instrucción
					if (objColParameters.Count > 1)
						strError = cnstStrErrorTooParameters;
					else if (LastInstruction == null)
						strError = cnstStrErrorExistsInstruction;
					else if (strContent.IsEmpty())
						strError = "No se encuentra ningún valor de Content/Type";
					else
						LastInstruction.Request.ContentType = strContent;
		}

		/// <summary>
		///		Interpreta un adjunto
		/// </summary>
		private void ParseAttachment(List<string> objColParameters, ref string strError)
		{ string strFileName = GetParameter(objColParameters, 0);

				// Interpreta los datos
					if (objColParameters.Count > 1)
						strError = cnstStrErrorTooParameters;
					else if (LastInstruction == null)
						strError = cnstStrErrorExistsInstruction;
					else if (strFileName.IsEmpty())
						strError = "Falta el nombre de archivo";
					else if (!System.IO.File.Exists(strFileName))
						strError = "No se puede abrir el archivo";
					else
						LastInstruction.Request.Attachments.Add(strFileName);
		}

		/// <summary>
		///		Interpreta un valor de QueryString, parámetros de URL o cabeceras
		/// </summary>
		private void ParseMessageParameters(string strType, List<string> objColParameters, ref string strError)
		{ string strKey = GetParameter(objColParameters, 0);
			string strValue = GetParameter(objColParameters, 1);

				// Interpreta los datos
					if (objColParameters.Count > 2)
						strError = cnstStrErrorTooParameters;
					else if (LastInstruction == null)
						strError = cnstStrErrorExistsInstruction;
					else if (strKey.IsEmpty())
						strError = "Falta la clave";
					else
						switch (strType)
							{	case cnstStrInstructionQueryParameter:
										LastInstruction.Request.QueryParameters.Add(strKey, strValue);
									break;
								case cnstStrInstructionUrlParameter:
										LastInstruction.Request.UrlParameters.Add(strKey, strValue);
									break;
								case cnstStrInstructionHeader:
										LastInstruction.Request.Headers.Add(strKey, strValue);
									break;
								default:
										strError = "No se reconoce la cabecera de instrucción";
									break;
							}
		}

		/// <summary>
		///		Interpreta el inicio de un cuerpo
		/// </summary>
		private void ParseBody(List<string> objColParameters, ref string strError)
		{ // Comprueba los errores
				if (LastInstruction == null)
					strError = cnstStrErrorExistsInstruction;
			// Indica que se ha comenzado a interpretar un cuerpo
				IsParsingBody = true;
				LastBody = "";
		}

		/// <summary>
		///		Interpreta el final de un cuerpo
		/// </summary>
		private void ParseEndBody(List<string> objColParameters, ref string strError)
		{ // Asigna el cuerpo de la instrucción
				if (LastInstruction != null)
					LastInstruction.Request.Body = LastBody;
			// Indica que se ha finalizado de interpretar el cuerpo
				IsParsingBody = false;
				LastBody = "";
		}

		/// <summary>
		///		Obtiene un valor de un array
		/// </summary>
		private string GetParameter(List<string> objColParameters, int intIndex)
		{	if (objColParameters != null && intIndex >= 0 && intIndex < objColParameters.Count)
				return objColParameters[intIndex];
			else
				return "";
		}

		/// <summary>
		///		Convierte el método
		/// </summary>
		private RequestMessage.MethodType? ConvertMethod(string strMethod)
		{ switch (strMethod.TrimIgnoreNull().ToUpper())
				{	case "GET":
						return RequestMessage.MethodType.Get;
					case "POST":
						return RequestMessage.MethodType.Post;
					case "PUT":
						return RequestMessage.MethodType.Put;
					case "DELETE":
						return RequestMessage.MethodType.Delete;
					case "HEAD":
						return RequestMessage.MethodType.Head;
					case "OPTIONS":
						return RequestMessage.MethodType.Options;
					default:
						return null;
				}
		}

		/// <summary>
		///		Añade un error a la colección
		/// </summary>
		private void AddError(int intLine, string strInstruction, string strMessage)
		{ Processor.Errors.Add(new Errors.SyntaxError(intLine, strInstruction, strMessage));
		}

		/// <summary>
		///		Procesador al que se asocia el intérprete
		/// </summary>
		private ScriptRestProcessor Processor { get; set; }

		/// <summary>
		///		Instrucción actual
		/// </summary>
		private Projects.RestInstruction LastInstruction { get; set; }

		/// <summary>
		///		Indica si se está interpretando un STARTBODY ... ENDBODY
		/// </summary>
		private bool IsParsingBody { get; set; }

		/// <summary>
		///		Cuerpo del mensaje que se está interpretando
		/// </summary>
		private string LastBody { get; set; }
	}
}