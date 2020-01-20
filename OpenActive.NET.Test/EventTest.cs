using Newtonsoft.Json;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace OpenActive.NET.Test
{
    // https://developers.google.com/search/docs/data-types/events
    public class EventTest
    {
        private readonly ITestOutputHelper output;

        public EventTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        private static readonly string NullString = null;
        private static readonly RequiredStatusType? NullRequiredStatusType = null;
        private static readonly Person NullPerson = null;

        private readonly SessionSeries @event = new OpenActive.NET.SessionSeries()
        {
            Name = "Virtual BODYPUMP",
            Description = "This is the virtual version of the original barbell class, which will help you get lean, toned and fit - fast. Les Mills™ Virtual classes are designed for people who cannot get access to our live classes or who want to get a ‘taste’ of a Les Mills™ class before taking a live class with an instructor. The classes are played on a big video screen, with dimmed lighting and pumping surround sound, and are led onscreen by the people who actually choreograph the classes.",
            Duration = TimeSpan.FromDays(1),
            StartDate = new DateTimeOffset(2017, 4, 24, 19, 30, 0, TimeSpan.FromHours(-8)),
            Location = new Place()
            {
                Id = null, // Should be ignored
                Name = "Santa Clara City Library, Central Park Library",
                Address = new PostalAddress()
                {
                    StreetAddress = "2635 Homestead Rd",
                    AddressLocality = "Santa Clara",
                    PostalCode = "95051",
                    AddressRegion = "CA",
                    AddressCountry = "US"
                }
            },
            Image = new List<ImageObject>() { new ImageObject { Url = new Uri("http://www.example.com/event_image/12345") } },
            EndDate = new DateTimeOffset(2017, 4, 24, 23, 0, 0, TimeSpan.FromHours(-8)),
            Offers = new List<Offer>() { new Offer()
            {
                AdvanceBooking = NullRequiredStatusType,
                Url = new Uri("https://www.example.com/event_offer/12345_201803180430"),
                Price = 30,
                PriceCurrency = "USD",
                ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(-8)),
                Category = NullString,
                OpenBookingFlowRequirement = new List<OpenBookingFlowRequirement>
                {
                    OpenBookingFlowRequirement.OpenBookingAttendeeDetails
                }
            } },
            EventSchedule = new List<Schedule>
            {
                new PartialSchedule
                {
                    ByDay = new List<Schema.NET.DayOfWeek>
                    {
                        Schema.NET.DayOfWeek.Tuesday,
                        Schema.NET.DayOfWeek.Sunday
                    },
                    Duration = new TimeSpan(1, 0, 0),
                    RepeatFrequency = new TimeSpan(7,0,0,0,0),
                    StartDate = "2018-10-19",
                    EndDate = "2018-11-04",
                    StartTime = new DateTimeOffset(1,1,1,8,30,00, new TimeSpan()),
                    EndTime = new DateTimeOffset(1,1,1,9,30,00, new TimeSpan())
                },
            },
            Organizer = NullPerson,
            AttendeeInstructions = "Ensure you bring trainers and a bottle of water.",
            MeetingPoint = "",
            AccessibilityInformation = NullString
        };

        private readonly string json =
        "{" +
            "\"@context\":\"https://openactive.io/\"," +
            "\"@type\":\"SessionSeries\"," +
            "\"name\":\"Virtual BODYPUMP\"," +
            "\"description\":\"This is the virtual version of the original barbell class, which will help you get lean, toned and fit - fast. Les Mills™ Virtual classes are designed for people who cannot get access to our live classes or who want to get a ‘taste’ of a Les Mills™ class before taking a live class with an instructor. The classes are played on a big video screen, with dimmed lighting and pumping surround sound, and are led onscreen by the people who actually choreograph the classes.\"," +
            "\"attendeeInstructions\":\"Ensure you bring trainers and a bottle of water.\"," +
            "\"duration\":\"P1D\"," +
            "\"eventSchedule\":[" +
              "{" +
                "\"@type\":\"PartialSchedule\"," +
                "\"byDay\":[" +
                  "\"https://schema.org/Tuesday\"," +
                  "\"https://schema.org/Sunday\"" +
                "]," +
                "\"duration\":\"PT1H\"," +
                "\"endTime\":\"09:30\"," +
                "\"repeatFrequency\":\"P7D\"," +
                "\"startDate\":\"2018-10-19\"," +
                "\"endDate\":\"2018-11-04\"," +
                "\"startTime\":\"08:30\"" +
              "}" +
            "]," +
            "\"image\":[" +
                "{" +
                    "\"@type\":\"ImageObject\"," +
                    "\"url\":\"http://www.example.com/event_image/12345\"" +
                "}" +
            "]," +
            "\"location\":{" +
                "\"@type\":\"Place\"," +
                "\"name\":\"Santa Clara City Library, Central Park Library\"," +
                "\"address\":{" +
                    "\"@type\":\"PostalAddress\"," +
                    "\"addressCountry\":\"US\"," +
                    "\"addressLocality\":\"Santa Clara\"," +
                    "\"addressRegion\":\"CA\"," +
                    "\"postalCode\":\"95051\"," +
                    "\"streetAddress\":\"2635 Homestead Rd\"" +
                "}" +
            "}," +
            "\"offers\":[" +
                "{" +
                    "\"@type\":\"Offer\"," +
                    "\"openBookingFlowRequirement\":[" +
                        "\"https://openactive.io/OpenBookingAttendeeDetails\"" +
                    "]," +
                    "\"price\":30.0," +
                    "\"priceCurrency\":\"USD\"," +
                    "\"url\":\"https://www.example.com/event_offer/12345_201803180430\"," +
                    "\"validFrom\":\"2017-01-20T16:20:00-08:00\"" +
                "}" +
            "]," +
            "\"startDate\":\"2017-04-24T19:30:00-08:00\"," +
            "\"endDate\":\"2017-04-24T23:00:00-08:00\"" +
        "}";

        [Fact]
        public void ToString_EventGoogleStructuredData_ReturnsExpectedJsonLd() {
            output.WriteLine(this.@event.ToString());
            Assert.Equal(this.json, this.@event.ToString());
        }

        [Fact]
        public void SessionSeries_EncodeDecode()
        {
            // Should recognise subclasses of Event when deserialising
            var decode = OpenActiveSerializer.Deserialize<SessionSeries>(json);
            var encode = OpenActiveSerializer.Serialize(decode);

            output.WriteLine(json);
            output.WriteLine(encode);
            Assert.Equal(json, encode);
        }

        [Fact]
        public void RootTypeMismatchError()
        {
            var rootSessionSeriesJson = "{" +
            "\"@context\":\"https://openactive.io/\"," +
            "\"@type\":\"SessionSeries\"," +
            "\"name\":\"Virtual BODYPUMP\"" +
            "}";

            var rootEventJson = "{" +
            "\"@context\":\"https://openactive.io/\"," +
            "\"@type\":\"Event\"," +
            "\"name\":\"Virtual BODYPUMP\"" +
            "}";

            // Should recognise subclasses of Event when deserialising
            Assert.IsType<SessionSeries>(OpenActiveSerializer.Deserialize<SessionSeries>(rootSessionSeriesJson));
            Assert.IsType<SessionSeries>(OpenActiveSerializer.Deserialize<Event>(rootSessionSeriesJson));
            Assert.IsType<Event>(OpenActiveSerializer.Deserialize<Event>(rootEventJson));
            
            // Note assignment fails if attempting to cast downwards
            Assert.Null(OpenActiveSerializer.Deserialize<SessionSeries>(rootEventJson));

            //var encode = OpenActiveSerializer.Serialize(decode);
        }

        [Fact]
        public void ToString_EventAccessor()
        {
            output.WriteLine(this.@event.ToString());
            Assert.Equal("Santa Clara City Library, Central Park Library", this.@event.Location.Name);
        }

        [Fact]
        public void ToString_OfferCast()
        {
            var json =
            "{" + 
                "\"@context\":[" +
                    "\"https://openactive.io/\"," +
                    "\"https://openactive.io/ns-beta\"" +
                "]," +
                "\"@type\":\"Event\"," +
                "\"offers\":[" +
                    "{" +
                        "\"@type\":\"beta:IndicativeOffer\"," +
                        "\"price\":0," +
                        "\"priceCurrency\":\"USD\"," +
                        "\"url\":\"https://www.example.com/event_offer/12345_201803180430\"," +
                        "\"validFrom\":\"2017-01-20T16:20:00-08:00\"" +
                    "}" +
                "]" +
            "}";

            var ev = new Event
            {
                Offers = (new List<IndicativeOffer>() { new IndicativeOffer()
                {
                    Url = new Uri("https://www.example.com/event_offer/12345_201803180430"),
                    Price = 0,
                    PriceCurrency = "USD",
                    ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(-8))
                } }).Cast<Offer>().ToList()
            };
            
            output.WriteLine(ev.ToString());
            Assert.Equal(json, ev.ToString());
        }

        [Fact]
        public void ToString_EncodeDecode ()
        {
            var original = "{\"@context\":\"https://openactive.io/\",\"@type\":\"Concept\",\"@id\":\"https://openactive.io/facility-types#37bbed12-270b-42b1-9af2-70f0273990dd\",\"inScheme\":\"https://openactive.io/facility-types\",\"prefLabel\":\"Grass\"}";
            var decode = OpenActiveSerializer.Deserialize<Concept>(original);
            var encode = OpenActiveSerializer.Serialize(decode);

            //output.WriteLine(decode.Id?.ToString());
            output.WriteLine(original);
            output.WriteLine(encode);
            //Assert.Equal("https://openactive.io/facility-types#37bbed12-270b-42b1-9af2-70f0273990dd", decode.Id?.ToString());
            Assert.Equal(original, encode);
        }



        [Fact]
        public void ToString_EncodeDecodeList()
        {
            var originalList = "[{\"@type\":\"Concept\",\"@id\":\"https://openactive.io/facility-types#37bbed12-270b-42b1-9af2-70f0273990dd\",\"inScheme\":\"https://openactive.io/facility-types\",\"prefLabel\":\"Grass\"}]";
            var decodeList = OpenActiveSerializer.DeserializeList<Concept>(originalList);
            var encodeList = OpenActiveSerializer.SerializeList(decodeList);

            output.WriteLine(originalList);
            output.WriteLine(encodeList);
            //Assert.Equal("https://openactive.io/facility-types#37bbed12-270b-42b1-9af2-70f0273990dd", decodeList.First().Id?.ToString());
            Assert.Equal(originalList, encodeList);
        }

        public List<Concept> concepts = new List<Concept>
        {
            new Concept
            {
                Id = new Uri("https://openactive.io/facility-types#37bbed12-270b-42b1-9af2-70f0273990dd"),
                PrefLabel = "Grass",
                InScheme = new Uri("https://openactive.io/facility-types")
            }
        };


        [Fact]
        public void ToString_OfferEncodeDecode()
        {
            var offer = new Offer()
            {
                Id = new Uri("https://www.example.com/event_offer/12345_201803180430"),
                Url = new Uri("https://www.example.com/event_offer/12345_201803180430"),
                Price = 0,
                PriceCurrency = "USD",
                ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(0))
            };

            var encode = offer.ToString();

            var decode = OpenActiveSerializer.Deserialize<Offer>(encode);

            var reencode = decode.ToString();

            output.WriteLine(encode);
            output.WriteLine(reencode);
            Assert.Equal(encode, reencode);
        }


    }
}
