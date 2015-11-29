using System;

namespace Bau.Libraries.LibRest.Messages.Parameters
{
	/// <summary>
	///		Colección de <see cref="ParameterData"/>
	/// </summary>
	public class ParameterDataCollection : BaseParametersCollection<ParameterData>
	{
		/// <summary>
		///		Añade un parámetro a la colección
		/// </summary>
		public void Add(string strKey, string strValue, ParameterData.UrlEncoderType intEncoderType = ParameterData.UrlEncoderType.Normal)
		{ Add(new ParameterData(strKey, strValue, intEncoderType));
		}

		/// <summary>
		///		Añade un valor entero
		/// </summary>
		public void Add(string strName, int? intValue)
		{ if (intValue != null)
				Add(strName, intValue.ToString());
		}

		/// <summary>
		///		Añade un valor doble a la colección de parámetros
		/// </summary>
		public void Add(string strName, double? dblValue)
		{ if (dblValue != null)
				Add(strName, dblValue.ToString().Replace(',', '.'));
		}
		
		/// <summary>
		///		Añade un valor lógico
		/// </summary>
		public void Add(string strName, bool? blnValue)
		{ if (blnValue != null)
				{ if (blnValue ?? true)
						Add(strName, "true");
					else
						Add(strName, "false");
				}
		}

		/// <summary>
		///		Clona una colección
		/// </summary>
		public ParameterDataCollection Clone()
		{ ParameterDataCollection objColParameters = new ParameterDataCollection();

				// Clona los parámetros
					foreach (ParameterData objParameter in this)
						objColParameters.Add(objParameter.Clone());
				// Devuelve la colección clonada
					return objColParameters;
		}
	}
}
