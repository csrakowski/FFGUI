using System;

namespace FFMPEG_CSWrapper
{
	public sealed partial class EncodingOptions
	{
		public string PresetName { get; set; }

		#region Video

		public bool IncludeVideo { get; set; }
		private string VideoArguments
		{
			get
			{
				if (IncludeVideo)
				{
					return $"{VideoResolutionArgument} {VideoFramerateArgument} {VideoBitrateArgument} {VideoScaleQualityArgument} {ForcedVideoCodecArgument}";
				}
				else
				{
					return "-vn";
				}
			}
		}

		public string ForcedVideoCodec { get; set; }
		private string ForcedVideoCodecArgument
		{
			get
			{
				var codec = ForcedVideoCodec;
				if (String.IsNullOrEmpty(codec))
				{
					return String.Empty;
					//codec = "copy";
				}
				return String.Format("-codec:v {0}", codec);
			}
		}

		public string VideoResolution { get; set; }
		private string VideoResolutionArgument
		{
			get
			{
				if (String.IsNullOrEmpty(VideoResolution))
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
				if (String.IsNullOrEmpty(VideoFramerate))
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
				if (String.IsNullOrEmpty(VideoBitrate))
				{
					return String.Empty;
				}
				else
				{
					return String.Format("-b:v {0}", VideoBitrate);
				}
			}
		}

		public string VideoScaleQuality { get; set; }
		private string VideoScaleQualityArgument
		{
			get
			{
				if (String.IsNullOrEmpty(VideoScaleQuality))
				{
					return String.Empty;
				}
				else
				{
					return String.Format("-q:v {0}", VideoScaleQuality);
				}
			}
		}

		#endregion

		#region Audio

		public bool IncludeAudio { get; set; }
		private string AudioArguments {
			get {
				if (IncludeAudio)
				{
					return $"{AudioChannelsArgument} {AudioSampleRateArgument} {AudioBitrateArgument} {AudioScaleQualityArgument} {ForcedAudioCodecArgument} {ApplyAudioNormalizationFilterArgument}";
				}
				else
				{
					return "-an";
				}
			}
		}

		public string ForcedAudioCodec { get; set; }
		private string ForcedAudioCodecArgument
		{
			get
			{
				var codec = ForcedAudioCodec;
				if (String.IsNullOrEmpty(codec))
				{
					return String.Empty;
					//codec = "copy";
				}
				return String.Format("-codec:a {0}", codec);
			}
		}

		public string AudioSampleRate { get; set; }
		private string AudioSampleRateArgument
		{
			get
			{
				if (String.IsNullOrEmpty(AudioSampleRate))
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
				if (String.IsNullOrEmpty(AudioBitrate))
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
				if (String.IsNullOrEmpty(AudioChannels))
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
				if (String.IsNullOrEmpty(AudioScaleQuality))
				{
					return String.Empty;
				}
				else
				{
					return String.Format("-q:a {0}", AudioScaleQuality);
				}
			}
		}

		public bool ApplyAudioNormalizationFilter { get; set; }
		private string ApplyAudioNormalizationFilterArgument
		{
			get
			{
				if (!ApplyAudioNormalizationFilter)
				{
					return String.Empty;
				}
				else
				{
					return "-af \"loudnorm\" -af \"volume=1.6\"";
				}
			}
		}

		#endregion

		public override string ToString()
		{
			return String.Format("{0} {1} -y", VideoArguments, AudioArguments);
		}
	}
}
