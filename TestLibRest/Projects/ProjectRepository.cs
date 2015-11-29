using System;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibRest;
using Bau.Libraries.LibRest.Messages;
using Bau.Libraries.LibRest.Messages.Headers;
using Bau.Libraries.LibRest.Messages.Parameters;
using Bau.Libraries.LibRest.Authentication;
using Bau.Libraries.LibRest.Authentication.Oauth;

namespace Bau.Applications.TestLibRest.Projects
{
	/// <summary>
	///		Repository para los parámetros de envío de datos por REST
	/// </summary>
	public class ProjectRepository 
	{ // Constantes privadas
			private const string cnstStrTagRoot = "RestParameters";
			private const string cnstStrTagContext = "Context";
			private const string cnstStrTagContextUserAgent = "UserAgent";
			private const string cnstStrTagContextTimeOut = "TimeOut";
			private const string cnstStrTagContextProxyEnabled = "ProxyEnabled";
			private const string cnstStrTagContextProxyAddress = "ProxyAddress";
			private const string cnstStrTagContextProxyPort = "ProxyPort";
			private const string cnstStrTagContextProxyUser = "ProxyUser";
			private const string cnstStrTagContextProxyPassword = "ProxyPassword";
			private const string cnstStrTagContextProxyByPassLocal = "ProxyByPassLocal";
			private const string cnstStrTagMessage = "Message";
			private const string cnstStrTagMessageName = "Name";
			private const string cnstStrTagMessageMethod = "Method";
			private const string cnstStrTagMessageURL = "URL";
			private const string cnstStrTagMessageContentType = "ContentType";
			private const string cnstStrTagMessageHeader = "Header";
			private const string cnstStrTagMessageQueryParameter = "QueryParameter";
			private const string cnstStrTagMessageAttrName = "Name";
			private const string cnstStrTagMessageAttrValue = "Value";
			private const string cnstStrTagMessageFileName = "FileName";
			private const string cnstStrTagAuthPlain = "AuthPlain";
			private const string cnstStrTagAuthPlainUser = "User";
			private const string cnstStrTagAuthPlainPassword = "Password";
			private const string cnstStrTagAuthOAuth = "AuthOAuth";
			private const string cnstStrTagAuthOAuthConsumerKey = "ConsumerKey";
			private const string cnstStrTagAuthOAuthConsumerSecret = "ConsumerSecret";
			private const string cnstStrTagAuthOAuthAccessToken = "AccessToken";
			private const string cnstStrTagAuthOAuthAccessTokenSecret = "AccessTokenSecret";

		/// <summary>
		///		Carga los datos de un archivo
		/// </summary>
		public Project Load(string strFileName)
		{ Project objProject = new Project();

				// Carga los datos
					if (System.IO.File.Exists(strFileName))
						{ MLFile objMLFile = new MLSerializer().Parse(MLSerializer.SerializerType.XML, strFileName);

								foreach (MLNode objMLNode in objMLFile.Nodes)
									if (objMLNode.Name == cnstStrTagRoot)
										foreach (MLNode objMLChild in objMLNode.Nodes)
											switch (objMLChild.Name)
												{ case cnstStrTagContext:
															objProject.Context = LoadContext(objMLChild);
														break;
													case cnstStrTagMessage:
															objProject.Instructions.Add(LoadInstruction(objMLChild));
														break;
													case cnstStrTagAuthPlain:
															objProject.Authenticator = LoadAuthenticationPlain(objMLChild);
														break;
													case cnstStrTagAuthOAuth:
															objProject.Authenticator = LoadAuthenticationOAuth(objMLChild);
														break;
												}
						}
				// Devuelve el proyecto
					return objProject;
		}

		/// <summary>
		///		Carga los datos de contexto
		/// </summary>
		private RestController LoadContext(MLNode objMLNode)
		{ RestController objContext = new RestController("Agent");
			
				// Carga los datos
					objContext.UserAgent = objMLNode.Nodes[cnstStrTagContextUserAgent].Value;
					objContext.TimeOut = objMLNode.Nodes[cnstStrTagContextTimeOut].GetValue(20000);
					objContext.Proxy.Enabled = objMLNode.Nodes[cnstStrTagContextProxyEnabled].Value.GetBool();
					objContext.Proxy.Address = objMLNode.Nodes[cnstStrTagContextProxyAddress].Value;
					objContext.Proxy.Port = objMLNode.Nodes[cnstStrTagContextProxyPort].Value.GetInt(0);
					objContext.Proxy.User = objMLNode.Nodes[cnstStrTagContextProxyUser].Value;
					objContext.Proxy.Password = objMLNode.Nodes[cnstStrTagContextProxyPassword].Value;
					objContext.Proxy.MustBypassLocal = objMLNode.Nodes[cnstStrTagContextProxyByPassLocal].GetValue(false);
				// Devuelve los datos de contexto
					return objContext;
		}

