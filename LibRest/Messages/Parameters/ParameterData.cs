using System;

using Bau.Libraries.LibRest.Encoders;

namespace Bau.Libraries.LibRest.Messages.Parameters
{
	/// <summary>
	///		Parámetro
	/// </summary>
	public class ParameterData : BaseParameter
	{ 
		/// <summary>
		///		Tipo de codificación para los valores
		/// </summary>
		public enum UrlEncoderType
			{ 
				/// <summary>Codificación de parámetros normal</summary>
				Normal,
				/// <summary>Codificación de parámetros utilizando Rfc3986</summary>
				Rfc3986
			}

		public ParameterData(string strKey, string strValue, UrlEncoderType intEncoderType = UrlEncoderType.Normal) : base(strKey)
		{ Value = strValue;
			EncoderType = intEncoderType;
		}

		/// <summary>
		///		Clona un parámetro
		/// </summary>
		public ParameterData Clone()
		{ return new ParameterData(Key, Value, EncoderType);
		}

		/// <summary>
		///		Tipo de codificación utilizado en el valor
		/// </summary>
		public UrlEncoderType EncoderType { get; set; }

		/// <summary>
		///		Valor del parámetro
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		///		Valor del parámetro codificado
		/// </summary>
		public string ValueEncoded
		{ get { return Value.UrlEncode(EncoderType); }
		}

		/// <summary>
		///		Valor completo: Key + "=" + ValueEncoded
		/// </summary>
		public string FullValue
		{ get { return Key + "=" + ValueEncoded; }
		}
	}
}
