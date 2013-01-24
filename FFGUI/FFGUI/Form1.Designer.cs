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
			this.SuspendLayout();
			// 
			// startConversionButton
			// 
			this.startConversionButton.Location = new System.Drawing.Point(173, 210);
			this.startConversionButton.Name = "startConversionButton";
			this.startConversionButton.Size = new System.Drawing.Size(99, 27);
			this.startConversionButton.TabIndex = 0;
			this.startConversionButton.Text = "Start Conversion";
			this.startConversionButton.UseVisualStyleBackColor = true;
			this.startConversionButton.Click += new System.EventHandler(this.OnStartConversion);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 240);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(284, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// browseInputButton
			// 
			this.browseInputButton.Location = new System.Drawing.Point(196, 29);
			this.browseInputButton.Name = "browseInputButton";
			this.browseInputButton.Size = new System.Drawing.Size(75, 23);
			this.browseInputButton.TabIndex = 2;
			this.browseInputButton.Text = "browse";
			this.browseInputButton.UseVisualStyleBackColor = true;
			this.browseInputButton.Click += new System.EventHandler(this.OnBrowseInputFile);
			// 
			// inputFileName
			// 
			this.inputFileName.Location = new System.Drawing.Point(13, 29);
			this.inputFileName.Name = "inputFileName";
			this.inputFileName.Size = new System.Drawing.Size(177, 20);
			this.inputFileName.TabIndex = 3;
			// 
			// outputFileName
			// 
			this.outputFileName.Location = new System.Drawing.Point(13, 67);
			this.outputFileName.Name = "outputFileName";
			this.outputFileName.Size = new System.Drawing.Size(177, 20);
			this.outputFileName.TabIndex = 4;
			// 
			// browseOutputButton
			// 
			this.browseOutputButton.Location = new System.Drawing.Point(197, 67);
			this.browseOutputButton.Name = "browseOutputButton";
			this.browseOutputButton.Size = new System.Drawing.Size(75, 23);
			this.browseOutputButton.TabIndex = 5;
			this.browseOutputButton.Text = "browse";
			this.browseOutputButton.UseVisualStyleBackColor = true;
			this.browseOutputButton.Click += new System.EventHandler(this.OnBrowseOutputFile);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
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
	}
}

