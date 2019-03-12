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

        private readonly SessionSeries @event = new OpenActive.NET.SessionSeries()
        {
            Name = "Virtual BODYPUMP",
            Description = "This is the virtual version of the original barbell class, which will help you get lean, toned and fit - fast. Les Mills™ Virtual classes are designed for people who cannot get access to our live classes or who want to get a ‘taste’ of a Les Mills™ class before taking a live class with an instructor. The classes are played on a big video screen, with dimmed lighting and pumping surround sound, and are led onscreen by the people who actually choreograph the classes.",
            Duration = TimeSpan.FromDays(1),
            StartDate = new DateTimeOffset(2017, 4, 24, 19, 30, 0, TimeSpan.FromHours(-8)),
            Location = new Place()
            {
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
            Offers = new List<Offer>() { new IndicativeOffer()
            {
                Url = new Uri("https://www.example.com/event_offer/12345_201803180430"), 
                Price = 30, 
                PriceCurrency = "USD", 
                ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(-8))
            } },
            AttendeeInstructions = "Ensure you bring trainers and a bottle of water.",
            MeetingPoint = ""
        };

        private readonly string json =
        "{" +
            "\"@context\":\"https://openactive.io/\"," +
            "\"type\":\"SessionSeries\"," +
            "\"name\":\"Jan Lieberman Concert Series: Journey in Jazz\"," +
            "\"description\":\"Join us for an afternoon of Jazz with Santa Clara resident and pianist Andy Lagunoff. Complimentary food and beverages will be served.\"," +
            "\"image\":\"http://www.example.com/event_image/12345\"," +
            "\"duration\":\"P1D\"," +
            "\"location\":{" +
                "\"type\":\"Place\"," +
                "\"name\":\"Santa Clara City Library, Central Park Library\"," +
                "\"address\":{" +
                    "\"type\":\"PostalAddress\"," +
                    "\"addressCountry\":\"US\"," +
                    "\"addressLocality\":\"Santa Clara\"," +
                    "\"addressRegion\":\"CA\"," +
                    "\"postalCode\":\"95051\"," +
                    "\"streetAddress\":\"2635 Homestead Rd\"" +
                "}" +
            "}," +
            "\"offers\":{" +
                "\"type\":\"Offer\"," +
                "\"url\":\"https://www.example.com/event_offer/12345_201803180430\"," +
                "\"availability\":\"http://schema.org/InStock\"," +
                "\"price\":30.0," +
                "\"priceCurrency\":\"USD\"," +
                "\"validFrom\":\"2017-01-20T16:20:00-08:00\"" +
            "}," +
            "\"performer\":{" +
                "\"type\":\"Person\"," +
                "\"name\":\"Andy Lagunoff\"" +
            "}," +
            "\"startDate\":\"2017-04-24T19:30:00-08:00\"," +
            "\"endDate\":\"2017-04-24T23:00:00-08:00\"," +
            "\"attendeeInstructions\":\"fun!\"" +
        "}";

        [Fact]
        public void ToString_EventGoogleStructuredData_ReturnsExpectedJsonLd() {
            output.WriteLine(this.@event.ToOpenActiveString());
            Assert.Equal(this.json, this.@event.ToOpenActiveString());
        }

        [Fact]
        public void ToString_EventAccessor()
        {
            output.WriteLine(this.@event.ToOpenActiveString());
            Assert.Equal("Santa Clara City Library, Central Park Library", this.@event.Location.Name);
        }

        [Fact]
        public void ToString_OfferCast()
        {
            var ev = new Event
            {
                Offers = (new List<IndicativeOffer>() { new IndicativeOffer()
                {
                    Url = new Uri("https://www.example.com/event_offer/12345_201803180430"),
                    Price = 30,
                    PriceCurrency = "USD",
                    ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(-8))
                } }).Cast<Offer>().ToList()
            };
            
            output.WriteLine(ev.ToOpenActiveString());
            Assert.Equal("Santa Clara City Library, Central Park Library", ev.ToOpenActiveString());
        }

    }
}
