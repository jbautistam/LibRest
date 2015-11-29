using System;
using System.Collections.Generic;
using System.Linq;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibRest.Messages.Parameters
{
	/// <summary>
	///		Colección de <see cref="BaseParameter"/>
	/// </summary>
	public abstract class BaseParametersCollection<TypeData> : List<TypeData> where TypeData : BaseParameter
	{
		/// <summary>
		///		Añade un parámetro a la colección
		/// </summary>
		public new void Add(TypeData objParameter)
		{ // Elimina el parámetro
				Remove(objParameter.Key);
			// Añade el parámetro
				base.Add(objParameter);
		}

		/// <summary>
		///		Indice de un elemento
		/// </summary>
		public int IndexOf(string strKey)
		{ // Busca el elemento
				for (int intIndex = 0; intIndex < Count; intIndex++)
					if (this[intIndex].Key.EqualsIgnoreCase(strKey))
						return intIndex;
			// Devuelve el valor que indica que no existe
				return -1;
		}

		/// <summary>
		///		Busca un elemento en la colección de parámetros
		/// </summary>
		public TypeData Search(string strKey)
		{ return this.FirstOrDefault<TypeData>(objParameter => objParameter.Key.EqualsIgnoreCase(strKey));
		}

		/// <summary>
		///		Elimina un elemento de la colección
		/// </summary>
		public void Remove(string strKey)
		{ int intIndex = IndexOf(strKey);

				if (intIndex >= 0)
					RemoveAt(intIndex);
		}

		/// <summary>
		///		Ordena la colección por clave
		/// </summary>
		public void SortByKey()
		{ Sort(new Comparers.BaseParameterComparer());
		}

		/// <summary>
		///		Obtiene / modifica un elemento de la colección de parámetros
		/// </summary>
		public TypeData this[string strKey]
		{ get { return Search(strKey); }
			set { Add(value); }
		}
	}
}
