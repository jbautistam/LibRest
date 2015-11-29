using System;
using System.Security.Cryptography;
using System.Text;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibRest.Encoders;
using Bau.Libraries.LibRest.Messages;
using Bau.Libraries.LibRest.Messages.Parameters;

namespace Bau.Libraries.LibRest.Authentication.Oauth
{
	/// <summary>
	///		Rutinas de autentificación para sistemas oAuth
	/// </summary>
	public class oAuthAuthenticator : IAuthenticator
	{ // Constantes privadas
			private const string cnstStrVersion = "1.0";
			private const string cnstStrSignatureMethod = "HMAC-SHA1";

		public oAuthAuthenticator(string strConsumerKey = null, string strConsumerSecret = null, 
															string strAccessToken = null, string strAccessTokenSecret = null)
		{ ConsumerKey = strConsumerKey;
			ConsumerSecret = strConsumerSecret;
			AccessToken = strAccessToken;
			AccessTokenSecret = strAccessTokenSecret;
		}

		/// <summary>
		///		Procesa la autentificación
		/// </summary>
		public void Process(RequestMessage objRequest)
		{ string strNonce, strTimestamp, strSignature;

				// Inicializa los valores aleatorios
					strNonce = new Random().Next(int.MaxValue).ToString("X"); // 123400, 9999999
					strTimestamp = ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
				// Genera la firma
					strSignature = GetSignature(GetDataToSign(objRequest.MethodDescription, objRequest.URL, objRequest.QueryParameters, strNonce, strTimestamp));
				// Añade la cabecera de autorización
					objRequest.Headers.Add("Authorization", GetAuthorizationData(strSignature, strNonce, strTimestamp)); 
		}

		/// <summary>
		///		Obtiene la firma a partir de los datos
		/// </summary>
		private string GetSignature(string strDataToSign)
		{ HMACSHA1 objSha1 = new HMACSHA1(Encoding.ASCII.GetBytes(string.Format("{0}&{1}", ConsumerSecret.UrlEncode(), AccessTokenSecret.UrlEncode())));
 
				// Devuelve la firma
					return Convert.ToBase64String(objSha1.ComputeHash(Encoding.ASCII.GetBytes(strDataToSign.ToString())));
		}

		/// <summary>
		///		Obtiene los datos a firmar
		/// </summary>
		private string GetDataToSign(string strMethodDescription, string strUrl, ParameterDataCollection objColQueryString, string strNonce, string strTimeStamp)
		{ ParameterDataCollection objColParameters = objColQueryString.Clone();
			string strDataToSign = "";

				// Añade los valores oAuth a los parámetros
					objColParameters.Add("oauth_version", cnstStrVersion);
					objColParameters.Add("oauth_consumer_key", ConsumerKey);
					objColParameters.Add("oauth_nonce", strNonce);
					objColParameters.Add("oauth_signature_method", cnstStrSignatureMethod);
					objColParameters.Add("oauth_timestamp", strTimeStamp);
					objColParameters.Add("oauth_token", AccessToken);
				// Ordena los parámetros
					objColParameters.SortByKey();
				// Añade los parámetros a la cadena
					foreach (ParameterData objParameter in objColParameters)
						strDataToSign = strDataToSign.AddWithSeparator(objParameter.Key + "=" + objParameter.ValueEncoded, "&", false);
				// Codifica los parámetros y lo añade a los datos a firmar
					strDataToSign = strMethodDescription + "&" + NormalizeUrl(strUrl).UrlEncode() + "&" + strDataToSign.UrlEncodeRFC3986();
				// Devuelve los datos a firmar
					return strDataToSign;
		}

