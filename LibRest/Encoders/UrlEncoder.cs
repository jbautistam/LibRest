using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibRest.Encoders
{
	/// <summary>
	///		Codificador para las Url
	/// </summary>
	internal static class UrlEncoder
	{ // Constante con los caracteres que no entran dentro del conjunto de caracteres reservados
			private const string cnstStrUnreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

		/// <summary>
		///		Codifica utilizando el sistema RFC 3986
		/// </summary>
		internal static string UrlEncode(this string strValue, Messages.Parameters.ParameterData.UrlEncoderType intEncoderType)
		{ switch (intEncoderType)
				{ case Messages.Parameters.ParameterData.UrlEncoderType.Rfc3986:
						return UrlEncodeRFC3986(strValue);
					default:
						return UrlEncode(strValue);
				}
		}

		/// <summary>
		///		Codifica utilizando el sistema RFC 3986
		/// </summary>
		internal static string UrlEncodeRFC3986(this string strValue)
		{ if (strValue.IsEmpty())
				return "";
			else
				{ string strEncoded = Uri.EscapeDataString(strValue);
 
						// Reemplaza los valores codificados por los valores de RFC 3986
							return Regex.Replace(strEncoded, "(%[0-9a-f][0-9a-f])", chrChar => chrChar.Value.ToUpper())
															.Replace("(", "%28")
															.Replace(")", "%29")
															.Replace("$", "%24")
															.Replace("!", "%21")
															.Replace("*", "%2A")
															.Replace("'", "%27")
															.Replace("%7E", "~");
				}
		}

    /// <summary>
    ///		Codifica una URL. Es diferente a la implementación predeterminada de .NET porque envía los caracteres
		///	hexadecimales en mayúsculas como especifica OAuth
    /// </summary>
    internal static string UrlEncode(this string strValue)
    { if (strValue.IsEmpty())
				return "";
			else
				{ StringBuilder sbResult = new StringBuilder();

						// Recorre los caracteres codificándolos
							foreach (char chrSymbol in strValue)
								if (cnstStrUnreservedChars.IndexOf(chrSymbol) != -1)
									sbResult.Append(chrSymbol);
								else if (string.Format("{0:X2}", (int) chrSymbol).Length > 3) // algunos caracteres producen cadenas con más de dos caracteres, se utiliza el urlencoder predeterminado para obtener el valor correcto
									sbResult.Append(HttpUtility.UrlEncode(strValue.Substring(strValue.IndexOf(chrSymbol), 1)).ToUpper());
								else
									sbResult.Append('%' + string.Format("{0:X2}", (int) chrSymbol));
						// Devuelve la cadena codificada
							return sbResult.ToString();
				}
    }
	}
}
