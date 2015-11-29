using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bau.Applications.TestLibRest.UC
{
	/// <summary>
	///		Formulario con los datos de un parámetro
	/// </summary>
	public partial class frmParameter : Form
	{
		public frmParameter()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ LoadParameter();
		}

		/// <summary>
		///		Carga los datos del parámetro
		/// </summary>
		private void LoadParameter()
		{ txtName.Text = Parameter.Key;
			txtValue.Text = Parameter.Value;
		}

		/// <summary>
		///		Comprueba los datos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false; // ...supone que los datos no son correctos

				// Comprueba los datos
					if (string.IsNullOrEmpty(txtName.Text))
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca la clave del parámetro");
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}

		/// <summary>
		///		Graba los datos
		/// </summary>
		private void Save()
		{ if (ValidateData())
				{ // Crea un nuevo objeto
						Parameter = new KeyValuePair<string,string>(txtName.Text, txtValue.Text);
					// Cierra el formulario indicando que se han grabado los datos
						DialogResult = System.Windows.Forms.DialogResult.OK;
						Close();
				}
		}

		/// <summary>
		///		Parámetro a modificar
		/// </summary>
		public KeyValuePair<string, string> Parameter { get; set; }

		private void frmParameter_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}
