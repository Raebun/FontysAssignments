namespace LibraryApp
{
	partial class ChooseFileLocation
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.tbFileLocation = new System.Windows.Forms.TextBox();
			this.btnFile = new System.Windows.Forms.Button();
			this.btnFolder = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(38, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose file location";
			// 
			// tbFileLocation
			// 
			this.tbFileLocation.Enabled = false;
			this.tbFileLocation.Location = new System.Drawing.Point(41, 56);
			this.tbFileLocation.Name = "tbFileLocation";
			this.tbFileLocation.Size = new System.Drawing.Size(386, 20);
			this.tbFileLocation.TabIndex = 1;
			// 
			// btnFile
			// 
			this.btnFile.Location = new System.Drawing.Point(41, 92);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(75, 23);
			this.btnFile.TabIndex = 2;
			this.btnFile.Text = "File";
			this.btnFile.UseVisualStyleBackColor = true;
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// btnFolder
			// 
			this.btnFolder.Location = new System.Drawing.Point(122, 92);
			this.btnFolder.Name = "btnFolder";
			this.btnFolder.Size = new System.Drawing.Size(75, 23);
			this.btnFolder.TabIndex = 3;
			this.btnFolder.Text = "Folder";
			this.btnFolder.UseVisualStyleBackColor = true;
			this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(352, 92);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// ChooseFileLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 137);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnFolder);
			this.Controls.Add(this.btnFile);
			this.Controls.Add(this.tbFileLocation);
			this.Controls.Add(this.label1);
			this.Name = "ChooseFileLocation";
			this.Text = "ChooseFileLocation";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox tbFileLocation;
		private System.Windows.Forms.Button btnFile;
		private System.Windows.Forms.Button btnFolder;
		private System.Windows.Forms.Button btnSave;
	}
}