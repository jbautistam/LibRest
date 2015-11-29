using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibRest.Authentication;

namespace Bau.Applications.TestLibRest.UC.Authentication
{
	/// <summary>
	///		Control de autentificación plano
	/// </summary>
	public partial class ctlAuthenticationPlain : UserControl, IAuthenticationControl
	{
		/// <summary>
		///		Autentificador
		/// </summary>
		public IAuthenticator Authenticator
		{ get { return new PlainAuthenticator(txtUser.Text, txtPassword.Text); }
			set
				{ if (value is PlainAuthenticator)
						{ PlainAuthenticator objAuthenticator = value as PlainAuthenticator;

								if (objAuthenticator != null)
									{ txtUser.Text = objAuthenticator.User;
										txtPassword.Text = objAuthenticator.Password;
									}
						}
				}
		}

		public ctlAuthenticationPlain()
		{ InitializeComponent();
		}
	}
}
