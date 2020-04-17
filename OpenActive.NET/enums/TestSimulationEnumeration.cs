
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// [NOTICE: This enumeration is part of the Open Booking API Test Interface, and MUST NOT be used in production.]
    /// An enumeration of test simulations.
    /// </summary>
    public enum  TestSimulationEnumeration
    {
        
        [EnumMember(Value = "https://openactive.io/test-interface#SimulateSellerRequestedCancellation")]
        SimulateSellerRequestedCancellation,
        [EnumMember(Value = "https://openactive.io/test-interface#SimulateSellerRequestedCancellationWithMessage")]
        SimulateSellerRequestedCancellationWithMessage,
        [EnumMember(Value = "https://openactive.io/test-interface#SimulateReplacement")]
        SimulateReplacement,
        [EnumMember(Value = "https://openactive.io/test-interface#SimulateCustomerNotice")]
        SimulateCustomerNotice,
        [EnumMember(Value = "https://openactive.io/test-interface#SimulateChangeOfLogistics")]
        SimulateChangeOfLogistics,
        [EnumMember(Value = "https://openactive.io/test-interface#SimulateOpportunityAttendanceUpdate")]
        SimulateOpportunityAttendanceUpdate,
        [EnumMember(Value = "https://openactive.io/test-interface#SimulateAccessPassUpdate")]
        SimulateAccessPassUpdate,
        [EnumMember(Value = "https://openactive.io/test-interface#SimulateAccessCodeUpdate")]
        SimulateAccessCodeUpdate
    }
}
