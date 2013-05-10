using System;

namespace FFMPEG_CSWrapper
{
    public sealed class EncodingOptions
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
            AudioScaleQuality = "4"
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
            AudioScaleQuality = "4"
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
            AudioScaleQuality = "4"
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
            AudioScaleQuality = "4"
            //ForcedAudioCodec = "AC3"
        };

        public static readonly EncodingOptions[] Presets = new[] { Custom480, Custom720, Custom1080 };

        public string PresetName { get; set; }

        public bool IncludeVideo { get; set; }

        public string ForcedVideoCodec { get; set; }
        private string ForcedVideoCodecArgument
        {
            get
            {
                if (IncludeVideo == false || String.IsNullOrEmpty(ForcedVideoCodec))
                {
                    return String.Empty;
                }
                else
                {
                    return String.Format("-codec:v {0}", ForcedVideoCodec);
                }
            }
        }

        public string VideoResolution { get; set; }
        private string VideoResolutionArgument
        {
            get
            {
                if (IncludeVideo == false || String.IsNullOrEmpty(VideoResolution))
                {
                    return String.Empty;
                }
                else
                {
                    return String.Format("-s {0}", VideoResolution);
                }
            }
        }

        public string VideoFramerate { get; set; }
        private string VideoFramerateArgument
        {
            get
            {
                if (IncludeVideo == false || String.IsNullOrEmpty(VideoFramerate))
                {
                    return String.Empty;
                }
                else
                {
                    return String.Format("-r {0}", VideoFramerate);
                }
            }
        }

        public string VideoBitrate { get; set; }
        private string VideoBitrateArgument
        {
            get
            {
                if (IncludeVideo == false || String.IsNullOrEmpty(VideoBitrate))
                {
                    return String.Empty;
                }
                else
                {
					//b:v
                    return String.Format("-b:v {0}", VideoBitrate);
                }
            }
        }

        public string VideoScaleQuality { get; set; }
        private string VideoScaleQualityArgument
        {
            get
            {
                if (IncludeVideo == false || String.IsNullOrEmpty(VideoScaleQuality))
                {
                    return String.Empty;
                }
                else
                {
                    return String.Format("-q:v {0}", VideoScaleQuality);
                }
            }
        }


        public bool IncludeAudio { get; set; }

        public string ForcedAudioCodec { get; set; }
        private string ForcedAudioCodecArgument
        {
            get
            {
                if (IncludeAudio == false || String.IsNullOrEmpty(ForcedAudioCodec))
                {
                    return String.Empty;
                }
                else
                {
                    return String.Format("-codec:a {0}", ForcedAudioCodec);
                }
            }
        }

        public string AudioSampleRate { get; set; }
        private string AudioSampleRateArgument
        {
            get
            {
                if (IncludeAudio == false || String.IsNullOrEmpty(AudioSampleRate))
                {
                    return String.Empty;
                }
                else
                {
                    return String.Format("-ar {0}", AudioSampleRate);
                }
            }
        }

        public string AudioBitrate { get; set; }
        private string AudioBitrateArgument
        {
            get
            {
                if (IncludeAudio == false || String.IsNullOrEmpty(AudioBitrate))
                {
                    return String.Empty;
                }
                else
                {
					//b:a?
                    return String.Format("-ab {0}", AudioBitrate);
                }
            }
        }

        public string AudioChannels { get; set; }
        private string AudioChannelsArgument
        {
            get
            {
                if (IncludeAudio == false || String.IsNullOrEmpty(AudioChannels))
                {
                    return String.Empty;
                }
                else
                {
                    return String.Format("-ac {0}", AudioChannels);
                }
            }
        }

        public string AudioScaleQuality { get; set; }
        private string AudioScaleQualityArgument
        {
            get
            {
                if (IncludeAudio == false || String.IsNullOrEmpty(AudioScaleQuality))
                {
                    return String.Empty;
                }
                else
                {
                    return String.Format("-q:a {0}", AudioScaleQuality);
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", VideoResolutionArgument, VideoFramerateArgument, VideoBitrateArgument, VideoScaleQualityArgument, ForcedVideoCodecArgument, AudioChannelsArgument, AudioSampleRateArgument, AudioBitrateArgument, AudioScaleQualityArgument, ForcedAudioCodecArgument);
        }
    }
}
