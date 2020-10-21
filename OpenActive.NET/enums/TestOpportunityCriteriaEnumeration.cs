
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
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableTwoSpaces")]
        TestOpportunityBookableTwoSpaces,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFiveSpaces")]
        TestOpportunityBookableFiveSpaces,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFree")]
        TestOpportunityBookableFree,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookablePaid")]
        TestOpportunityBookablePaid,
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
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFreeAttendeeDetails")]
        TestOpportunityBookableFreeAttendeeDetails,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookablePaidAttendeeDetails")]
        TestOpportunityBookablePaidAttendeeDetails,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableAdditionalDetails")]
        TestOpportunityBookableAdditionalDetails,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFreePrepaymentOptional")]
        TestOpportunityBookableFreePrepaymentOptional,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookablePaidPrepaymentOptional")]
        TestOpportunityBookablePaidPrepaymentOptional,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFreePrepaymentUnavailable")]
        TestOpportunityBookableFreePrepaymentUnavailable,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookablePaidPrepaymentUnavailable")]
        TestOpportunityBookablePaidPrepaymentUnavailable,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFreePrepaymentRequired")]
        TestOpportunityBookableFreePrepaymentRequired,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookablePaidPrepaymentRequired")]
        TestOpportunityBookablePaidPrepaymentRequired,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFreePrepaymentUnspecified")]
        TestOpportunityBookableFreePrepaymentUnspecified,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookablePaidPrepaymentUnspecified")]
        TestOpportunityBookablePaidPrepaymentUnspecified,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookablePaidTaxGross")]
        TestOpportunityBookablePaidTaxGross,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookablePaidTaxNet")]
        TestOpportunityBookablePaidTaxNet,
        [EnumMember(Value = "https://openactive.io/test-interface#TestOpportunityBookableFlowRequirementOnlyApproval")]
        TestOpportunityBookableFlowRequirementOnlyApproval
    }
}
