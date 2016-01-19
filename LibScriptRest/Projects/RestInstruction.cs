using System;

using Bau.Libraries.LibRest.Messages;

namespace Bau.Libraries.LibScriptRest.Projects
{
	/// <summary>
	///		Instrucción para envío de mensajes
	/// </summary>
	public class RestInstruction
	{ 
		public RestInstruction()
		{ Request = new RequestMessage(RequestMessage.MethodType.Get, null);
		}

		/// <summary>
		///		Solicitud
		/// </summary>
		public RequestMessage Request { get; set; }

		/// <summary>
		///		Respuesta
		/// </summary>
		public ResponseMessage Response { get; set; }

		/// <summary>
		///		Excepción asociado al envío de la instrucción
		/// </summary>
		public Exception Exception { get; internal set; }
	}
}
