
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  EventAttendanceModeEnumeration
    {

        [EnumMember(Value = "https://schema.org/OfflineEventAttendanceMode")]
        OfflineEventAttendanceMode,
        [EnumMember(Value = "https://schema.org/MixedEventAttendanceMode")]
        MixedEventAttendanceMode,
        [EnumMember(Value = "https://schema.org/OnlineEventAttendanceMode")]
        OnlineEventAttendanceMode
    }
}
