using System;

namespace Bau.Libraries.LibRest.Encoders
{
	/// <summary>
	///		Interface que deben cumplir las clases de codificación
	/// </summary>
	public interface IEncoder
	{
		/// <summary>
		///		Codifica una cadena 
		/// </summary>
		string Encode(string strSource, bool blnSubject);
		
		/// <summary>
		///		Codifica un array de bytes
		/// </summary>
		string Encode(byte [] arrBytSource, bool blnSuject);
		
		/// <summary>
		///		Decodifica una cadena
		/// </summary>
    string Decode(string strSource, bool blnSubject);
		
		/// <summary>
		///		Decodifica un array de bytes en una cadena
		/// </summary>
    string Decode(byte [] arrBytSource, bool blnSubject);
    
    /// <summary>
    ///		Decodifica en un array de bytes una cadena
    /// </summary>
		byte [] DecodeToBytes(string strSource, bool blnSubject);
    
		/// <summary>
		///		Decodifica en un array de bytes otro array de bytes
		/// </summary>
		byte [] DecodeToBytes(byte [] arrBytSource, bool blnSubject);
	}
}