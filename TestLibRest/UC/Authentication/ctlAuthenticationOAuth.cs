using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibRest.Authentication;
using Bau.Libraries.LibRest.Authentication.Oauth;

namespace Bau.Applications.TestLibRest.UC.Authentication
{
	/// <summary>
	///		Control de autentificación en oAuth
	/// </summary>
	public partial class ctlAuthenticationOAuth : UserControl, IAuthenticationControl
	{
		/// <summary>
		///		Autentificador
		/// </summary>
		public IAuthenticator Authenticator
		{ get
				{ oAuthAuthenticator objAuthenticator = new oAuthAuthenticator();

						// Asigna las propiedades
							 objAuthenticator.ConsumerKey = txtConsumerKey.Text;
							 objAuthenticator.ConsumerSecret = txtConsumerSecret.Text;
							 objAuthenticator.AccessToken = txtOAuthToken.Text;
							 objAuthenticator.AccessTokenSecret = txtOAuthTokenSecret.Text;
						// Devuelve el objeto
							return objAuthenticator;
				}
			set
				{ if (value is oAuthAuthenticator)
						{ oAuthAuthenticator objAuthenticator = value as oAuthAuthenticator;

								if (objAuthenticator != null)
									{ txtConsumerKey.Text = objAuthenticator.ConsumerKey;
										txtConsumerSecret.Text = objAuthenticator.ConsumerSecret;
										txtOAuthToken.Text = objAuthenticator.AccessToken;
										txtOAuthTokenSecret.Text = objAuthenticator.AccessTokenSecret;
									}
						}
				}
		}

		public ctlAuthenticationOAuth()
		{ InitializeComponent();
		}
	}
}
