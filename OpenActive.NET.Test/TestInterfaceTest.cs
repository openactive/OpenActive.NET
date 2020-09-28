using Newtonsoft.Json;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace OpenActive.NET.Test
{

    public class TestInterfaceTest
    {
        private readonly ITestOutputHelper output;

        public TestInterfaceTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly string jsonOpportunity =
        "{\"@type\":\"ScheduledSession\",\"superEvent\":{\"@type\":\"SessionSeries\"},\"@context\":[\"https://openactive.io/\",\"https://openactive.io/test-interface\"],\"test:testOpportunityCriteria\":\"https://openactive.io/test-interface#TestOpportunityBookable\"}";

        [Fact]
        public void ToString_TestInterfaceOpportunity_Deserialize() {
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(jsonOpportunity);

            Assert.Equal(TestOpportunityCriteriaEnumeration.TestOpportunityBookable, decode.TestOpportunityCriteria);
        }

        private readonly string jsonAction =
        "{\"@context\":[\"https://openactive.io/\",\"https://openactive.io/test-interface\"],\"@type\":\"test:ReplacementSimulateAction\",\"object\":{\"@type\":\"OrderProposal\",\"@id\":\"https://localhost:44396/api/openbooking/order-proposals/cacb58f6-50b5-570f-951f-acfba3d06986\"}}";

        [Fact]
        public void ToString_TestInterfaceAction_DeserializeParentClass()
        {
            var decode = OpenActiveSerializer.Deserialize<OpenBookingSimulateAction>(jsonAction);

            Assert.NotNull(decode);
            var decodeTyped = decode.Object.GetClass<Order>();
            Assert.NotNull(decodeTyped);
            Assert.Equal(new Uri("https://localhost:44396/api/openbooking/order-proposals/cacb58f6-50b5-570f-951f-acfba3d06986"), decodeTyped.Id);
        }

        [Fact]
        public void ToString_TestInterfaceAction_DeserializeGrandparentClass()
        {
            var decode = OpenActiveSerializer.Deserialize<Action>(jsonAction);

            Assert.NotNull(decode);
            var decodeTyped = decode.Object.GetClass<Order>();
            Assert.NotNull(decodeTyped);
            Assert.Equal(new Uri("https://localhost:44396/api/openbooking/order-proposals/cacb58f6-50b5-570f-951f-acfba3d06986"), decodeTyped.Id);
        }

        [Fact]
        public void ToString_TestInterfaceAction_DeserializeClass()
        {
            var decode = OpenActiveSerializer.Deserialize<ReplacementSimulateAction>(jsonAction);

            Assert.NotNull(decode);
            var decodeTyped = decode.Object.GetClass<Order>();
            Assert.NotNull(decodeTyped);
            Assert.Equal(new Uri("https://localhost:44396/api/openbooking/order-proposals/cacb58f6-50b5-570f-951f-acfba3d06986"), decodeTyped.Id);
        }
    }
}
