using System.Threading.Tasks;

namespace FFMPEG_CSWrapper
{
    public interface IFFWrapper
    {
        event FFWrapper.Completed OnCompleted;
        event FFWrapper.ProgressReport OnProgressChanged;

        bool GenerateThumbnail(string inputFile, string outputFile, string timeIndex = "00:00:01.000");
        Task<bool> StartBatchConversionAsync(string inputFolder, string outputFolder, string outputFormat, EncodingOptions advancedOptions);
        Task<bool> StartConversionAsync(string inputFile, string outputFile, EncodingOptions advancedOptions);
    }
}