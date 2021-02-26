
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// [NOTICE: This enumeration is part of the Open Booking API Test Interface, and MUST NOT be used in production.]
    /// An enumeration of test opportunity criteria to which an opportunity must conform.
    /// </summary>
    public enum  TestOpportunityCriteriaEnumeration
    {
        
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookable")]
        TestOpportunityBookable,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityNotBookableViaAvailableChannel")]
        TestOpportunityNotBookableViaAvailableChannel,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableNoSpaces")]
        TestOpportunityBookableNoSpaces,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFiveSpaces")]
        TestOpportunityBookableFiveSpaces,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFree")]
        TestOpportunityBookableFree,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableNonFree")]
        TestOpportunityBookableNonFree,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableUsingPayment")]
        TestOpportunityBookableUsingPayment,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableWithinValidFromBeforeStartDate")]
        TestOpportunityBookableWithinValidFromBeforeStartDate,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableOutsideValidFromBeforeStartDate")]
        TestOpportunityBookableOutsideValidFromBeforeStartDate,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableCancellable")]
        TestOpportunityBookableCancellable,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableCancellableWithinWindow")]
        TestOpportunityBookableCancellableWithinWindow,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableCancellableOutsideWindow")]
        TestOpportunityBookableCancellableOutsideWindow,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableWithinValidFromBeforeStartDateWindow")]
        TestOpportunityBookableWithinValidFromBeforeStartDateWindow,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableOutsideValidFromBeforeStartDateWindow")]
        TestOpportunityBookableOutsideValidFromBeforeStartDateWindow,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableAttendeeDetails")]
        TestOpportunityBookableAttendeeDetails,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableAdditionalDetails")]
        TestOpportunityBookableAdditionalDetails,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFreePrepaymentOptional")]
        TestOpportunityBookableFreePrepaymentOptional,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableNonFreePrepaymentOptional")]
        TestOpportunityBookableNonFreePrepaymentOptional,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableNonFreePrepaymentUnavailable")]
        TestOpportunityBookableNonFreePrepaymentUnavailable,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFreePrepaymentRequired")]
        TestOpportunityBookableFreePrepaymentRequired,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableNonFreePrepaymentRequired")]
        TestOpportunityBookableNonFreePrepaymentRequired,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableNonFreeTaxGross")]
        TestOpportunityBookableNonFreeTaxGross,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableNonFreeTaxNet")]
        TestOpportunityBookableNonFreeTaxNet,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableSellerTermsOfService")]
        TestOpportunityBookableSellerTermsOfService,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFlowRequirementOnlyApproval")]
        TestOpportunityBookableFlowRequirementOnlyApproval,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityOnlineBookable")]
        TestOpportunityOnlineBookable
    }
}
