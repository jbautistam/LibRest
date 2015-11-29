namespace Bau.Applications.TestLibRest
{
	partial class frmMain
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdOpen = new System.Windows.Forms.ToolStripButton();
			this.cmdSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdClear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdSend = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkUseProxy = new System.Windows.Forms.CheckBox();
			this.nudProxyPort = new Bau.Controls.TextBox.NumericUpDowExtended();
			this.txtPasswordProxy = new System.Windows.Forms.TextBox();
			this.txtUserProxy = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtProxyIp = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lswInstructions = new Bau.Controls.List.ListUpdatable();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.udtAuthentication = new Bau.Applications.TestLibRest.UC.Authentication.ctlAuthentication();
			this.toolStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdOpen,
            this.cmdSave,
            this.toolStripSeparator1,
            this.cmdClear,
            this.toolStripSeparator2,
            this.cmdSend});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(754, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// cmdOpen
			// 
			this.cmdOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdOpen.Image = global::Bau.Applications.TestLibRest.Properties.Resources.folder;
			this.cmdOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdOpen.Name = "cmdOpen";
			this.cmdOpen.Size = new System.Drawing.Size(23, 22);
			this.cmdOpen.Text = "Abrir";
			this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
			// 
			// cmdSave
			// 
			this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdSave.Image = global::Bau.Applications.TestLibRest.Properties.Resources.disk;
			this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(23, 22);
			this.cmdSave.Text = "Grabar";
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// cmdClear
			// 
			this.cmdClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdClear.Image = global::Bau.Applications.TestLibRest.Properties.Resources.cancel;
			this.cmdClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Size = new System.Drawing.Size(23, 22);
			this.cmdClear.Text = "Limpiar";
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// cmdSend
			// 
			this.cmdSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdSend.Image = global::Bau.Applications.TestLibRest.Properties.Resources.world_go;
			this.cmdSend.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdSend.Name = "cmdSend";
			this.cmdSend.Size = new System.Drawing.Size(23, 22);
			this.cmdSend.Text = "Enviar";
			this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 616);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(754, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(6, 30);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(744, 579);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(736, 553);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Proyecto";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.chkUseProxy);
			this.groupBox2.Controls.Add(this.nudProxyPort);
			this.groupBox2.Controls.Add(this.txtPasswordProxy);
			this.groupBox2.Controls.Add(this.txtUserProxy);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtProxyIp);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.groupBox2.Location = new System.Drawing.Point(3, 289);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(726, 82);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// chkUseProxy
			// 
			this.chkUseProxy.AutoSize = true;
			this.chkUseProxy.BackColor = System.Drawing.SystemColors.Control;
			this.chkUseProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkUseProxy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chkUseProxy.Location = new System.Drawing.Point(10, -1);
			this.chkUseProxy.Name = "chkUseProxy";
			this.chkUseProxy.Size = new System.Drawing.Size(99, 17);
			this.chkUseProxy.TabIndex = 0;
			this.chkUseProxy.Text = "Utilizar proxy";
			this.chkUseProxy.UseVisualStyleBackColor = false;
			this.chkUseProxy.CheckedChanged += new System.EventHandler(this.chkUseProxy_CheckedChanged);
			// 
			// nudProxyPort
			// 
			this.nudProxyPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.nudProxyPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nudProxyPort.Location = new System.Drawing.Point(384, 20);
			this.nudProxyPort.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
			this.nudProxyPort.Name = "nudProxyPort";
			this.nudProxyPort.Size = new System.Drawing.Size(67, 20);
			this.nudProxyPort.TabIndex = 4;
			this.nudProxyPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtPasswordProxy
			// 
			this.txtPasswordProxy.BackColor = System.Drawing.Color.White;
			this.txtPasswordProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPasswordProxy.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txtPasswordProxy.Location = new System.Drawing.Point(384, 47);
			this.txtPasswordProxy.Name = "txtPasswordProxy";
			this.txtPasswordProxy.Size = new System.Drawing.Size(194, 20);
			this.txtPasswordProxy.TabIndex = 2;
			// 
			// txtUserProxy
			// 
			this.txtUserProxy.BackColor = System.Drawing.Color.White;
			this.txtUserProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserProxy.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txtUserProxy.Location = new System.Drawing.Point(83, 46);
			this.txtUserProxy.Name = "txtUserProxy";
			this.txtUserProxy.Size = new System.Drawing.Size(228, 20);
			this.txtUserProxy.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label2.Location = new System.Drawing.Point(317, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Contraseña:";
			// 
			// txtProxyIp
			// 
			this.txtProxyIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.txtProxyIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtProxyIp.ImeMode = System.Windows.Forms.ImeMode.On;
			this.txtProxyIp.Location = new System.Drawing.Point(83, 20);
			this.txtProxyIp.Name = "txtProxyIp";
			this.txtProxyIp.Size = new System.Drawing.Size(228, 20);
			this.txtProxyIp.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label1.Location = new System.Drawing.Point(16, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Usuario:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label5.Location = new System.Drawing.Point(317, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "Puerto:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label6.Location = new System.Drawing.Point(16, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Dirección:";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.udtAuthentication);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.groupBox3.Location = new System.Drawing.Point(3, 377);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(726, 166);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Autentificación";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lswInstructions);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.groupBox1.Location = new System.Drawing.Point(3, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(726, 276);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Instrucciones";
			// 
			// lswInstructions
			// 
			this.lswInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lswInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lswInstructions.ForeColor = System.Drawing.Color.Black;
			this.lswInstructions.Location = new System.Drawing.Point(3, 16);
			this.lswInstructions.MultiSelect = true;
			this.lswInstructions.Name = "lswInstructions";
			this.lswInstructions.ShowItemToolTips = false;
			this.lswInstructions.Size = new System.Drawing.Size(720, 257);
			this.lswInstructions.TabIndex = 0;
			this.lswInstructions.OnUpdateRecord += new Bau.Controls.List.ListUpdatable.UpdateRecordHandler(this.lswInstructions_OnUpdateRecord);
			this.lswInstructions.OnDeleteRecord += new Bau.Controls.List.ListUpdatable.DeleteRecordHandler(this.lswInstructions_OnDeleteRecord);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtResult);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(736, 553);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Resultados";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtResult
			// 
			this.txtResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtResult.Location = new System.Drawing.Point(3, 3);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ReadOnly = true;
			this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtResult.Size = new System.Drawing.Size(730, 547);
			this.txtResult.TabIndex = 0;
			// 
			// udtAuthentication
			// 
			this.udtAuthentication.Dock = System.Windows.Forms.DockStyle.Fill;
			this.udtAuthentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.udtAuthentication.ForeColor = System.Drawing.Color.Black;
			this.udtAuthentication.Location = new System.Drawing.Point(3, 16);
			this.udtAuthentication.Name = "udtAuthentication";
			this.udtAuthentication.Size = new System.Drawing.Size(720, 147);
			this.udtAuthentication.TabIndex = 0;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 638);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BauRest";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudProxyPort)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdOpen;
		private System.Windows.Forms.ToolStripButton cmdSave;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton cmdClear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton cmdSend;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox3;
		private UC.Authentication.ctlAuthentication udtAuthentication;
		private System.Windows.Forms.GroupBox groupBox1;
		private Controls.List.ListUpdatable lswInstructions;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkUseProxy;
		private Controls.TextBox.NumericUpDowExtended nudProxyPort;
		private System.Windows.Forms.TextBox txtProxyIp;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPasswordProxy;
		private System.Windows.Forms.TextBox txtUserProxy;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

