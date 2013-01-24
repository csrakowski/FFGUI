using System;
using System.Diagnostics;
using System.Windows.Forms;
using FFGUI.Properties;

namespace FFGUI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void OnStartConversion(object sender, EventArgs e)
		{
			if(String.IsNullOrEmpty(inputFileName.Text))
			{
				MessageBox.Show(this, Resources.Form1_onStartConversion_No_input_file_selected, Resources.Form1_onStartConversion_Invalid_input_file, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (String.IsNullOrEmpty(outputFileName.Text))
			{
				MessageBox.Show(this, Resources.Form1_onStartConversion_No_output_file_selected, Resources.Form1_onStartConversion_Invalid_output_file, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Debug.WriteLine(string.Format("Starting Conversion: \"{0}\" --> \"{1}\"", inputFileName.Text, outputFileName.Text));
		}

		private void OnBrowseInputFile(object sender, EventArgs e)
		{
			DialogResult result = openFileDialog1.ShowDialog();
			if(result == DialogResult.OK)
			{
				inputFileName.Text = openFileDialog1.FileName;
			}
		}

		private void OnBrowseOutputFile(object sender, EventArgs e)
		{
			DialogResult result = saveFileDialog1.ShowDialog();
			if(result == DialogResult.OK)
			{
				outputFileName.Text = saveFileDialog1.FileName;
			}
		}
	}
}
