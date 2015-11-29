namespace Bau.Applications.TestLibRest.UC {
	partial class ctlListFiles {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
		if(disposing && (components != null)) {
		components.Dispose();
		}
		base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.lswParameters = new Bau.Controls.List.ListUpdatable();
			this.SuspendLayout();
			// 
			// lswParameters
			// 
			this.lswParameters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lswParameters.Location = new System.Drawing.Point(0, 0);
			this.lswParameters.MultiSelect = true;
			this.lswParameters.Name = "lswParameters";
			this.lswParameters.ShowItemToolTips = false;
			this.lswParameters.Size = new System.Drawing.Size(324, 350);
			this.lswParameters.TabIndex = 0;
			this.lswParameters.OnUpdateRecord += new Bau.Controls.List.ListUpdatable.UpdateRecordHandler(this.lswParameters_OnUpdateRecord);
			this.lswParameters.OnDeleteRecord += new Bau.Controls.List.ListUpdatable.DeleteRecordHandler(this.lswParameters_OnDeleteRecord);
			// 
			// ctlListParameters
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lswParameters);
			this.Name = "ctlListParameters";
			this.Size = new System.Drawing.Size(324, 350);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.List.ListUpdatable lswParameters;
	}
}
