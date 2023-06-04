using FFGUI.FFMPEGWrapper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FFGUI.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFFWrapper ffwraper;

        protected OpenFileDialog openFileDialog1;
        protected SaveFileDialog saveFileDialog1;
        protected Ookii.Dialogs.Wpf.VistaFolderBrowserDialog folderBrowserDialog1;

        public MainWindow()
        {
            InitializeComponent();

            if (!initialize())
            {
                App.Current.Shutdown();
            }
        }

        private bool initialize()
        {
            var ffmpeg = ConfigurationManager.AppSettings["FFMPEG_PATH"];
            if (!File.Exists(ffmpeg))
            {
                MessageBox.Show(this, MyResources.Form1_Form1_This_application_uses_FFMPEG_for_it_s_conversion__Please_select_where_ffmpeg_exe_can_be_found, MyResources.Form1_Form1_Missing_FFMPEG, MessageBoxButton.OK, MessageBoxImage.Error);
                var dialog = new OpenFileDialog();
                var result = dialog.ShowDialog(Owner);
                if (result == true)
                {
                    ffmpeg = dialog.FileName;
                    ConfigurationManager.AppSettings["FFMPEG_PATH"] = ffmpeg;
                    MessageBox.Show(this, $"To make this change permanent please write the following text in the .config file at the \"FFMPEG_PATH\" key:\n{ffmpeg}");
                }
                else
                {
                    MessageBox.Show(this, MyResources.Form1_Form1_Without_FFMPEG_this_application_is_useless__closing_down, MyResources.Form1_Form1_Missing_FFMPEG, MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            ffwraper = new FFWrapper(ffmpeg);
            ffwraper.OnProgressChanged += Ffwraper_OnProgressChanged;
            ffwraper.OnCompleted += Ffwraper_OnCompleted;

            openFileDialog1 = new OpenFileDialog();

            saveFileDialog1 = new SaveFileDialog
            {
                Filter = MyResources.FileFormats,
                DefaultExt = "MP4"
            };

            conversionFormats.Items.Add("MP4");
            conversionFormats.Items.Add("MP3");
            conversionFormats.Items.Add("MPEG");
            conversionFormats.Items.Add("AVI");
            conversionFormats.Items.Add("FLV");

            conversionFormats.SelectedIndex = 0;

            foreach (var preset in EncodingOptions.Presets)
            {
                presets.Items.Add(preset.PresetName);
            }
            presets.SelectedIndex = 1;
            //SetEncodingOptions(EncodingOptions.Custom720);
            return true;
        }

        private async void OnStartConversionAsync(object sender, RoutedEventArgs e)
        {
            var inputFile = inputFileName.Text;
            if (string.IsNullOrEmpty(inputFile))
            {
                MessageBox.Show(this, MyResources.Form1_onStartConversion_No_input_file_selected, MyResources.Form1_onStartConversion_Invalid_input_file, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var outputFile = outputFileName.Text;
            if (string.IsNullOrEmpty(outputFile))
            {
                MessageBox.Show(this, MyResources.Form1_onStartConversion_No_output_file_selected, MyResources.Form1_onStartConversion_Invalid_output_file, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var advancedOptions = GetEncodingOptions();
            if (advancedOptions == null)
            {
                return;
            }
            try
            {
                setToolStripText("Convertion stating...");
                toolStripProgressBar1.Visibility = Visibility.Visible;

                bool success = false;
                if (checkBoxBatchMode.IsChecked == true)
                {
                    string outputFormat = conversionFormats.SelectedItem.ToString();
                    success = await ffwraper.StartBatchConversionAsync(inputFile, outputFile, outputFormat, advancedOptions);
                }
                else
                {
                    success = await ffwraper.StartConversionAsync(inputFile, outputFile, advancedOptions);
                }
                var messageBoxMessage = $"The conversion completed successfully. The result is saved at: \"{outputFile}\".";
                var toolStripMessage = "Ready";
                if (!success)
                {
                    toolStripMessage = "Conversion Failed";
                    if (checkBoxBatchMode.IsChecked == true)
                    {
                        messageBoxMessage = "Not all files could be converted succesfully. Please review the log and try again.";
                    }
                    else
                    {
                        messageBoxMessage = "Something went wrong during conversion. Please try again.";
                    }
                }
                setToolStripText(toolStripMessage);
                toolStripProgressBar1.Visibility = Visibility.Hidden;
                MessageBox.Show(this, messageBoxMessage, "Conversion Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void setToolStripText(string text)
        {
            toolStripStatusLabel1.Content = text;
        }

        private void Ffwraper_OnCompleted()
        {
            setToolStripText("Conversion completed");
        }

        private void Ffwraper_OnProgressChanged(int currentFileIndex, string currentFileName, int totalFiles, float percentage)
        {
            setToolStripText($"Converting \"{currentFileName}\" - file {currentFileIndex} of {totalFiles} ({percentage}%)");
        }

        private void OnBrowseInputFile(object sender, RoutedEventArgs e)
        {
            if (checkBoxBatchMode.IsChecked == true)
            {
                folderBrowserDialog1.SelectedPath = inputFileName.Text;
                var result = folderBrowserDialog1.ShowDialog(this);
                if (result == true)
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
                if (result == true)
                {
                    var fileName = openFileDialog1.FileName;
                    inputFileName.Text = fileName;
                    fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
                    outputFileName.Text = fileName + ".mp4";
                }
            }
        }

        private void OnBrowseOutputFile(object sender, RoutedEventArgs e)
        {
            if (checkBoxBatchMode.IsChecked == true)
            {
                folderBrowserDialog1.SelectedPath = outputFileName.Text;
                var result = folderBrowserDialog1.ShowDialog(this);
                if (result == true)
                {
                    outputFileName.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            else
            {
                saveFileDialog1.FileName = outputFileName.Text;
                var result = saveFileDialog1.ShowDialog(this);
                if (result == true)
                {
                    outputFileName.Text = saveFileDialog1.FileName;
                }
            }
        }

        private EncodingOptions? GetEncodingOptions()
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
                MessageBox.Show(this, $"\"{resText}\" is an invalid resolution. Please enter one in the format of \"1920x1080\" or leave the field blank", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            var options = new EncodingOptions
            {
                IncludeVideo = includeVideo.IsChecked == true,
                VideoResolution = res,
                VideoFramerate = videoFramerate.Text,
                VideoBitrate = videoBitrate.Text,
                VideoScaleQuality = videoScaleQuality.Text,

                IncludeAudio = includeAudio.IsChecked == true,
                AudioSampleRate = audioSamplerate.Text,
                AudioBitrate = audioBitrate.Text,
                AudioChannels = audioChannels.Text,
                AudioScaleQuality = audioScaleQuality.Text,
                ApplyAudioNormalizationFilter = applyAudioNormalizationFilter.IsChecked == true,
            };

            return options;
        }

        private void SetEncodingOptions(EncodingOptions options)
        {
            includeVideo.IsChecked = options.IncludeVideo;
            videoResolution.Text = options.VideoResolution;
            videoFramerate.Text = options.VideoFramerate;
            videoBitrate.Text = options.VideoBitrate;
            videoScaleQuality.Text = options.VideoScaleQuality;

            includeAudio.IsChecked = options.IncludeAudio;
            audioSamplerate.Text = options.AudioSampleRate;
            audioBitrate.Text = options.AudioBitrate;
            audioChannels.Text = options.AudioChannels;
            audioScaleQuality.Text = options.AudioScaleQuality;
            applyAudioNormalizationFilter.IsChecked = options.ApplyAudioNormalizationFilter;
        }

        private void OnSelectPreset(object sender, RoutedEventArgs e)
        {
            SetEncodingOptions(EncodingOptions.Presets[presets.SelectedIndex]);
        }

        private void OnChangeBatchMode(object sender, RoutedEventArgs e)
        {
            conversionFormats.Visibility = (checkBoxBatchMode.IsChecked == true)
                                                ? Visibility.Visible
                                                : Visibility.Hidden;
        }
    }

    internal static class MyResources
    {
        public const string FileFormats = "MP4|*.mp4|MP3|*.mp3|AVI|*.avi|MPEG|*.mpg|Flash|*.flv|All Files|*.*";
        public const string Form1_Form1_Missing_FFMPEG = "Missing FFMPEG";
        public const string Form1_Form1_This_application_uses_FFMPEG_for_it_s_conversion__Please_select_where_ffmpeg_exe_can_be_found = "This application uses FFMPEG for it's conversion. Please select where ffmpeg.exe can be found";
        public const string Form1_Form1_Without_FFMPEG_this_application_is_useless__closing_down = "Without FFMPEG this application is useless, closing down";
        public const string Form1_onStartConversion_Invalid_input_file = "Invalid input file";
        public const string Form1_onStartConversion_Invalid_output_file = "Invalid output file";
        public const string Form1_onStartConversion_No_input_file_selected = "No input file selected";
        public const string Form1_onStartConversion_No_output_file_selected = "No output file selected";
    }
}
