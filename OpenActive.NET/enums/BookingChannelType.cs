using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  BookingChannelType
    {
        [EnumMember(Value = "https://openactive.io/TelephoneAdvanceBooking")]
        TelephoneAdvanceBooking,
        [EnumMember(Value = "https://openactive.io/TelephonePrepayment")]
        TelephonePrepayment,
        [EnumMember(Value = "https://openactive.io/OnlinePrepayment")]
        OnlinePrepayment
    }
}
