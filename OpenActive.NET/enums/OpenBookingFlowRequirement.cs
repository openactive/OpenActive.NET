using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  OpenBookingFlowRequirement
    {
        [EnumMember(Value = "https://openactive.io/OpenBookingIntakeForm")]
        OpenBookingIntakeForm,
        [EnumMember(Value = "https://openactive.io/OpenBookingAttendeeDetails")]
        OpenBookingAttendeeDetails,
        [EnumMember(Value = "https://openactive.io/OpenBookingApproval")]
        OpenBookingApproval,
        [EnumMember(Value = "https://openactive.io/OpenBookingNegotiation")]
        OpenBookingNegotiation,
        [EnumMember(Value = "https://openactive.io/OpenBookingMessageExchange")]
        OpenBookingMessageExchange
    }
}
