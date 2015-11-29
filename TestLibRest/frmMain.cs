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
using Bau.Libraries.LibRest.Authentication;

namespace Bau.Applications.TestLibRest
{
	/// <summary>
	///		Formulario principal para las pruebas
	/// </summary>
	public partial class frmMain : Form
	{ // Constantes privadas
			private const string cnstStrMaskFiles = "Archivos REST (*.rst)|*.rst|Todos los archivos (*.*)|*.*";
		// Variables privadas
			private Projects.Project objProject = new Projects.Project();

		public frmMain()
		{	InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ Clear();
		}

		/// <summary>
		///		Limpia los datos
		/// </summary>
		private void Clear()
		{ // Crea un nuevo objeto de proyecto
				objProject = new Projects.Project();
			// Inicializa los controles
				udtAuthentication.InitControl();
				udtAuthentication.Authenticator = null;
				txtResult.Text = "";
				chkUseProxy.Checked = false;
				txtProxyIp.Text = "";
				nudProxyPort.Value = 0;
			// Inicializa la lista de instrucciones
				InitListInstructions();
		}

		/// <summary>
		///		Habilita / inhabilita los controles
		/// </summary>
		private void EnableControls()
		{ txtProxyIp.Enabled = chkUseProxy.Checked;
			nudProxyPort.Enabled = chkUseProxy.Checked;
			txtUserProxy.Enabled = chkUseProxy.Checked;
			txtPasswordProxy.Enabled = chkUseProxy.Checked;
		}

		/// <summary>
		///		Inicializa la lista de instrucciones
		/// </summary>
		private void InitListInstructions()
		{ // Limpia la lista
				lswInstructions.Clear();
			// Añade las columnas
				lswInstructions.AddColumn(200, "Instrucción");
				lswInstructions.AddColumn(300, "Url");
				lswInstructions.AddColumn(200, "Método");
		}

		/// <summary>
		///		Carga la lista de instrucciones
		/// </summary>
		private void LoadListInstructions()
		{	// Inicializa la lista
				InitListInstructions();
			// Carga la lista
				if (objProject != null)
					foreach (Projects.Instruction objInstruction in objProject.Instructions)
						{ ListViewItem lsiItem = lswInstructions.AddRecord(objInstruction.ID, objInstruction.Name);

								lsiItem.SubItems.Add(objInstruction.Request.URL);
								lsiItem.SubItems.Add(objInstruction.Request.Method.ToString());
						}
		}

		/// <summary>
		///		Abre el formulario de modificación de instrucciones
		/// </summary>
		private void OpenFormUpdateInstruction(string strKey)
		{ frmInstruction frmNewInstruction = new frmInstruction();

				// Asigna las propiedades
					frmNewInstruction.Instruction = objProject.Instructions[strKey];
				// Muestra el formulario
					frmNewInstruction.ShowDialog();
				// Guarda los datos
					if (frmNewInstruction.DialogResult == System.Windows.Forms.DialogResult.OK)
						{ // Asigna la instrucción
								if (strKey.IsEmpty())
									objProject.Instructions.Add(frmNewInstruction.Instruction);
								else
									objProject.Instructions[strKey] = frmNewInstruction.Instruction;
							// Actualiza la lista
								LoadListInstructions();
						}
		}

		/// <summary>
		///		Borra una instrucción
		/// </summary>
		private void DeleteInstruction(string strKey)
		{ if (!strKey.IsEmpty() && Bau.Controls.Forms.Helper.ShowQuestion(this, "¿Realmente desea eliminar esta instrucción?"))
				{ // Borra la instrucción
						objProject.Instructions.Remove(strKey);
					// Carga la lista
						LoadListInstructions();
				}
		}

		/// <summary>
		///		Comprueba los datos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;

				// Comprueba los datos
					if (objProject == null)
						Bau.Controls.Forms.Helper.ShowMessage(this, "No hay ningún proyecto");
					else if (objProject.Instructions.Count == 0)
						Bau.Controls.Forms.Helper.ShowMessage(this, "El proyecto no tiene instrucciones");
					else if (chkUseProxy.Checked && txtProxyIp.Text.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca la dirección del proxy");
					else if (chkUseProxy.Checked && nudProxyPort.Value == 0)
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca el puerto del proxy");
					else
						blnValidate = true;
				// Devuelve el valor que indica si los datos son correctos
					return blnValidate;
		}