		/// <summary>
		///		Carga los datos de una instrucción
		/// </summary>
		private Instruction LoadInstruction(MLNode objMLNode)
		{ Instruction objInstruction = new Instruction();

				// Obtiene los datos de la instrucción
					objInstruction.Name = objMLNode.Nodes[cnstStrTagMessageName].Value;
					objInstruction.Request.Method = (RequestMessage.MethodType) objMLNode.Nodes[cnstStrTagMessageMethod].GetValue((int) RequestMessage.MethodType.Post);
					objInstruction.Request.URL = objMLNode.Nodes[cnstStrTagMessageURL].Value;
					objInstruction.Request.ContentType = objMLNode.Nodes[cnstStrTagMessageContentType].Value;
				// Obtiene los parámetros y nombres de archivos
					foreach (MLNode objMLChild in objMLNode.Nodes)
						switch (objMLChild.Name)
							{ case cnstStrTagMessageQueryParameter:
										objInstruction.Request.QueryParameters.Add(objMLChild.Attributes[cnstStrTagMessageAttrName].Value,
																															 objMLChild.Attributes[cnstStrTagMessageAttrValue].Value);
									break;
								case cnstStrTagMessageHeader:
										objInstruction.Request.Headers.Add(objMLChild.Attributes[cnstStrTagMessageAttrName].Value,
																											 objMLChild.Attributes[cnstStrTagMessageAttrValue].Value);
									break;
								case cnstStrTagMessageFileName:
										objInstruction.Request.Attachments.Add(objMLChild.Value);
									break;
							}						
				// Devuelve la instrucción
					return objInstruction;
		}

		/// <summary>
		///		Carga los datos de autentificación plano
		/// </summary>
		private IAuthenticator LoadAuthenticationPlain(MLNode objMLChild)
		{ return new PlainAuthenticator(objMLChild.Nodes[cnstStrTagAuthPlainUser].Value, 
																		objMLChild.Nodes[cnstStrTagAuthPlainPassword].Value);
		}

		/// <summary>
		///		Carga los datos de autentificación plano
		/// </summary>
		private IAuthenticator LoadAuthenticationOAuth(MLNode objMLChild)
		{ oAuthAuthenticator objAuthenticator = new oAuthAuthenticator();

				// Asigna los datos
					objAuthenticator.ConsumerKey = objMLChild.Nodes[cnstStrTagAuthOAuthConsumerKey].Value; 
					objAuthenticator.ConsumerSecret = objMLChild.Nodes[cnstStrTagAuthOAuthConsumerSecret].Value; 
					objAuthenticator.AccessToken = objMLChild.Nodes[cnstStrTagAuthOAuthAccessToken].Value; 
					objAuthenticator.AccessTokenSecret = objMLChild.Nodes[cnstStrTagAuthOAuthAccessTokenSecret].Value; 
				// Devuelve el autentificador
					return objAuthenticator;
		}

		/// <summary>
		///		Graba los datos de un mensaje
		/// </summary>
		public void Save(string strFileName, Project objProject)
		{ MLFile objMLFile = new MLFile();
			MLNode objMLNode = objMLFile.Nodes.Add(cnstStrTagRoot);

				// Añade los nodos de contexto
					AddNodesContext(objMLNode, objProject.Context);
				// Añade los nodos de las instrucciones
					foreach (Instruction objInstruction in objProject.Instructions)
						AddNodesMessage(objMLNode, objInstruction);
				// Añade los nodos de autentificación
					AddNodesAuthentification(objMLNode, objProject.Authenticator);
				// Graba el archivo
					new MLSerializer().Save(MLSerializer.SerializerType.XML, objMLFile, strFileName);
		}