		/// <summary>
		///		Obtiene los datos de autorización
		/// </summary>
		private string GetAuthorizationData(string strSignature, string strNonce, string strTimestamp)
		{ string strAuthorizationData = "OAuth ";

				// Añade los datos de autorización
					strAuthorizationData += GetAuthorizationParameter("oauth_nonce", strNonce) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_signature_method", cnstStrSignatureMethod) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_timestamp", strTimestamp) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_consumer_key", ConsumerKey) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_token", AccessToken) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_signature", strSignature) + ",";
					strAuthorizationData += GetAuthorizationParameter("oauth_version", cnstStrVersion);
				// Devuelve la cadena
					return strAuthorizationData;
		}

		/// <summary>
		///		Devuelve un parámetro de la cadena de autorización formateado
		/// </summary>
		private string GetAuthorizationParameter(string strKey, string strValue)
		{ return string.Format("{0}=\"{1}\"", strKey, strValue.UrlEncode());
		}

		/// <summary>
		///		Normaliza una URL
		/// </summary>
		private string NormalizeUrl(string url)
		{ Uri objUri = new Uri(url);
			string strPort = string.Empty;
 
				// Obtiene el puerto si no es el predeterminado
					if (objUri.Scheme.EqualsIgnoreCase("http") && objUri.Port != 80 ||
							objUri.Scheme.EqualsIgnoreCase("https") && objUri.Port != 443 ||
							objUri.Scheme.EqualsIgnoreCase("ftp") && objUri.Port != 20)
						strPort = string.Format(":{0}", objUri.Port);
				// Devuelve la URL normalizada
					return string.Format("{0}://{1}{2}{3}", objUri.Scheme, objUri.Host, strPort, objUri.AbsolutePath);
		}

    /// <summary>
    ///		Obtiene los tokens de autorización a Twitter para que la aplicación pueda validar un usuario
    /// </summary>
    public bool GetAuthorizationTokens(string strUrlRequestToken, string strUrlCallBack, out string strOAuthToken, out string strOAuthTokenSecret)
    {	RequestMessage objRequest = new RequestMessage(RequestMessage.MethodType.Post, strUrlRequestToken);
			ResponseMessage objResponse;
			
				// Añade los parámetros
					objRequest.QueryParameters.Add("oaut_callback", strUrlCallBack);
				// Envía el mensaje al servidor
					objResponse = GetResponseOAuth(objRequest);
				// Si todo ha ido bien, el servidor oAuth nos responde con una cadena del tipo: oauth_token=xxx&oauth_token_secret=xxx&oauth_callback_confirmed=true
					ExtractTokensAccess(objResponse, out strOAuthToken, out strOAuthTokenSecret);
				// Devuelve la cadena
					return !strOAuthToken.IsEmpty() && !strOAuthTokenSecret.IsEmpty();
    }
    
		/// <summary>
		///		Obtiene el token de acceso a partir de un PIN
		/// </summary>
		public bool GetAccessToken(string strUrlRequestAccessToken, string strPin, out string strOAuthToken, out string strOAuthTokenSecret)
		{ RequestMessage objRequest = new RequestMessage(RequestMessage.MethodType.Post, strUrlRequestAccessToken);
			ResponseMessage objResponse;

				// Añade los parámetros
					objRequest.QueryParameters.Add("oauth_verifier", strPin);
				// Envía el mensaje al servidor
					objResponse = GetResponseOAuth(objRequest);
				// Obtiene los tokens de la respuesta
					ExtractTokensAccess(objResponse,  out strOAuthToken, out strOAuthTokenSecret);
				// Devuelve el valor que indica si todo ha ido correcto
					return !strOAuthToken.IsEmpty() && !strOAuthTokenSecret.IsEmpty();
		}

    /// <summary>
    ///		Envía una solicitud Web utilizando oAuth
    /// </summary>
    private ResponseMessage GetResponseOAuth(RequestMessage objRequest)
    { RestController objRestController = new RestController("BauRest", 20000, this);

				// Devuelve la respuesta del servidor
					return objRestController.Send(objRequest);
    }

		/// <summary>
		///		Extrae los tokens de acceso de una respuesta
		/// </summary>
		private void ExtractTokensAccess(ResponseMessage objResponse, out string strOAuthToken, out string strOAuthTokenSecret)
		{ // Inicializa los valores de salida
				strOAuthToken = null;
				strOAuthTokenSecret = null;
			// Obtiene los tokens de la respuesta
				if (!objResponse.IsError && !objResponse.Body.IsEmpty())
						{ string [] arrStrBody = objResponse.Body.Split('&');

								// Recorre el array buscando las cadenas
									if (arrStrBody != null && arrStrBody.Length > 0)
										foreach (string strBody in arrStrBody)
											{ string [] arrStrQuery = strBody.Split('=');

													if (arrStrQuery != null && arrStrQuery.Length == 2)
														{ if (arrStrQuery[0].EqualsIgnoreCase("oauth_token"))
																strOAuthToken = arrStrQuery[1];
															else if (arrStrQuery[0].EqualsIgnoreCase("oauth_token_secret"))
																strOAuthTokenSecret = arrStrQuery[1];
														}
											}
						}
		}

		/// <summary>
		///		Clave de aplicación
		/// </summary>
		public string ConsumerKey { get; set; }

		/// <summary>
		///		Clave secreta de aplicación
		/// </summary>
		public string ConsumerSecret { get; set; }

		/// <summary>
		///		Token de acceso
		/// </summary>
		public string AccessToken { get; set; }

		/// <summary>
		///		Token de acceso secreto
		/// </summary>
		public string AccessTokenSecret { get; set; }
	}
}