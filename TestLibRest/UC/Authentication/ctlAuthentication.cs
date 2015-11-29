using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibRest.Authentication;
using Bau.Libraries.LibRest.Authentication.Oauth;

namespace Bau.Applications.TestLibRest.UC.Authentication
{
	/// <summary>
	///		Control de autentificación
	/// </summary>
	public partial class ctlAuthentication : UserControl, IAuthenticationControl
	{ // Enumerados públicos
			private enum AuthenticationType
				{ NoAuthentication,
					Plain,
					oAuth
				}

		public ctlAuthentication()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el control
		/// </summary>
		public void InitControl()
		{ // Carga el combo de autorización
				LoadComboAuthorization();
		}

		/// <summary>
		///		Carga el combo de autorización
		/// </summary>
		private void LoadComboAuthorization()
		{ // Limpia el combo
				cboAuthentication.Items.Clear();
			// Añade los elementos
				cboAuthentication.AddItem((int) AuthenticationType.NoAuthentication, "Sin autentificación");
				cboAuthentication.AddItem((int) AuthenticationType.Plain, "Plano");
				cboAuthentication.AddItem((int) AuthenticationType.oAuth, "oAuth");
			// Selecciona el primer elemento
				cboAuthentication.SelectedID = (int) AuthenticationType.NoAuthentication;
		}

		/// <summary>
		///		Muestra los controles
		/// </summary>
		private void EnableControls()
		{ udtAuthenticationPlain.Visible = cboAuthentication.SelectedID == (int) AuthenticationType.Plain;
			udtAuthenticationOAuth.Visible = cboAuthentication.SelectedID == (int) AuthenticationType.oAuth;
			switch ((AuthenticationType) cboAuthentication.SelectedID)
				{ case AuthenticationType.Plain:
							udtAuthenticationPlain.Dock = DockStyle.Fill;
						break;
					case AuthenticationType.oAuth:
							udtAuthenticationOAuth.Dock = DockStyle.Fill;
						break;
				}
		}

		/// <summary>
		///		Obtiene el control autentificado
		/// </summary>
		private IAuthenticationControl GetControlSelected()
		{ switch ((AuthenticationType) cboAuthentication.SelectedID)
				{ case AuthenticationType.Plain:
						return udtAuthenticationPlain;
					case AuthenticationType.oAuth:
						return udtAuthenticationOAuth;
					default:
						return null;
				}
		}

		/// <summary>
		///		Autentificador
		/// </summary>
		public IAuthenticator Authenticator 
		{ get 
				{ IAuthenticationControl objAuthenticator = GetControlSelected(); 

						if (objAuthenticator == null)
							return null;
						else
							return objAuthenticator.Authenticator;
				}
			set 
				{ IAuthenticationControl objAuthenticator;

						// Selecciona el autentificador en el combo
							cboAuthentication.SelectedID = (int) AuthenticationType.NoAuthentication;
							if (value != null)
								{ if (value is PlainAuthenticator)
										cboAuthentication.SelectedID = (int) AuthenticationType.Plain;
									else if (value is oAuthAuthenticator)
										cboAuthentication.SelectedID = (int) AuthenticationType.oAuth;
								}
						// Asigna el autentificador
							objAuthenticator = GetControlSelected();
							if (objAuthenticator != null)
								objAuthenticator.Authenticator = value;
				}
		}

		private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
		{ EnableControls();
		}
	}
}
