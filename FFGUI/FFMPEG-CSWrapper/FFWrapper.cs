using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FFMPEG_CSWrapper
{
    public static class FFWrapper
    {
        public static void StartConversion(string inputFile, string outputFile, EncodingOptions advancedOptions)
        {
            Debug.WriteLine(String.Format("Starting Conversion: \"{0}\" --> \"{1}\"", inputFile, outputFile));

            string commandLineArguments = String.Format("-i \"{0}\" {2} \"{1}\"", inputFile, outputFile, advancedOptions);
            Debug.WriteLine("Using arguments: " + commandLineArguments);

            string ffmpeg = ConfigurationManager.AppSettings["FFMPEG_PATH"];
            var p = Process.Start(ffmpeg, commandLineArguments);
            //p.StandardOutput;

            /*
            Process p = new Process
            {
                StartInfo =
                {
                    FileName = ffmpeg,
                    Arguments = commandLine
                }
            };
            /*
            p.Exited += (o, args) =>
                            {
                                Debug.WriteLine("Conversion done");						
                            };
            //*/
            /*
            p.OutputDataReceived += (o, args) =>
                                        {
                                            Debug.WriteLine(args);
                                        };
            //*/
            //p.Start();
            //p.WaitForExit();
        }
    }
}
