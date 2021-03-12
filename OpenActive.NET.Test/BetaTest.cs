using Newtonsoft.Json;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace OpenActive.NET.Test
{

    public class BetaTest
    {
        private readonly ITestOutputHelper output;

        public BetaTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly string jsonOpportunity =
        "{\"@context\":[\"https://openactive.io/\",\"https://openactive.io/ns-beta\"],\"@type\":\"SessionSeries\",\"beta:affiliatedLocation\":{" +
            "\"@type\":\"Place\"," +
            "\"name\":\"Santa Clara City Library, Central Park Library\"" +
        "}}";

        private readonly SessionSeries opportunity = new OpenActive.NET.SessionSeries()
        {
            AffiliatedLocation = new Place { 
                Name = "Santa Clara City Library, Central Park Library"
            }
        };

        [Fact]
        public void BetaOpportunity_Deserialize() {
            var decode = OpenActiveSerializer.Deserialize<SessionSeries>(jsonOpportunity);
            Assert.NotNull(decode);
            Assert.NotNull(decode.AffiliatedLocation);
            Assert.Equal("Santa Clara City Library, Central Park Library", decode.AffiliatedLocation.Name);
        }

        [Fact]
        public void BetaOpportunity_EncodeDecode()
        {
            var decode = OpenActiveSerializer.Deserialize<SessionSeries>(jsonOpportunity);
            var encode = OpenActiveSerializer.Serialize(decode);

            output.WriteLine(jsonOpportunity);
            output.WriteLine(encode);
            Assert.Equal(jsonOpportunity, encode);
        }

        [Fact]
        public void BetaOpportunity_ToString_ReturnsExpectedJsonLd()
        {
            output.WriteLine(this.opportunity.ToString());
            Assert.Equal(this.jsonOpportunity, this.opportunity.ToString());
        }

        [Fact]
        public void BetaOpportunity_Serialize()
        {
            var encode = OpenActiveSerializer.Serialize(this.opportunity);
            output.WriteLine(encode);
            Assert.Equal(this.jsonOpportunity, encode);
        }
    }
}
