using System;

using Bau.Libraries.LibRest.Messages;

namespace Bau.Applications.TestLibRest.Projects
{
	/// <summary>
	///		Instrucción para envío de mensajes
	/// </summary>
	public class Instruction
	{ // Variables privadas
			private string strGuid;

		public Instruction()
		{ Request = new RequestMessage(RequestMessage.MethodType.Get, null);
		}

		/// <summary>
		///		ID de la instrucción
		/// </summary>
		public string ID
		{ get 
				{ // Asigna el ID
						if (string.IsNullOrEmpty(strGuid))
							strGuid = Guid.NewGuid().ToString();
					// Devuelve el ID
						return strGuid;
				}
			set { strGuid = value; }
		}

		/// <summary>
		///		Nombre de la instrucción
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///		Solicitud
		/// </summary>
		public RequestMessage Request { get; set; }
	}
}
