using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibScriptRest.Projects
{
	/// <summary>
	///		Colección de <see cref="RestInstruction"/>
	/// </summary>
	public class RestInstructionsCollection : List<RestInstruction>
	{
		/// <summary>
		///		Añade una instrucción a la colección
		/// </summary>
		public RestInstruction Add(Libraries.LibRest.Messages.RequestMessage.MethodType intMethod, string strUrl)
		{ RestInstruction objInstruction = new RestInstruction();

				// Asigna los datos
					objInstruction.Request = new Libraries.LibRest.Messages.RequestMessage(intMethod, strUrl);
				// Añade la instrución
					Add(objInstruction);
				// ... y la devuelve
					return objInstruction;
		}
	}
}
