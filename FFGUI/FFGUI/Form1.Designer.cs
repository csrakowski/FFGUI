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
			this.startConversionButton = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.browseInputButton = new System.Windows.Forms.Button();
			this.inputFileName = new System.Windows.Forms.TextBox();
			this.outputFileName = new System.Windows.Forms.TextBox();
			this.browseOutputButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// startConversionButton
			// 
			this.startConversionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.startConversionButton.Location = new System.Drawing.Point(513, 390);
			this.startConversionButton.Name = "startConversionButton";
			this.startConversionButton.Size = new System.Drawing.Size(99, 27);
			this.startConversionButton.TabIndex = 0;
			this.startConversionButton.Text = "Start Conversion";
			this.startConversionButton.UseVisualStyleBackColor = true;
			this.startConversionButton.Click += new System.EventHandler(this.OnStartConversion);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 420);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(624, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// browseInputButton
			// 
			this.browseInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseInputButton.Location = new System.Drawing.Point(537, 34);
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
			this.inputFileName.Size = new System.Drawing.Size(451, 20);
			this.inputFileName.TabIndex = 3;
			// 
			// outputFileName
			// 
			this.outputFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputFileName.Location = new System.Drawing.Point(80, 72);
			this.outputFileName.Name = "outputFileName";
			this.outputFileName.Size = new System.Drawing.Size(451, 20);
			this.outputFileName.TabIndex = 4;
			// 
			// browseOutputButton
			// 
			this.browseOutputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseOutputButton.Location = new System.Drawing.Point(538, 72);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 442);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.browseOutputButton);
			this.Controls.Add(this.outputFileName);
			this.Controls.Add(this.inputFileName);
			this.Controls.Add(this.browseInputButton);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.startConversionButton);
			this.Name = "Form1";
			this.Text = "Form1";
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
	}
}

