using System;

using Bau.Libraries.LibRest;
using Bau.Libraries.LibRest.Authentication;

namespace Bau.Libraries.LibScriptRest.Projects
{
	/// <summary>
	///		Proyecto
	/// </summary>
	public class RestProgram
	{
		/// <summary>
		///		Contexto
		/// </summary>
		public RestController Context { get; set; } = new RestController();

		/// <summary>
		///		Autentificación
		/// </summary>
		public IAuthenticator Authenticator { get; set; }

		/// <summary>
		///		Instrucciones
		/// </summary>
		public RestInstructionsCollection Instructions { get; set; } = new RestInstructionsCollection();
	}
}
