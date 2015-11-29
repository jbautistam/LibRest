using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibRest.Messages;
using Bau.Libraries.LibRest.Messages.Parameters;
using Bau.Libraries.LibRest.Messages.Headers;

namespace Bau.Libraries.LibRest.Http
{
	/// <summary>
	///		Clase para envío y obtención de resultados Http
	/// </summary>
	internal class HttpSender
	{ // Constantes privadas
			private const int cnstIntBufferLength = 0x2000;

    /// <summary>
    ///		Envía un mensaje por HTTP
    /// </summary>
    internal ResponseMessage Send(RestController objController, RequestMessage objRequest, bool blnSendChunked = true)
    { ResponseMessage objResult;
			HttpWebRequest objHttpRequest = WebRequest.Create(objRequest.GetUrlWithQueryString(true)) as HttpWebRequest;
			byte[] arrBytPostData;

				// Asigna el delegado que trata los errores de certificados en conexiones SSL
					ServicePointManager.ServerCertificateValidationCallback =
					                  delegate(object objSender, X509Certificate objCertificate, 
					                           X509Chain objChain, SslPolicyErrors objSslPolicyErrors)
					                    { return true; // ... descarta todos los errores
					                    };
				// Añade el certificado si es necesario
					if (objController.Certificate != null)
						objHttpRequest.ClientCertificates.Add(objController.Certificate);
				// Asigna el proxy
					if (objController.Proxy.MustUseProxy)
						{ // Crea el proxy
								objHttpRequest.Proxy = new WebProxy(objController.Proxy.Address, objController.Proxy.Port);
							// Asigna las credenciales del proxy
								if (!string.IsNullOrEmpty(objController.Proxy.User))
									objHttpRequest.Proxy.Credentials = new NetworkCredential(objController.Proxy.User, objController.Proxy.Password);
								else
									objHttpRequest.UseDefaultCredentials = true;
						}
				// Asigna las propiedades
					objHttpRequest.Method = objRequest.MethodDescription;
					objHttpRequest.ServicePoint.Expect100Continue = false;
						objHttpRequest.SendChunked = blnSendChunked && (objRequest.Method == RequestMessage.MethodType.Post || objRequest.Method == RequestMessage.MethodType.Put);
					objHttpRequest.UserAgent = objController.UserAgent;
					objHttpRequest.Timeout = objController.TimeOut;
					objHttpRequest.KeepAlive = true;
				// Procesa la autentificación
					if (objController.Authenticator != null)
						objController.Authenticator.Process(objRequest);
				// Asigna el content-type de la solicitud
					if (!objRequest.ContentType.IsEmpty())
						objHttpRequest.ContentType = objRequest.ContentType;
				// Obtiene los datos a enviar
					arrBytPostData = GetPostData(objHttpRequest, objRequest);
				// Añade la longitud
					if (arrBytPostData != null)
						objHttpRequest.ContentLength = arrBytPostData.Length;
				// Asigna las cabeceras
					AddHeaders(objHttpRequest, objRequest.Headers);
				// Escribe los datos
					WritePostData(objHttpRequest, arrBytPostData);
				// Obtiene los datos de la respuesta
					objResult = GetResponse(objHttpRequest);
				// Cierra la solicitud Web
					objHttpRequest = null;
				// Devuelve los datos de salida
					return objResult;
    }

		/// <summary>
		///		Añade las cabeceras a una solicitud Web
		/// </summary>
		private void AddHeaders(HttpWebRequest objHttpRequest, HeadersCollection objColHeaders)
		{	foreach (Header objHeader in objColHeaders)
				objHttpRequest.Headers.Add(objHeader.Key, objHeader.Value);
		}

		/// <summary>
		///		Escribe los datos de envío sobre el stream de la solicitud
		/// </summary>
		private byte[] GetPostData(HttpWebRequest objHttpRequest, RequestMessage objRequest)
		{ byte [] arrBytParameters = null;

				// Añade los datos según el método de envío
					if (objRequest.Attachments.Count == 0)
						{ if (objRequest.Method == RequestMessage.MethodType.Post) // ... en el método POST se envía un formulario
								{ // Asigna el tipo de contenido
										if (objRequest.QueryParameters.Count != 0)
											objHttpRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
									// Codifica los parámetros
										arrBytParameters = EncodePostData(objRequest.QueryParameters, objRequest.Body);
								}
						}
					else
						{ string strBoundary = "-----------------------------" + DateTime.Now.Ticks.ToString("x");

								// Asigna el tipo de contenido
									objHttpRequest.ContentType = "multipart/form-data; boundary=" + strBoundary;
								// Obtiene el contenido
									arrBytParameters = GetMultipartFormData(strBoundary, objRequest.QueryParameters, objRequest.Attachments);
						}
				// Escribe los datos a enviar sobre la solicitud
					return arrBytParameters;
		}

