namespace Bau.Applications.ScriptLibRest
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdOpen = new System.Windows.Forms.ToolStripButton();
			this.cmdSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdClear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdSend = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tabInstructions = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtInstructions = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.toolStrip1.SuspendLayout();
			this.tabInstructions.SuspendLayout();
			this.tabPage1.SuspendLayout();
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
			this.toolStrip1.Size = new System.Drawing.Size(681, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// cmdOpen
			// 
			this.cmdOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdOpen.Image = global::Bau.Applications.ScriptLibRest.Properties.Resources.folder;
			this.cmdOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdOpen.Name = "cmdOpen";
			this.cmdOpen.Size = new System.Drawing.Size(23, 22);
			this.cmdOpen.Text = "Abrir";
			this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
			// 
			// cmdSave
			// 
			this.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdSave.Image = global::Bau.Applications.ScriptLibRest.Properties.Resources.disk;
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
			this.cmdClear.Image = global::Bau.Applications.ScriptLibRest.Properties.Resources.cancel;
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
			this.cmdSend.Image = global::Bau.Applications.ScriptLibRest.Properties.Resources.world_go;
			this.cmdSend.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdSend.Name = "cmdSend";
			this.cmdSend.Size = new System.Drawing.Size(23, 22);
			this.cmdSend.Text = "Enviar";
			this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 607);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(681, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tabInstructions
			// 
			this.tabInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabInstructions.Controls.Add(this.tabPage1);
			this.tabInstructions.Controls.Add(this.tabPage2);
			this.tabInstructions.Location = new System.Drawing.Point(6, 30);
			this.tabInstructions.Name = "tabInstructions";
			this.tabInstructions.SelectedIndex = 0;
			this.tabInstructions.Size = new System.Drawing.Size(671, 570);
			this.tabInstructions.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtInstructions);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(663, 544);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Proyecto";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtInstructions
			// 
			this.txtInstructions.AcceptsReturn = true;
			this.txtInstructions.AcceptsTab = true;
			this.txtInstructions.BackColor = System.Drawing.Color.White;
			this.txtInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInstructions.Location = new System.Drawing.Point(3, 3);
			this.txtInstructions.Multiline = true;
			this.txtInstructions.Name = "txtInstructions";
			this.txtInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtInstructions.Size = new System.Drawing.Size(657, 538);
			this.txtInstructions.TabIndex = 1;
			this.txtInstructions.TextChanged += new System.EventHandler(this.txtInstructions_TextChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtResult);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(663, 544);
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
			this.txtResult.Size = new System.Drawing.Size(657, 538);
			this.txtResult.TabIndex = 0;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 629);
			this.Controls.Add(this.tabInstructions);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ScriptBauRest";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabInstructions.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
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
		private System.Windows.Forms.TabControl tabInstructions;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.TextBox txtInstructions;
	}
}

