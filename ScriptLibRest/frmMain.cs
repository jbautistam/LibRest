using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Bau.Libraries.LibHelper.Extensors;
using Bau.Libraries.LibRest.Messages;
using Bau.Libraries.LibRest.Messages.Headers;
using Bau.Libraries.LibScriptRest;
using Bau.Libraries.LibScriptRest.Projects;

namespace Bau.Applications.ScriptLibRest
{
	/// <summary>
	///		Formulario principal para las pruebas
	/// </summary>
	public partial class frmMain : Form
	{ // Constantes privadas
			private const string cnstStrMaskFiles = "Archivos REST (*.rst)|*.rst|Todos los archivos (*.*)|*.*";

		public frmMain()
		{	InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ Clear();
			if (!Properties.Settings.Default.LastFile.IsEmpty())
				OpenFileRest(Properties.Settings.Default.LastFile);
		}

		/// <summary>
		///		Limpia los datos
		/// </summary>
		private void Clear()
		{ txtInstructions.Text = "";
			txtResult.Text = "";
			ShowDirty(false);
		}

		/// <summary>
		///		Comprueba los datos
		/// </summary>
		private bool ValidateData()
		{ bool blnValidate = false;

				// Comprueba los datos
					if (txtInstructions.Text.IsEmpty())
						Bau.Controls.Forms.Helper.ShowMessage(this, "Introduzca las instrucciones del proyecto");
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
				{ ScriptRestProcessor objProcessor = new ScriptRestProcessor();

						// Limpia la salida del log
							txtResult.Text = "";
						// Ejecuta el archivo
							objProcessor.Execute(txtInstructions.Text);
						// Muestra los errores o envía los datos
							if (objProcessor.Errors.Count > 0)
								ShowParseErrors(objProcessor.Errors);
							else
								{ // Log
										AddLog("Script interpretado correctamente");
									// Muestra el resultado de las instrucciones
										foreach (RestInstruction objInstruction in objProcessor.Program.Instructions)
											ShowResult(objInstruction);
									// Log
										AddLogSeparator(true);
								}
						// Muestra la ficha de resultados
							tabInstructions.SelectedIndex = 1;
				}
		}

		/// <summary>
		///		Muestra los erroes de interpretación
		/// </summary>
		private void ShowParseErrors(List<Libraries.LibScriptRest.Errors.SyntaxError> objColErrors)
		{ // Estado
				AddLog("Errores en la interpretación del texto");
			// Log
				for (int intIndex = 0; intIndex < objColErrors.Count;intIndex++)
					{ // Añade el log
							AddLog("Línea", objColErrors[intIndex].Line.ToString());
							AddLog("Instrucción", objColErrors[intIndex].Instruction);
							AddLog("Mensaje", objColErrors[intIndex].Message);
						// Añade la separación
							if (intIndex < objColErrors.Count - 1)
								AddLogSeparator(false);
					}
			// Final
				AddLogSeparator(true);
		}

		/// <summary>
		///		Muestra el resultado de una instrucción
		/// </summary>
		private void ShowResult(RestInstruction objInstruction)
		{ // Muestra la solicitud
				ShowRequest(objInstruction.Request);
				AddLogSeparator(false);
			// Muestra la respuesta
				if (objInstruction.Exception != null)
					AddLog("Excepción en la llamada", objInstruction.Exception.Message);
				else
					ShowResponse(objInstruction.Response);
			// Final
				AddLogSeparator(true);
		}

		/// <summary>
		///		Muestra la solicitud
		/// </summary>
		private void ShowRequest(RequestMessage objRequest)
		{ // Log
				AddLog("Solicitud");
			// Datos del mensaje
				ShowMessage(objRequest);
		}

		/// <summary>
		///		Muestra la respuesta de una instrucción
		/// </summary>
		private void ShowResponse(ResponseMessage objResponse)
		{	// Estado
				AddLog("Estado", (int) objResponse.Status + " -- " + objResponse.Status.ToString());
				AddLogSeparator(false);
			// Datos del mensaje
				ShowMessage(objResponse);
		}

