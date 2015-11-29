using System;

namespace Bau.Libraries.LibRest.Messages.Parameters
{
	/// <summary>
	///		Colección de <see cref="Attachment"/>
	/// </summary>
	public class AttachmentsCollection : BaseParametersCollection<Attachment>
	{
		/// <summary>
		///		Añade un adjunto
		/// </summary>
		public void Add(string strFileName)
		{ Add(Count.ToString(), strFileName);
		}

		/// <summary>
		///		Añade un adjunto
		/// </summary>
		public void Add(string strKey, string strFileName)
		{ Add(new Attachment(strKey, strFileName));
		}
	}
}
