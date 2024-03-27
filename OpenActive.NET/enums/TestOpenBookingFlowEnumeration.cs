using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// [NOTICE: This enumeration is part of the Open Booking API Test Interface, and MUST NOT be used in production.]
    /// An enumeration of [open booking flow](https://openactive.io/open-booking-api/EditorsDraft/1.0CR3/#booking-flows) that an [Opportunity and Offer pair](https://openactive.io/open-booking-api/EditorsDraft/1.0CR3/#definition-of-a-bookable-opportunity-and-offer-pair) can be booked with.
    /// </summary>
    public enum  TestOpenBookingFlowEnumeration
    {
        [EnumMember(Value = "https://openactive.io/test-interface#OpenBookingSimpleFlow")]
        OpenBookingSimpleFlow,
        [EnumMember(Value = "https://openactive.io/test-interface#OpenBookingApprovalFlow")]
        OpenBookingApprovalFlow
    }
}
