using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FFGUI.Properties;

namespace FFGUI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			string ffmpeg = ConfigurationManager.AppSettings["FFMPEG_PATH"];
			if(!File.Exists(ffmpeg))
			{
				Debug.WriteLine("No FFMpeg found, prompting user");
				MessageBox.Show(this, Resources.Form1_Form1_This_application_uses_FFMPEG_for_it_s_conversion__Please_select_where_ffmpeg_exe_can_be_found, Resources.Form1_Form1_Missing_FFMPEG, MessageBoxButtons.OK, MessageBoxIcon.Error);
				OpenFileDialog dialog = new OpenFileDialog();
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					ffmpeg = dialog.FileName;
					ConfigurationManager.AppSettings["FFMPEG_PATH"] = ffmpeg;
				}
				else
				{
					MessageBox.Show(this, "Without FFMPEG this application is useless, closing down", Resources.Form1_Form1_Missing_FFMPEG, MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
			}
			Debug.WriteLine(String.Format("Using ffmpeg at: \"{0}\"", ffmpeg));
			
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
			string advancedOptions = "-s 1920x1080 -r 60 -b 1024k -ar 48000 -ab 320k -ac 2 -qscale 4";
			string commandLine = String.Format("-i \"{0}\" {2} \"{1}\"", inputFileName.Text, outputFileName.Text, advancedOptions);
			Debug.WriteLine(commandLine);

			string ffmpeg = ConfigurationManager.AppSettings["FFMPEG_PATH"];

			Process p = Process.Start(ffmpeg, commandLine);
			p.Exited += (o, args) =>
				            {
					            Debug.WriteLine("Conversion done");						
				            };
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
