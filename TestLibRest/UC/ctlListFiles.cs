using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Libraries.LibRest.Messages.Parameters;
namespace Bau.Applications.TestLibRest.UC 
{
	/// <summary>
	///		Lista de parámetros
	/// </summary>
	public partial class ctlListFiles : UserControl 
	{ // Eventos públicos
			public EventHandler Changed;

		public ctlListFiles() 
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el control
		/// </summary>
		public void InitControl()
		{ // Limpia la lista
				lswParameters.Clear();
			// Añade las columnas
				lswParameters.AddColumn(Width - 20, "Archivo");
		}

		/// <summary>
		///		Carga los parámetros
		/// </summary>
		public void LoadParameters(AttachmentsCollection objColAttachments)
		{ // Inicializa el control
				InitControl();
			// Carga los parámetros
				foreach (Attachment objAttachment in objColAttachments)
					AddFile(objAttachment.FileName);
		}

		/// <summary>
		///		Añade un parámetro a la lista
		/// </summary>
		private void AddFile(string strFile)
		{ lswParameters.AddRecord(strFile, strFile);
		}

		/// <summary>
		///		Obtiene los archivos de la lista
		/// </summary>
		public AttachmentsCollection GetParameters()
		{ AttachmentsCollection objColFiles = new AttachmentsCollection();

				// Obtiene los parámetros
					foreach (ListViewItem lsiItem in lswParameters.Items)
						objColFiles.Add(lsiItem.Text);
				// Devuelve la colección de archivos
					return objColFiles;
		}

		/// <summary>
		///		Abre el formulario de parámetros
		/// </summary>
		private void OpenFormParameters(string strKey)
		{ ListViewItem lsiItem = Search(strKey);
			string strFileName = Bau.Controls.Forms.Helper.GetFileNameOpen("Todos los archivos (*.*)|*.*");

				// Asigna el resultado
					if (!string.IsNullOrEmpty(strFileName))
						{ // Añade el resultado a la lista
								if (lsiItem == null)
									AddFile(strFileName);
								else
									lsiItem.Text = strFileName;
							// Lanza el evento de modificación
								RaiseEventChanged();
						}
		}

		/// <summary>
		///		Obtiene un elemento de la lista
		/// </summary>
		private ListViewItem Search(string strKey)
		{ // Busca un elemento de la lista
				foreach (ListViewItem lsiItem in lswParameters.Items)
					if (lsiItem.Text == strKey)
						return lsiItem;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}

		/// <summary>
		///		Borra los parámetros seleccionados
		/// </summary>
		private void DeleteParameters()
		{ if (lswParameters.SelectedItems != null && lswParameters.SelectedItems.Count > 0 &&
					Bau.Controls.Forms.Helper.ShowQuestion(ParentForm, "¿Desea borrar estos elementos?"))
				{ // Borra los elementos
						foreach (ListViewItem lsiItem in lswParameters.SelectedItems)
							lswParameters.Items.Remove(lsiItem);
					// Lanza el evento de modificación
						RaiseEventChanged();
				}
		}

		/// <summary>
		///		Lanza el evento de modificación
		/// </summary>
		private void RaiseEventChanged()
		{ if (Changed != null)
				Changed(this, EventArgs.Empty);
		}

		private void lswParameters_OnUpdateRecord(object objSender, string strKey)
		{ OpenFormParameters(strKey);
		}

		private void lswParameters_OnDeleteRecord(object objSender, string strKey)
		{ DeleteParameters();
		}
	}
}