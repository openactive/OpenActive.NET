using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  RequiredStatusType
    {
        [EnumMember(Value = "https://openactive.io/Required")]
        Required,
        [EnumMember(Value = "https://openactive.io/Optional")]
        Optional,
        [EnumMember(Value = "https://openactive.io/Unavailable")]
        Unavailable
    }
}
