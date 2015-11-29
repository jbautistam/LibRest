using System;

namespace Bau.Libraries.LibRest.Authentication
{
	/// <summary>
	///		Interface que deben cumplir las clases utilizadas para la autentificación
	/// </summary>
	public interface IAuthenticator
	{
		/// <summary>
		///		Procesa utilizando un sistema de autentificación
		/// </summary>
		void Process(Messages.RequestMessage objRequest);
	}
}
