using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

                var commandLineArguments = String.Format("-i \"{0}\" {2} \"{1}\"", inputFile, outputFile, advancedOptions);
                Debug.WriteLine("Using arguments: " + commandLineArguments);

                var ffmpeg = ConfigurationManager.AppSettings["FFMPEG_PATH"];
                var procStartInfo = new ProcessStartInfo(ffmpeg, commandLineArguments)
                {
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Hidden,

                    UseShellExecute = false,
                    RedirectStandardOutput = true,

                    ErrorDialog = true,
                };
                var p = Process.Start(procStartInfo);

                //var txt = p.StandardOutput.ReadToEnd();

                //*
                p.Exited += (o, args) =>
                {
                    tcs.SetResult(true);
                    Debug.WriteLine("Conversion done");
                };
                p.OutputDataReceived += (o, args) =>
                {
                    Debug.WriteLine(args.Data);
                };
                //*/
                //p.Start();
                //p.WaitForExit();

                //tcs.SetResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in FFWrapper.StartConversion: " + ex.Message);
                tcs.SetException(ex);
            }
            return tcs.Task;
        }
    }
}
