using FFGUI.Properties;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
			Debug.WriteLine(String.Format("Using ffmpeg at: \"{0}\"", ffmpeg));
            
            saveFileDialog1.Filter = Resources.FileFormats;
            saveFileDialog1.DefaultExt = "mp4";

		    foreach (var preset in EncodingOptions.Presets)
		    {
		        presets.Items.Add(preset.PresetName);
		    }
		    presets.SelectedIndex = 1;
		    //SetEncodingOptions(EncodingOptions.Custom720);
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
			var advancedOptions = GetEncodingOptions();
			FFWrapper.StartConversion(inputFileName.Text, outputFileName.Text, advancedOptions);
		}

		private void OnBrowseInputFile(object sender, EventArgs e)
		{
		    var result = openFileDialog1.ShowDialog(this);
			if(result == DialogResult.OK)
			{
				inputFileName.Text = openFileDialog1.FileName;
			}
		}

		private void OnBrowseOutputFile(object sender, EventArgs e)
		{            
            var result = saveFileDialog1.ShowDialog(this);
			if(result == DialogResult.OK)
			{
				outputFileName.Text = saveFileDialog1.FileName;
			}
		}

		private EncodingOptions GetEncodingOptions()
		{
		    var res = "";
		    var p = videoResolution.Text.Split('x');
            if (p.Length > 1)
            {
                uint a, b;
                if (UInt32.TryParse(p[0], out a) && UInt32.TryParse(p[1], out b))
                {
                    res = a + "x" + b;
                }
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
				AudioChannels = audioChannels.Text
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
		}

        private void OnSelectPreset(object sender, EventArgs e)
        {
            SetEncodingOptions(EncodingOptions.Presets[presets.SelectedIndex]);
        }
	}
}
