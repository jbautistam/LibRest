using System;

using Bau.Libraries.LibHelper.Extensors;

namespace Bau.Libraries.LibRest.Proxies
{
	/// <summary>
	///		Datos del proxy
	/// </summary>
	public class ProxyData
	{
		public ProxyData() : this(null, 0, null, null, true) {}

		public ProxyData(string strAddress, int intPort, string strUser, string strPassword, bool blnMustBypassLocal,
										 bool? blnEnabled = null)
		{ Address = strAddress;
			Port = intPort;
			User = strUser;
			Password = strPassword;
			MustBypassLocal = blnMustBypassLocal;
			if (blnEnabled != null)
				Enabled = blnEnabled ?? false;
			else
				Enabled = !strAddress.IsEmpty();
		}

		/// <summary>
		///		Dirección del proxy
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		///		Puerto del proxy
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		///		Usuario del proxy
		/// </summary>
		public string User { get; set; }

		/// <summary>
		///		Contraseña del proxy
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		///		Indica si el proxy debe saltarse las direcciones locales
		/// </summary>
		public bool MustBypassLocal { get; set; }

		/// <summary>
		///		Indica si el proxy está activo
		/// </summary>
		public bool Enabled { get; set; }

		/// <summary>
		///		Indica si se debe utilizar un proxy
		/// </summary>
		public bool MustUseProxy
		{ get { return Enabled && !Address.IsEmpty(); }
		}
	}
}
