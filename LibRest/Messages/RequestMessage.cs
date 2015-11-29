using System;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibRest.Messages.Parameters;

namespace Bau.Libraries.LibRest.Messages
{
	/// <summary>
	///		Mensaje para una solicitud
	/// </summary>
	public class RequestMessage : BaseMessage
	{
		// Enumerados públicos
			public enum MethodType
				{ Get,
					Post,
					Put,
					Delete,
					Head,
					Options
				}

		public RequestMessage(MethodType intMethod, string strURL)
		{ // Asigna las propiedades
				Method = intMethod;
				URL = strURL;
			// Asigna los valores básicos
				ContentType = "text/xml";
			// Define los objetos
				UrlParameters = new ParameterDataCollection();
				QueryParameters = new ParameterDataCollection();
				Attachments = new AttachmentsCollection();
		}

		/// <summary>
		///		Obtiene la URL con los parámetros de consulta
		/// </summary>
		public string GetUrlWithQueryString(bool blnOnlyForMethodGet = false)
		{ string strUrl = URL;

				// Sustituye las secciones de la Url
					if (UrlParameters != null)
						foreach (ParameterData objUrlParameter in UrlParameters)
							strUrl = strUrl.ReplaceWithStringComparison("{" + objUrlParameter.Key + "}", objUrlParameter.Value);
				// Añade los parámetros
					if (QueryParameters != null && (!blnOnlyForMethodGet ||
																					(blnOnlyForMethodGet && Method == RequestMessage.MethodType.Get)))
						foreach (ParameterData objParameter in QueryParameters)
							{ // Añade el separador
									if (strUrl.IndexOf('?') < 0)
										strUrl += '?';
									else
										strUrl += '&';
								// Añade los parámetros
									strUrl += objParameter.Key + "=" + objParameter.ValueEncoded;
							}
				// Devuelve la URL
					return strUrl;
		}

		/// <summary>
		///		Método de envío
		/// </summary>
		public MethodType Method { get; set; }

		/// <summary>
		///		Método de envío --> cadena
		/// </summary>
		internal string MethodDescription
		{ get { return Method.ToString().ToUpper(); }
		}

		/// <summary>
		///		URL
		/// </summary>
		public string	URL { get; set; }

		/// <summary>
		///		Tipo de contenido
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		///		Cuerpo del mensaje
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		///		Parámetros de la Url (por ejemplo: http://www.sample.com/Client/{Id}/{Order}/)
		/// </summary>
		public ParameterDataCollection UrlParameters { get; set; }

		/// <summary>
		///		Parámetros de consulta
		/// </summary>
		public ParameterDataCollection QueryParameters { get; set; }

		/// <summary>
		///		Archivos adjuntos
		/// </summary>
		public AttachmentsCollection Attachments { get; set; }
	}
}
