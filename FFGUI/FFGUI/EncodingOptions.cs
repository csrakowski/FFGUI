using System;

namespace FFGUI
{
	public sealed class EncodingOptions
	{
		public static readonly EncodingOptions CUSTOM720 = new EncodingOptions
		{
			VideoResolution = "1280x720",
			VideoFramerate = "60",
			VideoBitrate = "1024k",
			VideoScaleQuality = "4",
			AudioSampleRate = "48000",
			AudioBitrate = "320k",
			AudioChannels = "2"
		};

		public string VideoResolution { get; set; }
		private string VideoResolutionArgument {
			get
			{
				if(String.IsNullOrEmpty(VideoResolution))
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
					return String.Format("-b {0}", VideoBitrate);
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
					return String.Format("-qscale {0}", VideoScaleQuality);
				}
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

		public override string ToString()
		{
			return String.Format("{0} {1} {2} {3} {4} {5} {6}", VideoResolutionArgument, VideoFramerateArgument, VideoBitrateArgument, VideoScaleQualityArgument, AudioChannelsArgument, AudioSampleRateArgument, AudioBitrateArgument);
		}
	}
}
