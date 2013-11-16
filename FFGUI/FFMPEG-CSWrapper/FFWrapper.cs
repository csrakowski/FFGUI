using System;
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
    public static class FFWrapper
    {
        public static Task<bool> StartConversion(string inputFile, string outputFile, EncodingOptions advancedOptions)
        {
            var tcs = new TaskCompletionSource<bool>();

            try
            {
                SimpleLogger.LogMessage(String.Format("Starting Conversion: \"{0}\" --> \"{1}\"", inputFile, outputFile));

                var commandLineArguments = String.Format("-i \"{0}\" {2} \"{1}\"", inputFile, outputFile, advancedOptions.ToString());
                SimpleLogger.LogMessage("Using arguments: " + commandLineArguments);

                var ffmpeg = ConfigurationManager.AppSettings["FFMPEG_PATH"];
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
                    SimpleLogger.LogMessage("Conversion done");
                    p.Dispose();
                    tcs.TrySetResult(true);
                };
                p.OutputDataReceived += (o, args) =>
                {
                    SimpleLogger.LogMessage(args.Data);
                };
                p.ErrorDataReceived += (o, args) =>
                {
                    SimpleLogger.LogMessage(args.Data, "Errors");
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
                SimpleLogger.LogMessage("Exception in FFWrapper.StartConversion: " + ex.Message, "Exceptions");
                tcs.TrySetException(ex);
                return tcs.Task;
            }
        }

        public static async Task<bool> StartBatchConversion(string inputFolder, string outputFolder, string outputFormat, EncodingOptions advancedOptions)
        {
            if(!Directory.Exists(outputFolder)) {
                Directory.CreateDirectory(outputFolder);
            }

            var result = new List<bool>();
            var di = new DirectoryInfo(inputFolder);
            var files = di.GetFiles();
            foreach(var file in files)
            {
                var status = false;
                try
                {
                    var inName = file.FullName;
                    var outName = String.Format("{0}\\{1}.{2}", outputFolder, file.Name, outputFormat);
                    status = await StartConversion(inName, outName, advancedOptions);
                }
                catch (Exception ex)
                {
                    SimpleLogger.LogMessage("Exception in FFWrapper.StartBatchConversion: " + ex.Message);
                }
                result.Add(status);
            }
            return result.All(b => b);
        }
    }
}
