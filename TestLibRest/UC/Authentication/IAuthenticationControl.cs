using System;

using Bau.Libraries.LibRest.Authentication;

namespace Bau.Applications.TestLibRest.UC.Authentication
{
	/// <summary>
	///		Interface para los controles de autentificación
	/// </summary>
	public interface IAuthenticationControl
	{
		/// <summary>
		///		Autentificador
		/// </summary>
		IAuthenticator Authenticator { get; set; }
	}
}
