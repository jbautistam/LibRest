using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibRest.Messages.Parameters
{
	/// <summary>
	///		Clase con los datos de un adjunto
	/// </summary>
	public class Attachment : BaseParameter
	{ // Variables privadas
			private string strFileName;

		public Attachment(string strKey, string strFileName) : base(strKey)
		{ FileName = strFileName;
		}

		/// <summary>
		///		Obtiene el tipo de contenido a partir del nombre de archivo
		/// </summary>
		private void AssignContentType(string strFileName)
		{ string strExtension = System.IO.Path.GetExtension(strFileName);

				// Inicializa el tipo de contenido
					ContentType = "application/octet-stream";
				// Obtiene el tipo de contenido a partir de la extensión
					if (!strExtension.IsEmpty())
						{ // Quita el punto inicial 
								if (strExtension.StartsWith(".") && strExtension.Length > 1)
									strExtension = strExtension.Substring(1);
							// Obtiene el tipo de contenido
								if (strExtension.EqualsIgnoreCase("txt"))
									ContentType = "text/plain";
								else if (strExtension.EqualsIgnoreCase("htm") || strExtension.EqualsIgnoreCase("html"))
									ContentType = "text/html";
								else if (strExtension.EqualsIgnoreCase("xml"))
									ContentType = "text/xml";
								else if (strExtension.EqualsIgnoreCase("rtf"))
									ContentType = "text/richtext";
								else if (strExtension.EqualsIgnoreCase("mid"))
									ContentType = "audio/mid";
								else if (strExtension.EqualsIgnoreCase("wav"))
									ContentType = "audio/wav";
								else if (strExtension.EqualsIgnoreCase("gif"))
									ContentType = "image/gif";
								else if (strExtension.EqualsIgnoreCase("jpg"))
									ContentType = "image/jpeg";
								else if (strExtension.EqualsIgnoreCase("jpeg"))
									ContentType = "image/pjpeg";
								else if (strExtension.EqualsIgnoreCase("png"))
									ContentType = "image/png";
								else if (strExtension.EqualsIgnoreCase("tif") || strExtension.EqualsIgnoreCase("tiff"))
									ContentType = "image/tiff";
								else if (strExtension.EqualsIgnoreCase("bmp"))
									ContentType = "image/bmp";
								else if (strExtension.EqualsIgnoreCase("emf"))
									ContentType = "image/x-emf";
								else if (strExtension.EqualsIgnoreCase("wmf"))
									ContentType = "image/x-wmf";
								else if (strExtension.EqualsIgnoreCase("avi"))
									ContentType = "video/avi";
								else if (strExtension.EqualsIgnoreCase("mpg") || strExtension.EqualsIgnoreCase("mpeg"))
									ContentType = "video/mpeg";
								else if (strExtension.EqualsIgnoreCase("ai") || strExtension.EqualsIgnoreCase("ps") ||
												 strExtension.EqualsIgnoreCase("eps"))
									ContentType = "application/postscript";
								else if (strExtension.EqualsIgnoreCase("pdf"))
									ContentType = "application/pdf";
								else if (strExtension.EqualsIgnoreCase("atom"))
									ContentType = "application/atom+xml";
								else if (strExtension.EqualsIgnoreCase("rss"))
									ContentType = "application/rss+xml";
								else if (strExtension.EqualsIgnoreCase("tar"))
									ContentType = "application/x-compressed";
								else if (strExtension.EqualsIgnoreCase("zip"))
									ContentType = "application/x-zip-compressed";
								else if (strExtension.EqualsIgnoreCase("gzip"))
									ContentType = "application/x-gzip-compressed";
								else if (strExtension.EqualsIgnoreCase("xls"))
									ContentType = "application/vnd.ms-excel";
								else if (strExtension.EqualsIgnoreCase("doc"))
									ContentType = "application/msword";
								else if (strExtension.EqualsIgnoreCase("ppt"))
									ContentType = "application/vnd.ms-powerpoint";
						}
		}

		/// <summary>
		///		Tipo de contenido
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		///		Nombre de archivo
		/// </summary>
		public string FileName 
		{ get { return strFileName; } 
			set
				{ strFileName = value;
					AssignContentType(strFileName);
				}
		}
	}
}
