using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibRest;
using Bau.Libraries.LibRest.Messages;
using Bau.Libraries.LibRest.Messages.Headers;
using Bau.Libraries.LibRest.Messages.Parameters;
using Bau.Applications.TestLibRest.Projects;

namespace Bau.Applications.TestLibRest
{
	/// <summary>
	///		Formulario para el mantenimiento de una instrucción
	/// </summary>
	public partial class frmInstruction : Form
	{
		public frmInstruction()
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Inicializa la instrucción si no estaba en la memoria
				if (Instruction == null)
					Instruction = new Instruction();
			// Inicializa el combo
				cboMethod.Items.Clear();
				cboMethod.AddItem((int) RequestMessage.MethodType.Get, "Get");
				cboMethod.AddItem((int) RequestMessage.MethodType.Post, "Post");
				cboMethod.AddItem((int) RequestMessage.MethodType.Put, "Put");
				cboMethod.AddItem((int) RequestMessage.MethodType.Delete, "Delete");
				cboMethod.AddItem((int) RequestMessage.MethodType.Head, "Head");
				cboMethod.AddItem((int) RequestMessage.MethodType.Options, "Options");
				cboMethod.SelectedIndex = 0;
			// Inicializa los controles
				udtHeaders.InitControl();
				udtParameters.InitControl();
				udtFiles.InitControl();
			// Carga los datos de la instrucción
				LoadInstruction();
		}

		/// <summary>
		///		Limpia los datos
		/// </summary>
		private void Clear()
		{ txtURL.Text = "";
			cboMethod.SelectedIndex = 0;
			txtBody.Text = "";
			udtHeaders.InitControl();
			udtParameters.InitControl();
			udtFiles.InitControl();
		}
		
		/// <summary>
		///		Carga los datos de la instrucción
		/// </summary>
		private void LoadInstruction()
		{ txtName.Text = Instruction.Name;
			txtURL.Text = Instruction.Request.URL;
			txtBody.Text = Instruction.Request.Body;
			cboMethod.SelectedID = (int) Instruction.Request.Method;
			udtHeaders.LoadParameters(Convert(Instruction.Request.Headers));
			udtParameters.LoadParameters(Instruction.Request.QueryParameters);
			udtFiles.LoadParameters(Instruction.Request.Attachments);
		}

		/// <summary>
		///		Convierte una colección de cabeceras en una colección de parámetros
		/// </summary>
		private ParameterDataCollection Convert(HeadersCollection objColHeaders)
		{ ParameterDataCollection objColParameters = new ParameterDataCollection();

				// Convierte las cabeceras
					foreach (Header objHeader in objColHeaders)
						objColParameters.Add(objHeader.Key, objHeader.Value);
				// Devuelve la colección de parámetros
					return objColParameters;
		}

		/// <summary>
		///		Comprueba los datos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;
		
				// Comprueba los datos introducidos
					if (txtName.Text.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca el nombre de la instrucción");
					else if (cboMethod.SelectedIndex < 0)
						Bau.Controls.Forms.Helper.ShowMessage(this, "Seleccione el método de envío");
					else if (string.IsNullOrEmpty(txtURL.Text))
						Bau.Controls.Forms.Helper.ShowMessage(this, "Seleccione la URL");
					else
						blnValidate = true;
				// Devuelve el valor que comprueba si los datos son correctos
					return blnValidate;
		}

		/// <summary>
		///		Graba los datos de la instrucción
		/// </summary>
		private void Save()
		{ if (ValidateData())
				{ // Asigna los datos
						Instruction.Name = txtName.Text;
						Instruction.Request.URL = txtURL.Text;
						Instruction.Request.Method = (RequestMessage.MethodType) cboMethod.SelectedID;
						Instruction.Request.Body = txtBody.Text;
						Instruction.Request.Headers = ConvertToHeaders(udtHeaders.GetParameters());
						Instruction.Request.QueryParameters = ConvertToParameters(udtParameters.GetParameters());
						Instruction.Request.Attachments = udtFiles.GetParameters();
					// Cierra el formulario indicando que ha habido modificaciones
						DialogResult = System.Windows.Forms.DialogResult.OK;
						Close();
				}
		}

		/// <summary>
		///		Convierte un diccionario a una colección de parámetros
		/// </summary>
		private ParameterDataCollection ConvertToParameters(Dictionary<string, string> dctParameters)
		{ ParameterDataCollection objColParameters = new ParameterDataCollection();

				// Asigna los parámetros
					foreach (KeyValuePair<string, string> objParameter in dctParameters)
						objColParameters.Add(objParameter.Key, objParameter.Value);
				// Devuelve la colección
					return objColParameters;
		}

		/// <summary>
		///		Convierte un diccionario a una colección de cabeceras
		/// </summary>
		private HeadersCollection ConvertToHeaders(Dictionary<string, string> dctParameters)
		{ HeadersCollection objColHeaders = new HeadersCollection();

				// Asigna los parámetros
					foreach (KeyValuePair<string, string> objParameter in dctParameters)
						objColHeaders.Add(objParameter.Key, objParameter.Value);
				// Devuelve la colección
					return objColHeaders;
		}

		/// <summary>
		///		Instrucciones
		/// </summary>
		public Instruction Instruction { get; set; }

		private void frmInstruction_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void cmdAccept_Click(object sender, EventArgs e)
		{ Save();
		}
	}
}
