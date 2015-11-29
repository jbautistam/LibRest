using System;

namespace Bau.Libraries.LibRest.Messages.Headers
{
	/// <summary>
	///		Datos de la cabecera
	/// </summary>
	public class Header : Parameters.BaseParameter
	{
		public Header(string strKey, string strValue) : base(strKey)
		{ Value = strValue;
		}

		/// <summary>
		///		Valor
		/// </summary>
		public string Value { get; set; }
	}
}