		/// <summary>
		///		Envía los datos
		/// </summary>
		private void Send()
		{ if (ValidateData())
				{ RestController objRestController = new RestController();

						// Asigna el proxy
							AssignContext(objRestController);
						// Ejecuta las instrucciones
							foreach (Projects.Instruction objInstruction in objProject.Instructions)
								ShowResponse(objRestController.Send(objInstruction.Request));
				}
		}

		/// <summary>
		///		Asigna los datos del proxy
		/// </summary>
		private void AssignContext(RestController objRestController) 
		{	// Asigna el proxy
				objRestController.Proxy = new Libraries.LibRest.Proxies.ProxyData(txtProxyIp.Text, (int) nudProxyPort.Value, 
																																					txtUserProxy.Text, txtPasswordProxy.Text, true,
																																					chkUseProxy.Enabled);
			// Asigna la autentificación
				objRestController.Authenticator = udtAuthentication.Authenticator;
		}

		/// <summary>
		///		Muestra la respuesta
		/// </summary>
		private void ShowResponse(ResponseMessage objResponse)
		{ txtResult.AppendText("Estado: " + (int) objResponse.Status + " -- " + objResponse.Status.ToString() + Environment.NewLine);
			txtResult.AppendText(Environment.NewLine + "--------------------------------------" + Environment.NewLine);
			txtResult.AppendText("Cabeceras:" + Environment.NewLine);
			foreach (Header objHeader in objResponse.Headers)
				txtResult.AppendText(objHeader.Key + ": " + objHeader.Value + Environment.NewLine);
			txtResult.AppendText(Environment.NewLine + "--------------------------------------" + Environment.NewLine);
			txtResult.AppendText("Cuerpo:" + Environment.NewLine);
			txtResult.AppendText(GetBody(objResponse.Body) + Environment.NewLine);
			txtResult.AppendText("=======================================================" + Environment.NewLine);
		}
		
		/// <summary>
		///		Obtiene un texto adecuado para añadirlo a un cuadro de texto
		/// </summary>
		private string GetBody(string strBody)
		{ string strResult = strBody.Replace("\r\n", Environment.NewLine);
		
				// Reemplaza el resto de los "caracteres extraños"
					strResult = strResult.Replace("\r", Environment.NewLine);
					strResult = strResult.Replace("\n", Environment.NewLine);
					strResult = strResult.Replace("\t", "     ");
				// Devuelve el cuerpo resultante
					return strResult;
		}
		
		/// <summary>
		///		Abre un archivo REST
		/// </summary>
		private void OpenFileRest()
		{ string strFileName = Bau.Controls.Forms.Helper.GetFileNameOpen(cnstStrMaskFiles);

				if (!string.IsNullOrEmpty(strFileName))
					{ // Carga los datos del archivo
							objProject = new Projects.ProjectRepository().Load(strFileName);
						// Muestra los datos del proxy
							txtProxyIp.Text = objProject.Context.Proxy.Address;
							nudProxyPort.Value = objProject.Context.Proxy.Port;
							chkUseProxy.Checked = !txtProxyIp.Text.IsEmpty();
						// Carga las instrucciones y los datos de autentificación
							LoadListInstructions();
							udtAuthentication.Authenticator = objProject.Authenticator;
					}
		}

		/// <summary>
		///		Graba un archivo REST
		/// </summary>
		private void Save()
		{ string strFileName = Bau.Controls.Forms.Helper.GetFileNameSave(cnstStrMaskFiles);

				if (!string.IsNullOrEmpty(strFileName))
					{ // Asigna los datos de contexto
							AssignContext(objProject.Context);
						// Graba el archivo 
							new Projects.ProjectRepository().Save(strFileName, objProject);
					}
		}

		/// <summary>
		///		Acciones antes de salir de la aplicación
		/// </summary>
		private void ExitApp()
		{ 
		}

		private void cmdSend_Click(object sender, EventArgs e)
		{ Send();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) 
		{ ExitApp();
		}

		private void cmdOpen_Click(object sender, EventArgs e)
		{ OpenFileRest();
		}

		private void cmdSave_Click(object sender, EventArgs e)
		{ Save();
		}

		private void cmdClear_Click(object sender, EventArgs e)
		{ if (tabControl1.TabIndex == 0)
				Clear();
			else
				txtResult.Text = "";
		}

		private void lswInstructions_OnUpdateRecord(object objSender, string strKey)
		{ OpenFormUpdateInstruction(strKey);
		}

		private void lswInstructions_OnDeleteRecord(object objSender, string strKey)
		{ DeleteInstruction(strKey);
		}

		private void chkUseProxy_CheckedChanged(Object sender,EventArgs e) 
		{ EnableControls();
		}
	}
}