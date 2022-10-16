using System;
using System.Windows.Forms;

namespace LibraryApp
{
	public partial class ChooseFileLocation : Form
	{
		public string ReturnValue { get; set; }

		public ChooseFileLocation()
		{
			InitializeComponent();
		}

		private void btnFile_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog diag = new FolderBrowserDialog();
			if (diag.ShowDialog() == DialogResult.OK)
			{
				tbFileLocation.Text = diag.SelectedPath;
			}
			else
			{ 
				tbFileLocation.Text = "You didn't select the folder!"; 
			}
		}

		private void btnFolder_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select File";
			openFileDialog.InitialDirectory = @"C:\";//--"C:\\";
			openFileDialog.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";
			openFileDialog.FilterIndex = 2;
			openFileDialog.ShowDialog();
			if (openFileDialog.FileName != "")
			{ 
				tbFileLocation.Text = openFileDialog.FileName; 
			}
			else
			{
				tbFileLocation.Text = "You didn't select the file!"; 
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			ReturnValue = tbFileLocation.Text;
			Close();
		}
	}
}
