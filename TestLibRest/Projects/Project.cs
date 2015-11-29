using System;

using Bau.Libraries.LibRest;
using Bau.Libraries.LibRest.Authentication;

namespace Bau.Applications.TestLibRest.Projects
{
	/// <summary>
	///		Proyecto
	/// </summary>
	public class Project
	{
		public Project()
		{ Context =  new RestController();
			Instructions = new InstructionsCollection();
		}

		/// <summary>
		///		Contexto
		/// </summary>
		public RestController Context { get; set; }

		/// <summary>
		///		Autentificación
		/// </summary>
		public IAuthenticator Authenticator { get; set; }

		/// <summary>
		///		Instrucciones
		/// </summary>
		public InstructionsCollection Instructions { get; set; }
	}
}