		/// <summary>
		///		Escribe los datos enviados sobre la solicitud
		/// </summary>
		private void WritePostData(HttpWebRequest objHttpRequest, byte[] arrBytPostData)
		{	// Escribe los datos
				if (arrBytPostData != null && objHttpRequest.Method.EqualsIgnoreCase(RequestMessage.MethodType.Post.ToString()))
					using (Stream stmWriter = objHttpRequest.GetRequestStream())
						{	// Escribe los datos de entrada
								if (arrBytPostData != null && arrBytPostData.Length != 0)
									stmWriter.Write(arrBytPostData, 0, arrBytPostData.Length);
							// Cierra el stream
								stmWriter.Flush();
								stmWriter.Close();
						}
		}

		/// <summary>
		///		Obtiene los datos a enviar
		/// </summary>
		private byte[] EncodePostData(ParameterDataCollection objColQueryString, string strBody)
		{	string strEncoded = "";

				// Codifica los datos
					if (objColQueryString != null && objColQueryString.Count > 0)
						foreach (ParameterData objQueryString in objColQueryString)
							{	// Añade el separador si es necesario
									if (!string.IsNullOrEmpty(strEncoded))
										strEncoded += "&";
								// Añade los datos a la cadena codificada
									strEncoded += string.Format("{0}={1}", objQueryString.Key, objQueryString.ValueEncoded);
							}
				// Añade el cuerpo del mensaje
					if (!string.IsNullOrEmpty(strBody))
						strEncoded += Environment.NewLine + strBody;
				// Devuelve la cadena codificada
					return new System.Text.UTF8Encoding().GetBytes(strEncoded);
		}

		/// <summary>
		///		Obtiene los datos a enviar cuando hay nombres de archivos
		/// </summary>
		private byte[] GetMultipartFormData(string strBoundary, ParameterDataCollection objColQueryString, AttachmentsCollection objColAttachments)
		{ byte [] arrBytFormData;

				// Escribe los datos en un stream en memoria
					using (MemoryStream stmData = new MemoryStream())
						{ System.Text.UTF8Encoding objEncoding = new System.Text.UTF8Encoding();
							string strFooter = "\r\n--" + strBoundary + "--\r\n";

								// Asigna los archivos
									foreach (Attachment objAttachment in objColAttachments)
										{ byte [] arrBytHeader = objEncoding.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
																																								strBoundary, Path.GetFileName(objAttachment.FileName), 
																																								Path.GetFileName(objAttachment.FileName), 
																																								objAttachment.ContentType));
											byte [] arrBytFile = ReadFile(objAttachment.FileName);

												// Escribe la cabecera
													stmData.Write(arrBytHeader, 0, arrBytHeader.Length);
												// Escribe los datos del archivo
													stmData.Write(arrBytFile, 0, arrBytFile.Length);
												// Añade un salto de línea para permitir que se envíen varios archivos 
													stmData.Write(objEncoding.GetBytes("\r\n"), 0, 2);
											}
								// Asigna los parámetros
									foreach (ParameterData objQueryString in objColQueryString)
										{ byte [] arrBytPostData = objEncoding.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n",
																																									strBoundary, objQueryString.Key, objQueryString.ValueEncoded));

