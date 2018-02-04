using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFMPEG_CSWrapper
{
    public sealed partial class EncodingOptions
    {
        public static readonly EncodingOptions HFVideo = new EncodingOptions
        {
            PresetName = "hfVideo",

            IncludeVideo = true,
            VideoResolution = "1280x720",
            VideoFramerate = "25",
            VideoBitrate = "2048k",
            VideoScaleQuality = "4",
            ForcedVideoCodec = "x264",

            IncludeAudio = true,
            AudioSampleRate = "44100",
            AudioBitrate = "192k",
            AudioChannels = "2",
            AudioScaleQuality = "4",
            ApplyAudioNormalizationFilter = true
            //ForcedAudioCodec = "MP3"
        };

        public static readonly EncodingOptions Custom480 = new EncodingOptions
        {
            PresetName = "480p",

            IncludeVideo = true,
            VideoResolution = "853x480",
            VideoFramerate = "25",
            VideoBitrate = "1024k",
            VideoScaleQuality = "4",
            //ForcedVideoCodec = "x264",

            IncludeAudio = true,
            AudioSampleRate = "48000",
            AudioBitrate = "192k",
            AudioChannels = "2",
            AudioScaleQuality = "4",
            ApplyAudioNormalizationFilter = true
            //ForcedAudioCodec = "AC3"
        };

        public static readonly EncodingOptions Custom720 = new EncodingOptions
        {
            PresetName = "720p",

            IncludeVideo = true,
            VideoResolution = "1280x720",
            VideoFramerate = "25",
            VideoBitrate = "2048k",
            VideoScaleQuality = "4",
            //ForcedVideoCodec = "x264",

            IncludeAudio = true,
            AudioSampleRate = "48000",
            AudioBitrate = "192k",
            AudioChannels = "2",
            AudioScaleQuality = "4",
            ApplyAudioNormalizationFilter = true
            //ForcedAudioCodec = "AC3"
        };

        public static readonly EncodingOptions Custom1080 = new EncodingOptions
        {
            PresetName = "1080p",

            IncludeVideo = true,
            VideoResolution = "1920x1080",
            VideoFramerate = "25",
            VideoBitrate = "8192k",
            VideoScaleQuality = "4",
            //ForcedVideoCodec = "x264",

            IncludeAudio = true,
            AudioSampleRate = "48000",
            AudioBitrate = "320k",
            AudioChannels = "2",
            AudioScaleQuality = "4",
            ApplyAudioNormalizationFilter = true
            //ForcedAudioCodec = "AC3"
        };

        public static readonly EncodingOptions[] Presets = { Custom480, Custom720, Custom1080 };
    }
}
