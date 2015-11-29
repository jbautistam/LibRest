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
	public partial class ctlListParameters : UserControl 
	{ // Eventos públicos
			public EventHandler Changed;

		public ctlListParameters() 
		{ InitializeComponent();
		}

		/// <summary>
		///		Inicializa el control
		/// </summary>
		public void InitControl()
		{ // Limpia la lista
				lswParameters.Clear();
			// Añade las columnas
				lswParameters.AddColumn(150, "Nombre");
				lswParameters.AddColumn(Width - 170, "Valor");
		}

		/// <summary>
		///		Carga los parámetros
		/// </summary>
		public void LoadParameters(ParameterDataCollection objColParameters)
		{ // Inicializa el control
				InitControl();
			// Carga los parámetros
				foreach (ParameterData objParameter in objColParameters)
					AddParameter(objParameter);
		}

		/// <summary>
		///		Añade un parámetro a la lista
		/// </summary>
		private void AddParameter(ParameterData objParameter)
		{ ListViewItem lsiItem = lswParameters.AddRecord(objParameter.Key, objParameter.Key);

				lsiItem.SubItems.Add(objParameter.Value);
		}

		/// <summary>
		///		Obtiene los parámetros de la lista
		/// </summary>
		public Dictionary<string, string> GetParameters()
		{ Dictionary<string, string> objColParameters = new Dictionary<string, string>();

				// Obtiene los parámetros
					foreach (ListViewItem lsiItem in lswParameters.Items)
						objColParameters.Add(lsiItem.Text, lsiItem.SubItems[1].Text);
				// Devuelve la colección de parámetros
					return objColParameters;
		}

		/// <summary>
		///		Abre el formulario de parámetros
		/// </summary>
		private void OpenFormParameters(string strKey)
		{ ListViewItem lsiItem = Search(strKey);
			frmParameter frmNewParameter = new frmParameter();

				// Asigna los datos del parámetro
					if (lsiItem == null)
						frmNewParameter.Parameter = new KeyValuePair<string,string>();
					else
						frmNewParameter.Parameter = new KeyValuePair<string,string>(lsiItem.Text, lsiItem.SubItems[1].Text);
				// Abre el formulario
					frmNewParameter.ShowDialog();
				// Asigna el resultado
					if (frmNewParameter.DialogResult == DialogResult.OK)
						{ // Añade el resultado a la lista
								if (lsiItem == null)
									AddParameter(new ParameterData(frmNewParameter.Parameter.Key, frmNewParameter.Parameter.Value));
								else
									{ lsiItem.Text = frmNewParameter.Parameter.Key;
										lsiItem.SubItems[1].Text = frmNewParameter.Parameter.Value;
									}
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
