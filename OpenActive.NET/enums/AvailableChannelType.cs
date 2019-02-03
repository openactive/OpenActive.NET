
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// [NOTICE: This is a beta enumeration, and is highly likely to change in future versions of this library.] 
    /// An enumeration of channels through which a booking can be made.
    /// </summary>
    public enum  AvailableChannelType
    {
        
        [EnumMember(Value = "https://openactive.io/ns-beta#TelephoneAdvanceBooking")]
        TelephoneAdvanceBooking,
        [EnumMember(Value = "https://openactive.io/ns-beta#TelephonePrepayment")]
        TelephonePrepayment,
        [EnumMember(Value = "https://openactive.io/ns-beta#OnlinePrepayment")]
        OnlinePrepayment,
        [EnumMember(Value = "https://openactive.io/ns-beta#OpenBookingPrepayment")]
        OpenBookingPrepayment
    }
}