		/// <summary>
		///		Muestra los datos de un mensaje
		/// </summary>
		private void ShowMessage(BaseMessage objMessage)
		{	// Cabeceras
				AddLog("Cabeceras:");
				foreach (Header objHeader in objMessage.Headers)
					AddLog(objHeader.Key, objHeader.Value);
				AddLogSeparator(false);
			// Cuerpo
				AddLog("Cuerpo:");
				AddLog(GetBody(objMessage.Body));
		}

		/// <summary>
		///		Añade una cadena al log
		/// </summary>
		private void AddLog(string strHeader, string strValue)
		{ AddLog(strHeader + ": " + strValue);
		}

		/// <summary>
		///		Añade un texto al log
		/// </summary>
		private void AddLog(string strText)
		{ txtResult.AppendText(strText + Environment.NewLine);
		}

		/// <summary>
		///		Añade un separador al log
		/// </summary>
		private void AddLogSeparator(bool blnEnd)
		{ if (blnEnd)
				{ AddLog(new string('=', 30));
					AddLog("");
				}
			else
				AddLog(new string('-', 30));
		}

		/// <summary>
		///		Obtiene un texto adecuado para añadirlo a un cuadro de texto
		/// </summary>
		private string GetBody(string strBody)
		{ string strResult = "";
		
				// Si hay algo en el cuerpo del mensaje
					if (!strBody.IsEmpty())
						{ // Asigna el cuerpo al resultado
								strResult = strBody.Replace("\r\n", Environment.NewLine);
							// Reemplaza el resto de los "caracteres extraños"
								strResult = strResult.Replace("\r", Environment.NewLine);
								strResult = strResult.Replace("\n", Environment.NewLine);
								strResult = strResult.Replace("\t", "     ");
						}
				// Devuelve el cuerpo resultante
					return strResult;
		}
		
		/// <summary>
		///		Abre un archivo REST
		/// </summary>
		private void OpenFileRest()
		{ string strFileName = Bau.Controls.Forms.Helper.GetFileNameOpen(cnstStrMaskFiles);

				// Abre el archivo de script
					OpenFileRest(strFileName);
		}

		/// <summary>
		///		Abre un archivo REST
		/// </summary>
		private void OpenFileRest(string strFileName)
		{ if (!strFileName.IsEmpty() && System.IO.File.Exists(strFileName))
				{ // Limpia los datos
						Clear();
					// Carga las instrucciones
						try
							{ // Carga las instrucciones
									txtInstructions.Text = Libraries.LibHelper.Files.HelperFiles.LoadTextFile(strFileName);
								// Graba el archivo en las propiedades
									SaveLastFile(strFileName);
								// Indica que no se ha modificado nada
									ShowDirty(false);
							}
						catch (Exception objException)
							{ Bau.Controls.Forms.Helper.ShowMessage(this, "Error al cargar el archivo: " + objException.Message);
							}
				}
		}

		/// <summary>
		///		Muestra un asterisco en la ficha cuando se cambian las instrucciones
		/// </summary>
		private void ShowDirty(bool blnIsDirty)
		{ if (blnIsDirty)
				{ if (!tabInstructions.TabPages[0].Text.EndsWith("*"))
						tabInstructions.TabPages[0].Text += " *";
				}
			else
				tabInstructions.TabPages[0].Text = "Instrucciones";
		}

		/// <summary>
		///		Graba un script de instrucciones
		/// </summary>
		private void Save()
		{ string strFileName = Bau.Controls.Forms.Helper.GetFileNameSave(cnstStrMaskFiles);

				if (!strFileName.IsEmpty())
					try
						{ // Graba las instrucciones
								Libraries.LibHelper.Files.HelperFiles.SaveTextFile(strFileName, txtInstructions.Text);
							// Indica que se ha grabado
								ShowDirty(false);
							// Cambia el último archivo
								SaveLastFile(strFileName);
						}
					catch (Exception objException)
						{ Bau.Controls.Forms.Helper.ShowMessage(this, "Error al grabar el archvo: " + objException.Message);
						}
		}

		/// <summary>
		///		Guarda el último archivo
		/// </summary>
		private void SaveLastFile(string strFileName)
		{	Properties.Settings.Default.LastFile = strFileName;
			Properties.Settings.Default.Save();
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
		{ if (tabInstructions.TabIndex == 0)
				Clear();
			else
				txtResult.Text = "";
		}

		private void txtInstructions_TextChanged(Object sender, EventArgs e)
		{ ShowDirty(true);
		}
	}
}