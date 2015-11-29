using System;

namespace Bau.Libraries.LibRest.Messages.Parameters
{
	/// <summary>
	///		Clase base para los parámetros que se pueden añadir a un mensaje
	/// </summary>
	public abstract class BaseParameter
	{
		public BaseParameter(string strKey)
		{ Key = strKey;
		}

		/// <summary>
		///		Clave del parámetro
		/// </summary>
		public string Key { get; private set; }
	}
}
