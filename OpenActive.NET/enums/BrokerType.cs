
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// </summary>
    public enum  BrokerType
    {
        
        [EnumMember(Value = "https://openactive.io/AgentBroker")]
        AgentBroker,
        [EnumMember(Value = "https://openactive.io/NoBroker")]
        NoBroker,
        [EnumMember(Value = "https://openactive.io/ResellerBroker")]
        ResellerBroker
    }
}
