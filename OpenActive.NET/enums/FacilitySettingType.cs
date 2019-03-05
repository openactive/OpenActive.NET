
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// [NOTICE: This is a beta enumeration, and is highly likely to change in future versions of this library.] 
    /// An enumeration of settings in which a facility can exist.
    /// </summary>
    public enum  FacilitySettingType
    {
        
        [EnumMember(Value = "https://openactive.io/ns-beta#IndoorFacility")]
        IndoorFacility,
        [EnumMember(Value = "https://openactive.io/ns-beta#OutdoorFacility")]
        OutdoorFacility
    }
}
