
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  AvailableChannelType
    {

        [EnumMember(Value = "https://openactive.io/OpenBookingPrepayment")]
        OpenBookingPrepayment,
        [EnumMember(Value = "https://openactive.io/TelephoneAdvanceBooking")]
        TelephoneAdvanceBooking,
        [EnumMember(Value = "https://openactive.io/TelephonePrepayment")]
        TelephonePrepayment,
        [EnumMember(Value = "https://openactive.io/OnlinePrepayment")]
        OnlinePrepayment
    }
}
