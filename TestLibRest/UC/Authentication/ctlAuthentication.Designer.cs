namespace Bau.Applications.TestLibRest.UC.Authentication
{
	partial class ctlAuthentication
	{
		/// <summary> 
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
		if(disposing && (components != null)) {
		components.Dispose();
		}
		base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar 
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.cboAuthentication = new Bau.Controls.Combos.ComboBoxExtended();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.udtAuthenticationPlain = new Bau.Applications.TestLibRest.UC.Authentication.ctlAuthenticationPlain();
			this.udtAuthenticationOAuth = new Bau.Applications.TestLibRest.UC.Authentication.ctlAuthenticationOAuth();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cboAuthentication
			// 
			this.cboAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAuthentication.FormattingEnabled = true;
			this.cboAuthentication.Location = new System.Drawing.Point(119, 4);
			this.cboAuthentication.Name = "cboAuthentication";
			this.cboAuthentication.SelectedID = null;
			this.cboAuthentication.Size = new System.Drawing.Size(434, 21);
			this.cboAuthentication.TabIndex = 0;
			this.cboAuthentication.SelectedIndexChanged += new System.EventHandler(this.cboAuthentication_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Autentificación:";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.udtAuthenticationPlain);
			this.panel1.Controls.Add(this.udtAuthenticationOAuth);
			this.panel1.Location = new System.Drawing.Point(0, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(565, 252);
			this.panel1.TabIndex = 2;
			// 
			// udtAuthenticationPlain
			// 
			this.udtAuthenticationPlain.Location = new System.Drawing.Point(11, 8);
			this.udtAuthenticationPlain.Name = "udtAuthenticationPlain";
			this.udtAuthenticationPlain.Size = new System.Drawing.Size(201, 90);
			this.udtAuthenticationPlain.TabIndex = 1;
			// 
			// udtAuthenticationOAuth
			// 
			this.udtAuthenticationOAuth.Location = new System.Drawing.Point(225, 3);
			this.udtAuthenticationOAuth.Name = "udtAuthenticationOAuth";
			this.udtAuthenticationOAuth.Size = new System.Drawing.Size(381, 122);
			this.udtAuthenticationOAuth.TabIndex = 0;
			// 
			// ctlAuthentication
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboAuthentication);
			this.Name = "ctlAuthentication";
			this.Size = new System.Drawing.Size(565, 282);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.Combos.ComboBoxExtended cboAuthentication;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private ctlAuthenticationPlain udtAuthenticationPlain;
		private ctlAuthenticationOAuth udtAuthenticationOAuth;
	}
}
