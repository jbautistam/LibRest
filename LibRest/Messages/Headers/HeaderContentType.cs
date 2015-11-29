using System;

namespace Bau.Libraries.LibRest.Messages.Parameters.Headers
{
	/// <summary>
	///		Cabecera para los tipos de contenido
	/// </summary>
	public class HeaderContentType
	{	// Variables privadas
			private string strContentType;
		
		/// <summary>
		///		Tipo de contenido
		/// </summary>
		public string ContentType
		{ get { return strContentType; }
			set { strContentType = value; }
		}
	}
}
