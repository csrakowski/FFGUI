using FFGUI.Properties;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using FFMPEG_CSWrapper;
using System.Threading.Tasks;
using Logger;

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
                SimpleLogger.LogMessage("No FFMpeg found, prompting user");
				MessageBox.Show(this, Resources.Form1_Form1_This_application_uses_FFMPEG_for_it_s_conversion__Please_select_where_ffmpeg_exe_can_be_found, Resources.Form1_Form1_Missing_FFMPEG, MessageBoxButtons.OK, MessageBoxIcon.Error);
				var dialog = new OpenFileDialog();
				var result = dialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					ffmpeg = dialog.FileName;
					ConfigurationManager.AppSettings["FFMPEG_PATH"] = ffmpeg;
					MessageBox.Show(this, String.Format("To make this change permanent please write the following text in the .config file at the \"FFMPEG_PATH\" key:\n{0}", ffmpeg));
				}
				else
				{
					MessageBox.Show(this, Resources.Form1_Form1_Without_FFMPEG_this_application_is_useless__closing_down, Resources.Form1_Form1_Missing_FFMPEG, MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
				}
			}
            SimpleLogger.LogMessage(String.Format("Using ffmpeg at: \"{0}\"", ffmpeg));

            saveFileDialog1.Filter = Resources.FileFormats;
            saveFileDialog1.DefaultExt = "MP4";

            conversionFormats.Items.AddRange(new[] {
                "MP4",
                "MP3",
                "MPEG",
                "AVI",
                "FLV"
            });
            conversionFormats.SelectedIndex = 0;

		    foreach (var preset in EncodingOptions.Presets)
		    {
		        presets.Items.Add(preset.PresetName);
		    }
		    presets.SelectedIndex = 1;
		    //SetEncodingOptions(EncodingOptions.Custom720);
		}

		private async void OnStartConversion(object sender, EventArgs e)
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
			var advancedOptions = GetEncodingOptions();
            if (advancedOptions == null)
            {
                return;
            }
            try
            {
                toolStripStatusLabel1.Text = "Converting...";
                toolStripProgressBar1.Visible = true;

                bool success = false;
                if (checkBoxBatchMode.Checked)
                {
                    string outputFormat = conversionFormats.SelectedItem.ToString();
                    success = await FFWrapper.StartBatchConversion(inputFileName.Text, outputFileName.Text, outputFormat, advancedOptions);
                }
                else
                {
                    success = await FFWrapper.StartConversion(inputFileName.Text, outputFileName.Text, advancedOptions);
                }
                var messageBoxMessage = String.Format("The conversion completed successfully. The result is saved at: \"{0}\".", outputFileName.Text);
                var toolStripMessage = "Ready";
                if (!success)
                {
                    toolStripMessage = "Conversion Failed";
                    if (checkBoxBatchMode.Checked)
                    {
                        messageBoxMessage = "Not all files could be converted succesfully. Please review the log and try again.";
                    }
                    else
                    {
                        messageBoxMessage = "Something went wrong during conversion. Please try again.";
                    }
                }
                toolStripStatusLabel1.Text = toolStripMessage;
                toolStripProgressBar1.Visible = false;
                MessageBox.Show(this, messageBoxMessage, "Conversion Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}
        
		private void OnBrowseInputFile(object sender, EventArgs e)
		{
            if (checkBoxBatchMode.Checked)
            {
                folderBrowserDialog1.SelectedPath = inputFileName.Text;
                var result = folderBrowserDialog1.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var fileName = folderBrowserDialog1.SelectedPath;
                    inputFileName.Text = fileName;
                    outputFileName.Text = fileName + " output";
                }
            }
            else
            {
                openFileDialog1.FileName = inputFileName.Text;
                var result = openFileDialog1.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var fileName = openFileDialog1.FileName;
                    inputFileName.Text = fileName;
                    fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
                    outputFileName.Text = fileName + ".mp4";
                }
            }
		}

		private void OnBrowseOutputFile(object sender, EventArgs e)
		{
            if (checkBoxBatchMode.Checked)
            {
                folderBrowserDialog1.SelectedPath = outputFileName.Text;
                var result = folderBrowserDialog1.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    outputFileName.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            else
            {
                saveFileDialog1.FileName = outputFileName.Text;
                var result = saveFileDialog1.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    outputFileName.Text = saveFileDialog1.FileName;
                }
            }
		}

		private EncodingOptions GetEncodingOptions()
		{
		    var res = String.Empty;
            var resText = videoResolution.Text;
		    var p = resText.Split('x');
            if (p.Length > 1)
            {
                uint a, b;
                if (UInt32.TryParse(p[0], out a) && UInt32.TryParse(p[1], out b))
                {
                    res = a + "x" + b;
                }
            }
            if ((!String.IsNullOrEmpty(resText)) && String.IsNullOrEmpty(res))
            {
                MessageBox.Show(this, String.Format("\"{0}\" is an invalid resolution. Please enter one in the format of \"1920x1080\" or leave the field blank", resText), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
			var options = new EncodingOptions
			{
				IncludeVideo =includeVideo.Checked,
				VideoResolution = res,
				VideoFramerate = videoFramerate.Text,
				VideoBitrate = videoBitrate.Text,
				VideoScaleQuality = videoScaleQuality.Text,

				IncludeAudio = includeAudio.Checked,
				AudioSampleRate = audioSamplerate.Text,
				AudioBitrate = audioBitrate.Text,
				AudioChannels = audioChannels.Text,
                AudioScaleQuality = audioScaleQuality.Text,
			};

			return options;
		}

		private void SetEncodingOptions(EncodingOptions options)
		{
			includeVideo.Checked = options.IncludeVideo;
			videoResolution.Text = options.VideoResolution;
			videoFramerate.Text = options.VideoFramerate;
			videoBitrate.Text = options.VideoBitrate;
			videoScaleQuality.Text = options.VideoScaleQuality;

			includeAudio.Checked = options.IncludeAudio;
			audioSamplerate.Text = options.AudioSampleRate;
			audioBitrate.Text = options.AudioBitrate;
            audioChannels.Text = options.AudioChannels;
            audioScaleQuality.Text = options.AudioScaleQuality;
		}

        private void OnSelectPreset(object sender, EventArgs e)
        {
            SetEncodingOptions(EncodingOptions.Presets[presets.SelectedIndex]);
        }

        private void OnChangeBatchMode(object sender, EventArgs e)
        {
            conversionFormats.Visible = checkBoxBatchMode.Checked;
        }
	}
}
