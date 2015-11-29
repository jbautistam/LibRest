using System;

namespace Bau.Libraries.LibRest.Messages.Headers
{
	/// <summary>
	///		Colección de <see cref="Header"/>
	/// </summary>
	public class HeadersCollection : Parameters.BaseParametersCollection<Header>
	{
		/// <summary>
		///		Añade una cabecera a la colección
		/// </summary>
		public void Add(string strKey, string strValue)
		{ Add(new Header(strKey, strValue));
		}
	}
}
