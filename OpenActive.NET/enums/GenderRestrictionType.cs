
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// Enumerated types for gender restrictions that are applied to Events
    /// </summary>
    public enum  GenderRestrictionType
    {
        
        [EnumMember(Value = "https://openactive.io/NoRestriction")]
        NoRestriction,
        [EnumMember(Value = "https://openactive.io/MaleOnly")]
        MaleOnly,
        [EnumMember(Value = "https://openactive.io/FemaleOnly")]
        FemaleOnly
    }
}
