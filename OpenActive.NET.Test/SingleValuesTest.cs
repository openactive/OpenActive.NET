using Newtonsoft.Json;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
namespace OpenActive.NET.Test
{
    public class SingleValuesTest
    {
        private readonly ITestOutputHelper output;

        public SingleValuesTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void SingleValues_Primative()
        {
            SingleValues<int, string> value = 1;
            Assert.Equal(1, value.GetPrimative<int>());
        }

        [Fact]
        public void SingleValues_Nullable_Primative()
        {
            SingleValues<int?, string> value = 1;
            Assert.Equal(1, value.GetPrimative<int>());
        }

        private readonly string SuperEventJson = "{\"id\":\"https://tst.myeveryoneactive.com/OpenActive/api/scheduled-sessions/1380172616\",\"type\":\"ScheduledSession\",\"endDate\":\"2020-02-11T15:00:00Z\",\"@context\":[\"https://openactive.io/\",\"https://openactive.io/ns-beta\"],\"duration\":\"PT8H\",\"startDate\":\"2020-02-11T07:00:00Z\",\"identifier\":\"1380172616\",\"maximumAttendeeCapacity\":15,\"remainingAttendeeCapacity\":15,\"beta:sportsActivityLocation\":[{\"name\":\"Gym Active 11-15yrs\",\"type\":\"SportsActivityLocation\"}],\"superEvent\":{\"name\":\"Adult Supervised11-15yrs\",\"type\":\"SessionSeries\",\"offers\":[{\"name\":\"Adult\",\"type\":\"Offer\",\"price\":2.35,\"identifier\":\"STAND\",\"description\":\"Junior Active\",\"priceCurrency\":\"GBP\"}],\"@context\":[\"https://openactive.io/\",\"https://imin.co/\",\"https://openactive.io/ns-beta\"],\"activity\":[{\"type\":\"Concept\",\"prefLabel\":\"Gym Active 11-15 Yrs\"}],\"category\":[\"Gym Active 11-15 Yrs\"],\"duration\":\"PT8H\",\"location\":{\"type\":\"Place\",\"id\":\"#/imin:locationSummary/954715d5fae3e05804d2194dda366e8a1c68c602\"},\"identifier\":\"everyoneactivetst2020-SessionSeries-c949770d44c848e22bb8bb4e6ad64a2be5787980\",\"eventSchedule\":[{\"type\":\"PartialSchedule\",\"byDay\":[\"schema:Monday\",\"schema:Tuesday\",\"schema:Wednesday\",\"schema:Thursday\",\"schema:Friday\"],\"endDate\":\"2022-12-31\",\"endTime\":\"15:00\",\"duration\":\"PT8H\",\"startDate\":\"2016-05-16\",\"startTime\":\"07:00\"}],\"superEvent\":{\"@context\":[\"https://openactive.io/\",\"https://schema.imin.co/\",\"https://openactive.io/ns-beta\",\"http://data.emduk.org/ns/emduk.jsonld\"],\"name\":\"11-15 Years Supervised Gym Sessions\",\"type\":\"EventSeries\",\"ageRange\":{\"type\":\"QuantitativeValue\",\"maxValue\":15,\"minValue\":11},\"isCoached\":false,\"organizer\":{\"name\":\"EveryoneActive\",\"type\":\"Organization\",\"legalName\":\"EveryoneActive\"},\"identifier\":\"everyoneactivetst2020-EventSeries-460a7c85ebdf02ade2aa4674ac6f5571c41163c3\",\"imin:level\":[{\"name\":\"Beginner\",\"type\":\"imin:BeginnerLevel\"},{\"name\":\"Intermediate\",\"type\":\"imin:IntermediateLevel\"},{\"name\":\"Advanced\",\"type\":\"imin:AdvancedLevel\"}],\"description\":\"Suitable for children aged from 11 to 15 years, these gym and studio-based sessions help to improve general fitness and to promote healthy lifestyles.\\n\",\"genderRestriction\":\"oa:NoRestriction\",\"imin:aggregateOffer\":{\"type\":\"imin:AggregateOffer\",\"publicAdult\":{\"type\":\"AggregateOffer\",\"price\":2.35,\"priceCurrency\":\"GBP\",\"imin:membershipRequired\":false}},\"isAccessibleForFree\":false,\"beta:formattedDescription\":\"<p>Suitable for children aged from 11 to 15 years, these gym and studio-based sessions help to improve general fitness and to promote healthy lifestyles.</p>\",\"id\":\"https://search-test.imin.co/events-api/v2/event-series/everyoneactivetst2020-EventSeries-460a7c85ebdf02ade2aa4674ac6f5571c41163c3\",\"imin:dataSource\":{\"type\":\"WebAPI\",\"identifier\":\"everyoneactivetst2020\"},\"imin:locationSummary\":[{\"id\":\"#/imin:locationSummary/954715d5fae3e05804d2194dda366e8a1c68c602\",\"geo\":{\"type\":\"GeoCoordinates\",\"latitude\":54.5605505,\"longitude\":-1.204684},\"name\":\"Neptune Centre\",\"type\":\"Place\",\"address\":{\"type\":\"PostalAddress\",\"imin:fullAddress\":\"Neptune Centre\"},\"identifier\":\"0138\"}]}}}";

        [Fact]
        public void ScheduledSession_SuperEvent_Deserialize()
        {
            // Should recognise subclasses of Event when deserialising
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(SuperEventJson);
            output.WriteLine(SuperEventJson);
            output.WriteLine("");
            output.WriteLine(decode.ToString());

            // Should recognise subclasses of Event when deserialising
            Assert.IsType<ScheduledSession>(OpenActiveSerializer.Deserialize<ScheduledSession>(SuperEventJson));
            Assert.IsType<ScheduledSession>(OpenActiveSerializer.Deserialize<Event>(SuperEventJson));

            Assert.Equal(15, decode.MaximumAttendeeCapacity);

            // Test superEvent
            Assert.IsType<SessionSeries>(decode.SuperEvent.Object);
            Assert.Equal("Adult Supervised11-15yrs", decode.SuperEvent.Object?.Name);

            // Test superEvent.superEvent
            Assert.IsType<EventSeries>(decode.SuperEvent.Object?.SuperEvent);
            Assert.Equal("11-15 Years Supervised Gym Sessions", decode.SuperEvent.Object?.SuperEvent.Name);
        }

        [Fact]
        public void SingleValues_HasValueOfType()
        {
            SingleValues<Event, string> sessionSeries = new SessionSeries();
            SingleValues<Event, string> @event = new Event();

            Assert.True(sessionSeries.HasValueOfType<SessionSeries>());
            Assert.True(sessionSeries.HasValueOfType<Event>());

            Assert.False(@event.HasValueOfType<SessionSeries>());
            Assert.True(@event.HasValueOfType<Event>());
        }

        [Fact]
        public void SingleValues_GetClass()
        {
            SingleValues<Event, string> sessionSeries = new SessionSeries();
            SingleValues<Event, string> @event = new Event();

            Assert.NotNull(sessionSeries.GetClass<SessionSeries>());
            Assert.NotNull(sessionSeries.GetClass<Event>());

            Assert.Null(@event.GetClass<SessionSeries>());
            Assert.NotNull(@event.GetClass<Event>());
        }
    }
}
