using System;
using System.Net;

namespace Bau.Libraries.LibRest.Messages
{
	/// <summary>
	///		Mensaje de respuesta del servidor
	/// </summary>
	public class ResponseMessage : BaseMessage
	{
		public ResponseMessage(HttpStatusCode intStatus, string strBody, Exception objException = null)
		{ Status = intStatus;
			Body = strBody;
			Exception = objException;
		}

		/// <summary>
		///		Código de estado de la respuesta del servidor
		/// </summary>
		public HttpStatusCode Status { get; internal set; }

		/// <summary>
		///		Descripción del estado
		/// </summary>
		public string StatusDescription { get; internal set; }

		/// <summary>
		///		Codificación del contenido
		/// </summary>
		public string ContentEncoding { get; internal set; }

		/// <summary>
		///		Longitud del contenido
		/// </summary>
		public long ContentLength { get; internal set; }

		/// <summary>
		///		Tipo de contenido
		/// </summary>
		public string ContentType { get; internal set; }

		/// <summary>
		///		Indica si el contenido se obtiene de caché
		/// </summary>
		public bool IsFromCache { get; internal set; }

		/// <summary>
		///		Indica si se ha autentificado en cliente y servidor
		/// </summary>
		public bool IsMutuallyAuthenticated { get; internal set; }

		/// <summary>
		///		Fecha de última modificación del recurso devuelto
		/// </summary>
		public DateTime LastModified { get; internal set; }

		/// <summary>
		///		Método de la respuesta
		/// </summary>
		public string Method { get; internal set; }

		/// <summary>
		///		Versión del protocolo
		/// </summary>
		public Version ProtocolVersion { get; internal set; }

		/// <summary>
		///		Uri de la respuesta
		/// </summary>
		public Uri ResponseUri { get; internal set; }

		/// <summary>
		///		Servidor de la respuesta
		/// </summary>
		public string Server { get; internal set; }

		/// <summary>
		///		Mensaje de salida
		/// </summary>
		public string Body { get; internal set; }

		/// <summary>
		///		Excepción asociada al mensaje
		/// </summary>
		public Exception Exception { get; private set; }

		/// <summary>
		///		Indica si es un error
		/// </summary>
		public bool IsError 
		{ get 
				{ return Exception != null || (Status != HttpStatusCode.Accepted && Status != HttpStatusCode.Continue && Status != HttpStatusCode.Created &&
																			 Status != HttpStatusCode.Found && Status != HttpStatusCode.OK); 
				}
		}

		/// <summary>
		///		Descripción del error
		/// </summary>
		public string ErrorDescription
		{ get
				{ string strError = " Status: " + Status.ToString() + " (" + StatusDescription + ")";

						// Añade la excepción (si la hubiese)
							if (Exception != null)
								strError += ". Excepción: " + Exception.Message;
						// Devuelve el error
							return strError;
				}
		}
	}
}
