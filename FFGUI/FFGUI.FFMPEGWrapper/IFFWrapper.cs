using System.Threading.Tasks;

namespace FFGUI.FFMPEGWrapper
{
    public interface IFFWrapper
    {
        event CompletedEvent OnCompleted;
        event ProgressReportEvent OnProgressChanged;
        event LogMessageEvent OnLogMessage;

        bool GenerateThumbnail(string inputFile, string outputFile, string timeIndex = "00:00:01.000");
        Task<bool> StartBatchConversionAsync(string inputFolder, string outputFolder, string outputFormat, EncodingOptions advancedOptions);
        Task<bool> StartConversionAsync(string inputFile, string outputFile, EncodingOptions advancedOptions);
    }
}