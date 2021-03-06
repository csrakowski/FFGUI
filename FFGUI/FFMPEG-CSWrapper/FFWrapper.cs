﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Logger;
using System.Diagnostics;

namespace FFMPEG_CSWrapper
{
	public class FFWrapper : IFFWrapper
	{
		private readonly ISimpleLogger simpleLogger;
		private readonly string ffmpeg;

		public delegate void ProgressReport(int currentFileIndex, string currentFileName, int totalFiles, float percentage);
		public event ProgressReport OnProgressChanged;

		public delegate void Completed();
		public event Completed OnCompleted;

		public FFWrapper(ISimpleLogger simpleLogger, string ffmepgPath)
		{
			this.simpleLogger = simpleLogger;
			this.ffmpeg = ffmepgPath;
		}

		public bool GenerateThumbnail(string inputFile, string outputFile, string timeIndex = "00:00:01.000")
		{
			simpleLogger.LogMessage($"Generating Thumbnail for file: \"{inputFile}\" --> \"{outputFile}\", using time index: {timeIndex}");

			var commandArguments = $"-i \"{inputFile}\" -ss {timeIndex} -f image2 -vframes 1 \"{outputFile}\"";

			simpleLogger.LogMessage("Using arguments: " + commandArguments);

			var success = false;
			try
			{
				var procStartInfo = new ProcessStartInfo(ffmpeg, commandArguments)
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					WindowStyle = ProcessWindowStyle.Hidden,

					ErrorDialog = true,
				};
				var p = Process.Start(procStartInfo);
				p.WaitForExit();
				success = true;
			}
			catch (Exception ex)
			{
				simpleLogger.LogMessage("Exception in FFWrapper.GenerateThumbnail: " + ex.Message, "Exceptions");
				success = false;
			}

			return success;
		}

		public Task<bool> StartConversionAsync(string inputFile, string outputFile, EncodingOptions advancedOptions)
		{
			var tcs = new TaskCompletionSource<bool>();

			try
			{
				simpleLogger.LogMessage($"Starting Conversion: \"{inputFile}\" --> \"{outputFile}\"");

				var commandLineArguments = $"-i \"{inputFile}\" {advancedOptions.ToString()} \"{outputFile}\"";
				simpleLogger.LogMessage("Using arguments: " + commandLineArguments);

				var procStartInfo = new ProcessStartInfo(ffmpeg, commandLineArguments)
				{
					//*
					CreateNoWindow = true,
					UseShellExecute = false,
					WindowStyle = ProcessWindowStyle.Hidden,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					//*/

					ErrorDialog = true,
				};
				//var p = Process.Start(procStartInfo);
				var p = new Process()
				{
					StartInfo = procStartInfo,
					EnableRaisingEvents = true,
				};

				//*
				p.Exited += (o, args) =>
				{
					simpleLogger.LogMessage("Conversion done");
					p.Dispose();
					tcs.TrySetResult(true);
				};
				p.OutputDataReceived += (o, args) =>
				{
					simpleLogger.LogMessage(args.Data);
				};
				p.ErrorDataReceived += (o, args) =>
				{
					simpleLogger.LogMessage(args.Data, "Errors");
				};
				//*/
				if(p.Start())
				{
					p.BeginOutputReadLine();
					p.BeginErrorReadLine();
				}
				else
				{
					tcs.TrySetException(new InvalidOperationException("Failed to start process"));
				}

				return tcs.Task;
			}
			catch (Exception ex)
			{
				simpleLogger.LogMessage("Exception in FFWrapper.StartConversion: " + ex.Message, "Exceptions");
				tcs.TrySetException(ex);
				return tcs.Task;
			}
		}

		public async Task<bool> StartBatchConversionAsync(string inputFolder, string outputFolder, string outputFormat, EncodingOptions advancedOptions)
		{
			if(!Directory.Exists(outputFolder)) {
				Directory.CreateDirectory(outputFolder);
			}

			var result = new List<bool>();
			var di = new DirectoryInfo(inputFolder);
			var files = di.GetFiles();

			var numberOfFiles = files.Length;
			for (int i = 0; i < numberOfFiles; i++)
			{
				var status = false;
				try
				{
					var file = files[i];
					var inName = file.FullName;
					var outName = $"{outputFolder}\\{file.Name}.{outputFormat}";
					setProgress(i, inName, numberOfFiles);
					status = await StartConversionAsync(inName, outName, advancedOptions);
				}
				catch (Exception ex)
				{
					simpleLogger.LogMessage("Exception in FFWrapper.StartBatchConversion: " + ex.Message);
				}
				result.Add(status);
			}
			setProgress(numberOfFiles, String.Empty, numberOfFiles);
			return result.All(b => b);
		}

		private void setProgress(int currentIndex, string currentFileName, int totalNumberOfFiles)
		{
			if(totalNumberOfFiles == 0 || currentIndex > totalNumberOfFiles)
			{
				OnProgressChanged?.Invoke(totalNumberOfFiles, String.Empty, totalNumberOfFiles, 100);
				OnCompleted?.Invoke();
			}
			else
			{
				var perc = (((float)currentIndex / (float)totalNumberOfFiles) * 100);
				var perv = (float)Math.Round(perc, 0);
				OnProgressChanged?.Invoke(currentIndex, currentFileName, totalNumberOfFiles, perc);
			}
		}
	}
}
