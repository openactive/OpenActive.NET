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

        private readonly string json =
        "{\"@type\":\"ScheduledSession\",\"superEvent\":{\"@type\":\"SessionSeries\"},\"@context\":[\"https://openactive.io/\",\"https://openactive.io/test-interface\"],\"test:testOpportunityCriteria\":\"https://openactive.io/test-interface#TestOpportunityBookable\"}";

        [Fact]
        public void ToString_DatasetGoogleStructuredData_ReturnsExpectedJsonLd() {
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(json);

            Assert.Equal(TestOpportunityCriteriaEnumeration.TestOpportunityBookable, decode.TestOpportunityCriteria);
        }

        

    }
}
