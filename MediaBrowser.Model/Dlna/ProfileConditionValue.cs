using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1591

namespace MediaBrowser.Model.Dlna
{
    [SuppressMessage("Design", "CA1027:Mark enums with FlagsAttribute", Justification = "False positive")]
    public enum ProfileConditionValue
    {
        AudioChannels = 0,
        AudioBitrate = 1,
        AudioProfile = 2,
        Width = 3,
        Height = 4,
        Has64BitOffsets = 5,
        PacketLength = 6,
        VideoBitDepth = 7,
        VideoBitrate = 8,
        VideoFramerate = 9,
        VideoLevel = 10,
        VideoProfile = 11,
        VideoTimestamp = 12,
        IsAnamorphic = 13,
        RefFrames = 14,
        NumAudioStreams = 16,
        NumVideoStreams = 17,
        IsSecondaryAudio = 18,
        VideoCodecTag = 19,
        IsAvc = 20,
        IsInterlaced = 21,
        AudioSampleRate = 22,
        AudioBitDepth = 23,
        VideoRangeType = 24
    }
}
