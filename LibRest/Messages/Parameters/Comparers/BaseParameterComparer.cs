using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibRest.Messages.Parameters.Comparers
{
	/// <summary>
	///		Clase de comparación para ordenar los parámetros de consulta
	/// </summary>
	internal class BaseParameterComparer : IComparer<BaseParameter>
	{
		/// <summary>
		///		Compara dos parámetros
		/// </summary>
		public int Compare(BaseParameter objSource, BaseParameter objTarget)
		{	return (objSource.Key ?? "").CompareTo(objTarget.Key ?? "");
		}
	}
}