		/// <summary>
		///		Añade los nodos de contexto
		/// </summary>
		private void AddNodesContext(MLNode objMLNode, RestController objContext) 
		{	MLNode objMLChild = objMLNode.Nodes.Add(cnstStrTagContext);
		
				// Añade los nodos de contexto
					objMLChild.Nodes.Add(cnstStrTagContextUserAgent, objContext.UserAgent);
					objMLChild.Nodes.Add(cnstStrTagContextTimeOut, objContext.TimeOut);
					objMLChild.Nodes.Add(cnstStrTagContextProxyEnabled, objContext.Proxy.Enabled);
					objMLChild.Nodes.Add(cnstStrTagContextProxyAddress, objContext.Proxy.Address);
					objMLChild.Nodes.Add(cnstStrTagContextProxyPort, objContext.Proxy.Port);
					objMLChild.Nodes.Add(cnstStrTagContextProxyUser, objContext.Proxy.User);
					objMLChild.Nodes.Add(cnstStrTagContextProxyPassword, objContext.Proxy.Password);
					objMLChild.Nodes.Add(cnstStrTagContextProxyByPassLocal, objContext.Proxy.MustBypassLocal);
		}

		/// <summary>
		///		Añade los nodos de la instrucción
		/// </summary>
		private void AddNodesMessage(MLNode objMLNode, Instruction objInstruction)
		{ MLNode objMLChild = objMLNode.Nodes.Add(cnstStrTagMessage);

				// Obtiene los datos de la instrucción
					objMLChild.Nodes.Add(cnstStrTagMessageName, objInstruction.Name);
					objMLChild.Nodes.Add(cnstStrTagMessageMethod, (int) objInstruction.Request.Method);
					objMLChild.Nodes.Add(cnstStrTagMessageURL, objInstruction.Request.URL);
					objMLChild.Nodes.Add(cnstStrTagMessageContentType, objInstruction.Request.ContentType);
				// Añade los parámetros, cabeceras y nombres de archivos
					foreach (ParameterData objQueryParameter in objInstruction.Request.QueryParameters)
						objMLChild.Nodes.Add(GetNodeKey(cnstStrTagMessageQueryParameter, objQueryParameter.Key, objQueryParameter.Value));
					foreach (Header objHeader in objInstruction.Request.Headers)
						objMLChild.Nodes.Add(GetNodeKey(cnstStrTagMessageHeader, objHeader.Key, objHeader.Value));
					foreach (Attachment objAttachment in objInstruction.Request.Attachments)
						objMLChild.Nodes.Add(cnstStrTagMessageFileName, objAttachment.FileName);
		}

		/// <summary>
		///		Añade los nodos de autentificación
		/// </summary>
		private void AddNodesAuthentification(MLNode objMLNode, IAuthenticator objAuthenticator)
		{ if (objAuthenticator != null)
				{ if (objAuthenticator is PlainAuthenticator)
						AddNodesAuthentificationPlain(objMLNode, objAuthenticator as PlainAuthenticator);
					else if (objAuthenticator is oAuthAuthenticator)
						AddNodesAuthentificationOAuht(objMLNode, objAuthenticator as oAuthAuthenticator);
				}
		}

		/// <summary>
		///		Añade los nodos de autentificación plano
		/// </summary>
		private void AddNodesAuthentificationPlain(MLNode objMLNode, PlainAuthenticator objAuthenticator)
		{	MLNode objMLAuth = objMLNode.Nodes.Add(cnstStrTagAuthPlain);

				objMLAuth.Nodes.Add(cnstStrTagAuthPlainUser, objAuthenticator.User);
				objMLAuth.Nodes.Add(cnstStrTagAuthPlainPassword, objAuthenticator.Password);
		}

		/// <summary>
		///		Añade los nodos de autentificación oAuth
		/// </summary>
		private void AddNodesAuthentificationOAuht(MLNode objMLNode, oAuthAuthenticator objAuthenticator)
		{ MLNode objMLAuth = objMLNode.Nodes.Add(cnstStrTagAuthOAuth);

				objMLAuth.Nodes.Add(cnstStrTagAuthOAuthConsumerKey, objAuthenticator.ConsumerKey);
				objMLAuth.Nodes.Add(cnstStrTagAuthOAuthConsumerSecret, objAuthenticator.ConsumerSecret);
				objMLAuth.Nodes.Add(cnstStrTagAuthOAuthAccessToken, objAuthenticator.AccessToken);
				objMLAuth.Nodes.Add(cnstStrTagAuthOAuthAccessTokenSecret, objAuthenticator.AccessTokenSecret);
		}

		/// <summary>
		///		Obtiene un nodo para parámetros o cabeceras
		/// </summary>
		private MLNode GetNodeKey(string strHeader, string strKey, string strValue) 
		{ MLNode objMLNode = new MLNode(strHeader);

				// Añade los atributos
					objMLNode.Attributes.Add(cnstStrTagMessageAttrName, strKey);
					objMLNode.Attributes.Add(cnstStrTagMessageAttrValue, strValue);
				// Devuelve el nodo
					return objMLNode;
		}
	}
}