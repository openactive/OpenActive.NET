
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// </summary>
    public enum  TaxMode
    {
        
        [EnumMember(Value = "https://openactive.io/TaxGross")]
        TaxGross,
        [EnumMember(Value = "https://openactive.io/TaxNet")]
        TaxNet
    }
}
