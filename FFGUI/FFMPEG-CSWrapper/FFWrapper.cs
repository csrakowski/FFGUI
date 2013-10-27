using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFMPEG_CSWrapper
{
    public static class FFWrapper
    {
        public static Task<bool> StartConversion(string inputFile, string outputFile, EncodingOptions advancedOptions)
        {
            var tcs = new TaskCompletionSource<bool>();

            try
            {
                Debug.WriteLine(String.Format("Starting Conversion: \"{0}\" --> \"{1}\"", inputFile, outputFile));

                var commandLineArguments = String.Format("-i \"{0}\" {2} \"{1}\"", inputFile, outputFile, advancedOptions.ToString());
                Debug.WriteLine("Using arguments: " + commandLineArguments);

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
                    Debug.WriteLine("Conversion done");
                    p.Dispose();
                    tcs.TrySetResult(true);
                };
                p.OutputDataReceived += (o, args) =>
                {
                    Debug.WriteLine(args.Data, "Messages");
                };
                p.ErrorDataReceived += (o, args) =>
                {
                    Debug.WriteLine(args.Data, "Errors");
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
                Debug.WriteLine("Exception in FFWrapper.StartConversion: " + ex.Message);
                tcs.TrySetException(ex);
                return tcs.Task;
            }
        }
    }
}
