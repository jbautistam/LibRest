using System;
using System.Security.Cryptography.X509Certificates;

namespace Bau.Libraries.LibRest
{
	/// <summary>
	///		Controlador para las comunicaciones REST
	/// </summary>
	public class RestController
	{
		public RestController(string strUserAgent = "BauRest", int intTimeOut = 20000, 
													Authentication.IAuthenticator objAuthenticator = null,
													X509Certificate2 objCertificate = null)
		{ // Asigna las propiedades
				UserAgent = strUserAgent;
				TimeOut = intTimeOut;
				Authenticator = objAuthenticator;
				Certificate = objCertificate;
			// Inicializa los objetos
				Proxy = new Proxies.ProxyData();
		}

		/// <summary>
		///		Envía un mensaje
		/// </summary>
		public Messages.ResponseMessage Send(Messages.RequestMessage objRequest)
		{ return new Http.HttpSender().Send(this, objRequest);
		}

		/// <summary>
		///		Agente
		/// </summary>
		public string UserAgent { get; set; }

		/// <summary>
		///		Tiempo de espera
		/// </summary>
		public int TimeOut { get; set; }

		/// <summary>
		///		Clase utilizada para autentificación
		/// </summary>
		public Authentication.IAuthenticator Authenticator { get; set; }

		/// <summary>
		///		Proxy que se utiliza en las comunicaciones
		/// </summary>
		public Proxies.ProxyData Proxy { get; set; }

		/// <summary>
		///		Certificado
		/// </summary>
		public X509Certificate2 Certificate { get; set; }
	}
}
