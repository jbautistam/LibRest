using System;

namespace Bau.Libraries.LibScriptRest.Errors
{
	/// <summary>
	///		Error sintáctico en la interpretación
	/// </summary>
	public class SyntaxError
	{
		public SyntaxError(int intLine, string strInstruction, string strMessage)
		{ Line = intLine;
			Instruction = strInstruction;
			Message = strMessage;
		}

		/// <summary>
		///		Línea en la que genera el error
		/// </summary>
		public int Line { get; private set; }

		/// <summary>
		///		Instrucción que generó el error
		/// </summary>
		public string Instruction { get; private set; }

		/// <summary>
		///		Mensaje de error
		/// </summary>
		public string Message { get; private set; }
	}
}
