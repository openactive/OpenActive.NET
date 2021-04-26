using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// [NOTICE: This enumeration is part of the Open Booking API Test Interface, and MUST NOT be used in production.]
    /// An enumeration of open booking flows that an opportunity can be booked with.
    /// </summary>
    public enum  TestOpenBookingFlowEnumeration
    {
        [EnumMember(Value = "https://openactive.io/test-interface#OpenBookingSimpleFlow")]
        OpenBookingSimpleFlow,
        [EnumMember(Value = "https://openactive.io/test-interface#OpenBookingApprovalFlow")]
        OpenBookingApprovalFlow
    }
}
