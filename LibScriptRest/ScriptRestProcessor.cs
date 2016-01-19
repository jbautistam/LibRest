using System;

using Bau.Libraries.LibRest;

namespace Bau.Libraries.LibScriptRest
{
	/// <summary>
	///		Procesador para scripts de Rest
	/// </summary>
	public class ScriptRestProcessor
	{
		/// <summary>
		///		Limpia la memoria del procesador
		/// </summary>
		public void Clear()
		{ Program = new Projects.RestProgram();
			Errors.Clear();
		}

		/// <summary>
		///		Ejecuta las instrucciones de un script Rest
		/// </summary>
		public void Execute(string strScript)
		{ Parser.ScriptParser objParser = new Parser.ScriptParser(this);

				// Limpia los datos
					Clear();
				// Interpreta el script
					objParser.Parse(strScript);
				// Ejecuta el programa resultante
					if (Errors.Count == 0 && Program.Instructions.Count > 0)
						Send(Program);
		}

		/// <summary>
		///		Envía los mensajes del proyecto
		/// </summary>
		private void Send(Projects.RestProgram objProgram)
		{	RestController objRestController = new RestController();

				// Asigna los datos de solicitud
					objRestController.UserAgent = objProgram.Context.UserAgent;
					objRestController.TimeOut = objProgram.Context.TimeOut;
					objRestController.Certificate = objProgram.Context.Certificate;
					objRestController.Proxy = objProgram.Context.Proxy;
					objRestController.Authenticator = objProgram.Context.Authenticator;
				// Ejecuta las instrucciones
					foreach (Projects.RestInstruction objInstruction in objProgram.Instructions)
						try
							{ objInstruction.Response = objRestController.Send(objInstruction.Request);
							}
						catch (Exception objException)
							{ objInstruction.Exception = objException;
							}
		}

		/// <summary>
		///		Proyecto interpretado
		/// </summary>
		public Projects.RestProgram Program { get; private set; } = new Projects.RestProgram();

		/// <summary>
		///		Errores de interpretación
		/// </summary>
		public System.Collections.Generic.List<Errors.SyntaxError> Errors { get; internal set; } = new System.Collections.Generic.List<Errors.SyntaxError>();
	}
}
