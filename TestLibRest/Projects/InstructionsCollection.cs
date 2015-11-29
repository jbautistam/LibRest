using System;
using System.Collections.Generic;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Applications.TestLibRest.Projects
{
	/// <summary>
	///		Colección de <see cref="Instruction"/>
	/// </summary>
	public class InstructionsCollection : List<Instruction>
	{
		/// <summary>
		///		Indice de un elemento
		/// </summary>
		public int IndexOf(string strKey)
		{ // Busca el índice del elemento
				for (int intIndex = 0; intIndex < Count; intIndex++)
					if (this[intIndex].ID.EqualsIgnoreCase(strKey))
						return intIndex;
			// Si ha llegado hasta aquí es porque no ha encontrado ningún elemento
				return -1;
		}

		/// <summary>
		///		Elimina un elemento
		/// </summary>
		public void Remove(string strKey)
		{ int intIndex = IndexOf(strKey);

				if (intIndex != -1)
					RemoveAt(intIndex);
		}

		/// <summary>
		///		Obtiene un elemento
		/// </summary>
		public Instruction this[string strKey]
		{ get
				{ int intIndex = IndexOf(strKey);

						if (intIndex < 0)
							return null;
						else
							return this[intIndex];
				}
			set
				{ int intIndex = IndexOf(strKey);

						if (intIndex >= 0)
							this[intIndex] = value;
				}
		}
	}
}
