namespace FFGUI
{
	partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.startConversionButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.browseInputButton = new System.Windows.Forms.Button();
            this.inputFileName = new System.Windows.Forms.TextBox();
            this.outputFileName = new System.Windows.Forms.TextBox();
            this.browseOutputButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.videoResolution = new System.Windows.Forms.MaskedTextBox();
            this.videoBitrate = new System.Windows.Forms.TextBox();
            this.videoFramerate = new System.Windows.Forms.TextBox();
            this.videoScaleQuality = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.includeVideo = new System.Windows.Forms.CheckBox();
            this.includeAudio = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.audioChannels = new System.Windows.Forms.ComboBox();
            this.audioSamplerate = new System.Windows.Forms.TextBox();
            this.audioBitrate = new System.Windows.Forms.TextBox();
            this.encodingOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.encodingOptionsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.presets = new System.Windows.Forms.ComboBox();
            this.audioScaleQuality = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodingOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodingOptionsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // startConversionButton
            // 
            this.startConversionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startConversionButton.Location = new System.Drawing.Point(519, 385);
            this.startConversionButton.Name = "startConversionButton";
            this.startConversionButton.Size = new System.Drawing.Size(99, 27);
            this.startConversionButton.TabIndex = 0;
            this.startConversionButton.Text = "Start Conversion";
            this.startConversionButton.UseVisualStyleBackColor = true;
            this.startConversionButton.Click += new System.EventHandler(this.OnStartConversion);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(620, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.CausesValidation = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(500, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // browseInputButton
            // 
            this.browseInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseInputButton.Location = new System.Drawing.Point(543, 34);
            this.browseInputButton.Name = "browseInputButton";
            this.browseInputButton.Size = new System.Drawing.Size(75, 23);
            this.browseInputButton.TabIndex = 2;
            this.browseInputButton.Text = "Browse";
            this.browseInputButton.UseVisualStyleBackColor = true;
            this.browseInputButton.Click += new System.EventHandler(this.OnBrowseInputFile);
            // 
            // inputFileName
            // 
            this.inputFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFileName.Location = new System.Drawing.Point(80, 34);
            this.inputFileName.Name = "inputFileName";
            this.inputFileName.Size = new System.Drawing.Size(457, 20);
            this.inputFileName.TabIndex = 3;
            // 
            // outputFileName
            // 
            this.outputFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFileName.Location = new System.Drawing.Point(80, 72);
            this.outputFileName.Name = "outputFileName";
            this.outputFileName.Size = new System.Drawing.Size(457, 20);
            this.outputFileName.TabIndex = 4;
            // 
            // browseOutputButton
            // 
            this.browseOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseOutputButton.Location = new System.Drawing.Point(544, 72);
            this.browseOutputButton.Name = "browseOutputButton";
            this.browseOutputButton.Size = new System.Drawing.Size(75, 23);
            this.browseOutputButton.TabIndex = 5;
            this.browseOutputButton.Text = "Browse";
            this.browseOutputButton.UseVisualStyleBackColor = true;
            this.browseOutputButton.Click += new System.EventHandler(this.OnBrowseOutputFile);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Output file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Advanced options (leave blank for defaults)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Resolution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Bitrate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Framerate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Scale quality";
            // 
            // videoResolution
            // 
            this.videoResolution.Location = new System.Drawing.Point(80, 189);
            this.videoResolution.Name = "videoResolution";
            this.videoResolution.Size = new System.Drawing.Size(144, 20);
            this.videoResolution.TabIndex = 13;
            // 
            // videoBitrate
            // 
            this.videoBitrate.Location = new System.Drawing.Point(80, 220);
            this.videoBitrate.Name = "videoBitrate";
            this.videoBitrate.Size = new System.Drawing.Size(144, 20);
            this.videoBitrate.TabIndex = 14;
            // 
            // videoFramerate
            // 
            this.videoFramerate.Location = new System.Drawing.Point(80, 249);
            this.videoFramerate.Name = "videoFramerate";
            this.videoFramerate.Size = new System.Drawing.Size(144, 20);
            this.videoFramerate.TabIndex = 15;
            // 
            // videoScaleQuality
            // 
            this.videoScaleQuality.FormattingEnabled = true;
            this.videoScaleQuality.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.videoScaleQuality.Location = new System.Drawing.Point(80, 275);
            this.videoScaleQuality.Name = "videoScaleQuality";
            this.videoScaleQuality.Size = new System.Drawing.Size(144, 21);
            this.videoScaleQuality.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Video";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(336, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Audio";
            // 
            // includeVideo
            // 
            this.includeVideo.AutoSize = true;
            this.includeVideo.Checked = true;
            this.includeVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeVideo.Location = new System.Drawing.Point(80, 156);
            this.includeVideo.Name = "includeVideo";
            this.includeVideo.Size = new System.Drawing.Size(90, 17);
            this.includeVideo.TabIndex = 20;
            this.includeVideo.Text = "Include video";
            this.includeVideo.UseVisualStyleBackColor = true;
            // 
            // includeAudio
            // 
            this.includeAudio.AutoSize = true;
            this.includeAudio.Checked = true;
            this.includeAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeAudio.Location = new System.Drawing.Point(402, 154);
            this.includeAudio.Name = "includeAudio";
            this.includeAudio.Size = new System.Drawing.Size(90, 17);
            this.includeAudio.TabIndex = 21;
            this.includeAudio.Text = "Include audio";
            this.includeAudio.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(336, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Samplerate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(336, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Bitrate";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(336, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Channels";
            // 
            // audioChannels
            // 
            this.audioChannels.FormattingEnabled = true;
            this.audioChannels.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.audioChannels.Location = new System.Drawing.Point(402, 248);
            this.audioChannels.Name = "audioChannels";
            this.audioChannels.Size = new System.Drawing.Size(121, 21);
            this.audioChannels.TabIndex = 25;
            // 
            // audioSamplerate
            // 
            this.audioSamplerate.Location = new System.Drawing.Point(402, 189);
            this.audioSamplerate.Name = "audioSamplerate";
            this.audioSamplerate.Size = new System.Drawing.Size(121, 20);
            this.audioSamplerate.TabIndex = 26;
            // 
            // audioBitrate
            // 
            this.audioBitrate.Location = new System.Drawing.Point(402, 220);
            this.audioBitrate.Name = "audioBitrate";
            this.audioBitrate.Size = new System.Drawing.Size(121, 20);
            this.audioBitrate.TabIndex = 27;
            // 
            // encodingOptionsBindingSource
            // 
            this.encodingOptionsBindingSource.DataSource = typeof(FFMPEG_CSWrapper.EncodingOptions);
            // 
            // encodingOptionsBindingSource1
            // 
            this.encodingOptionsBindingSource1.DataSource = typeof(FFMPEG_CSWrapper.EncodingOptions);
            // 
            // presets
            // 
            this.presets.FormattingEnabled = true;
            this.presets.Location = new System.Drawing.Point(239, 125);
            this.presets.Margin = new System.Windows.Forms.Padding(2);
            this.presets.Name = "presets";
            this.presets.Size = new System.Drawing.Size(103, 21);
            this.presets.TabIndex = 28;
            this.presets.SelectedIndexChanged += new System.EventHandler(this.OnSelectPreset);
            // 
            // audioScaleQuality
            // 
            this.audioScaleQuality.FormattingEnabled = true;
            this.audioScaleQuality.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.audioScaleQuality.Location = new System.Drawing.Point(402, 277);
            this.audioScaleQuality.Name = "audioScaleQuality";
            this.audioScaleQuality.Size = new System.Drawing.Size(121, 21);
            this.audioScaleQuality.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(336, 280);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Scale quality";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyVideos;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 437);
            this.Controls.Add(this.audioScaleQuality);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.presets);
            this.Controls.Add(this.audioBitrate);
            this.Controls.Add(this.audioSamplerate);
            this.Controls.Add(this.audioChannels);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.includeAudio);
            this.Controls.Add(this.includeVideo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.videoScaleQuality);
            this.Controls.Add(this.videoFramerate);
            this.Controls.Add(this.videoBitrate);
            this.Controls.Add(this.videoResolution);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browseOutputButton);
            this.Controls.Add(this.outputFileName);
            this.Controls.Add(this.inputFileName);
            this.Controls.Add(this.browseInputButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startConversionButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FFGUI - By Christiaan Rakowski";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodingOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodingOptionsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button startConversionButton;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button browseInputButton;
		private System.Windows.Forms.TextBox inputFileName;
		private System.Windows.Forms.TextBox outputFileName;
		private System.Windows.Forms.Button browseOutputButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.MaskedTextBox videoResolution;
		private System.Windows.Forms.TextBox videoBitrate;
		private System.Windows.Forms.TextBox videoFramerate;
		private System.Windows.Forms.ComboBox videoScaleQuality;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox includeVideo;
		private System.Windows.Forms.CheckBox includeAudio;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox audioChannels;
		private System.Windows.Forms.TextBox audioSamplerate;
		private System.Windows.Forms.TextBox audioBitrate;
        private System.Windows.Forms.BindingSource encodingOptionsBindingSource;
        private System.Windows.Forms.BindingSource encodingOptionsBindingSource1;
        private System.Windows.Forms.ComboBox presets;
        private System.Windows.Forms.ComboBox audioScaleQuality;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}

