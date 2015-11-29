namespace Bau.Applications.TestLibRest.UC.Authentication
{
	partial class ctlAuthenticationOAuth
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
			this.txtConsumerSecret = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtConsumerKey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtOAuthToken = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtOAuthTokenSecret = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtConsumerSecret
			// 
			this.txtConsumerSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConsumerSecret.Location = new System.Drawing.Point(112, 33);
			this.txtConsumerSecret.Name = "txtConsumerSecret";
			this.txtConsumerSecret.Size = new System.Drawing.Size(472, 20);
			this.txtConsumerSecret.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label2.Location = new System.Drawing.Point(6, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Consumer secret:";
			// 
			// txtConsumerKey
			// 
			this.txtConsumerKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConsumerKey.Location = new System.Drawing.Point(112, 7);
			this.txtConsumerKey.Name = "txtConsumerKey";
			this.txtConsumerKey.Size = new System.Drawing.Size(472, 20);
			this.txtConsumerKey.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label1.Location = new System.Drawing.Point(6, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Consumer key:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label3.Location = new System.Drawing.Point(6, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "oAuth token:";
			// 
			// txtOAuthToken
			// 
			this.txtOAuthToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOAuthToken.Location = new System.Drawing.Point(112, 59);
			this.txtOAuthToken.Name = "txtOAuthToken";
			this.txtOAuthToken.Size = new System.Drawing.Size(472, 20);
			this.txtOAuthToken.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label4.Location = new System.Drawing.Point(6, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "oAuth token secret:";
			// 
			// txtOAuthTokenSecret
			// 
			this.txtOAuthTokenSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOAuthTokenSecret.Location = new System.Drawing.Point(112, 85);
			this.txtOAuthTokenSecret.Name = "txtOAuthTokenSecret";
			this.txtOAuthTokenSecret.Size = new System.Drawing.Size(472, 20);
			this.txtOAuthTokenSecret.TabIndex = 7;
			// 
			// ctlAuthenticationOAuth
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtOAuthTokenSecret);
			this.Controls.Add(this.txtConsumerSecret);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtOAuthToken);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtConsumerKey);
			this.Controls.Add(this.label1);
			this.Name = "ctlAuthenticationOAuth";
			this.Size = new System.Drawing.Size(587, 285);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtConsumerSecret;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtConsumerKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtOAuthToken;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtOAuthTokenSecret;
	}
}