												// Escribe los datos
													stmData.Write(arrBytPostData, 0, arrBytPostData.Length);
										}
								// Añade el final de la solicitud
									stmData.Write(objEncoding.GetBytes(strFooter), 0, strFooter.Length);
								// Pasa los datos del stream de memoria al buffer
									stmData.Position = 0;
									arrBytFormData = new byte[stmData.Length];
									stmData.Read(arrBytFormData, 0, arrBytFormData.Length);
								// Cierra el stream de memoria
									stmData.Close();
						}
				// Devuelve el array de bytes de datos
					return arrBytFormData;
		}

		/// <summary>
		///		Lee los datos de un archivo
		/// </summary>
		private byte[] ReadFile(string strFileName)
		{ byte [] arrBytData;

				// Lee los datos sobre el array de bytes
					using (FileStream stmFile = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
						{ // Crea el buffer
								arrBytData = new byte[stmFile.Length];
							// Asigna los datos del archivo al buffer
								stmFile.Read(arrBytData, 0, arrBytData.Length);
							// Cierre el archivo
								stmFile.Close();
						}
			// Devuelve el array de bytes
				return arrBytData;
		}

    /// <summary>
    ///		Procesa la respuesta de la Web
    /// </summary>
    private ResponseMessage GetResponse(HttpWebRequest objHtppRequest)
    { ResponseMessage objResult = new ResponseMessage(HttpStatusCode.InternalServerError, "Error interno", new NotImplementedException());
    
				// Obtiene la respuesta
					try
						{ byte [] arrBytData;

								// Crea una respuesta en principio, correcta
									objResult = new ResponseMessage(HttpStatusCode.OK, "No enviado");
								// Obtiene la respuesta del servidor
									using (HttpWebResponse objHttpResponse = (HttpWebResponse) objHtppRequest.GetResponse())
										{ // Lee los datos en un stream en memoria
												using (Stream stmResponse = objHttpResponse.GetResponseStream())
													{ // Copia la respuesta en memoria
															using (MemoryStream stmMemory = new MemoryStream(cnstIntBufferLength))
																{ byte[] arrBytBuffer = new byte[cnstIntBufferLength];
																	int intBytes;

																		// Lee el stream de respuesta en un array de bytes
																			while ((intBytes = stmResponse.Read(arrBytBuffer, 0, arrBytBuffer.Length)) > 0) 
																				stmMemory.Write(arrBytBuffer, 0, intBytes);
																		// Pasa el stream en memoria a un array de bytes
																			arrBytData = stmMemory.ToArray();
																		// Cierra el stream de memoria
																			stmMemory.Close();
																}
														// Cierra el stream de entrada
															stmResponse.Close();
													}
											// Obtiene el resultado
												objResult.ContentEncoding = objHttpResponse.ContentEncoding;
												objResult.ContentLength = objHttpResponse.ContentLength;
												objResult.ContentType = objHttpResponse.ContentType;
												// objResult.Cookies = objHttpResponse.Cookies;
												objResult.IsFromCache = objHttpResponse.IsFromCache;
												objResult.IsMutuallyAuthenticated = objHttpResponse.IsMutuallyAuthenticated;
												objResult.LastModified = objHttpResponse.LastModified;
												objResult.Method = objHttpResponse.Method;
												objResult.ProtocolVersion = objHttpResponse.ProtocolVersion;
												objResult.ResponseUri = objHttpResponse.ResponseUri;
												objResult.Server = objHttpResponse.Server;												
												objResult.Status = objHttpResponse.StatusCode;
												objResult.StatusDescription = objHttpResponse.StatusDescription;
											// Obtiene el cuerpo del mensaje
												objResult.Body = System.Text.Encoding.Default.GetString(arrBytData);
											// Asigna las cabeceras
												foreach (string strKey in objHttpResponse.Headers.Keys)
													objResult.Headers.Add(strKey, objHttpResponse.Headers[strKey]);
										}
						}
					catch (WebException objWebException)
						{ objResult = new ResponseMessage(HttpStatusCode.BadRequest, ComputeException(objWebException), objWebException);
						}
					catch (Exception objException)
						{ objResult = new ResponseMessage(HttpStatusCode.BadRequest, "Excepción", objException);
						}
				// Devuelve la respuesta
					return objResult;
    }

		/// <summary>
		///		Calcula los datos de la excepción interna
		/// </summary>
		private string ComputeException(WebException objWebException)
		{ System.Text.StringBuilder sbException = new System.Text.StringBuilder();

				// Añade el error
					sbException.AppendLine("ERROR:" + objWebException.Message + ". STATUS: " + objWebException.Status.ToString());
				// Si es un error de protocolo, recoge los datos
					if (objWebException.Status == WebExceptionStatus.ProtocolError)
						{ HttpWebResponse objHttpResponse = ((HttpWebResponse) objWebException.Response);

								// Añade los datos de protocolo
									sbException.AppendLine(string.Format("Status Code : {0}", objHttpResponse.StatusCode));
									sbException.AppendLine(string.Format("Status Description : {0}", objHttpResponse.StatusDescription));
								// Añade el contenido de la respuesta
									try
										{ StreamReader reader = new StreamReader(objHttpResponse.GetResponseStream());

												sbException.AppendLine(reader.ReadToEnd());
										}
									catch (Exception objException) 
										{ sbException.AppendLine("Error al leer la respuesta interna de la excepción (" + objException.Message + ")");
										}
								}
				// Devuelve la cadena con la excepción interna
					return sbException.ToString();
		}

		/// <summary>
		///		Lee las cabeceras de una respuesta
		/// </summary>
		private void ReadHeaders(HttpWebResponse objHttpResponse, ResponseMessage objResult)
		{ foreach (string strKey in objHttpResponse.Headers.Keys)
				objResult.Headers.Add(strKey, objHttpResponse.Headers[strKey]);
		}
	}
}