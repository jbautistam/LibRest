using System;

namespace Bau.Libraries.LibRest.Authentication
{
	/// <summary>
	///		Autentificador en formato plano
	/// </summary>
	public class PlainAuthenticator : IAuthenticator
	{
		public PlainAuthenticator(string strUser, string strPassword)
		{ User = strUser;
			Password = strPassword;
		}

		/// <summary>
		///		Procesa el sistema de autentificación
		/// </summary>
		public void Process(Messages.RequestMessage objRequest)
		{ string strAuthorization = User + ":" + Password;

				// Codifica en Base64 la cadena de usuario y contraseña
					strAuthorization = new Encoders.BinayEncoder().Encode(strAuthorization, false);
				// Añade la cabecera de autorización		
					objRequest.Headers.Add("Authorization", "Basic " + strAuthorization);
		}

		/// <summary>
		///		Usuario
		/// </summary>
		public string User { get; set; }

		/// <summary>
		///		Contraseña
		/// </summary>
		public string Password { get; set; }
	}
}
