using Newtonsoft.Json;
using OpenActive.NET;
using OpenActive.NET.Rpde.Version1;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xunit;
using Xunit.Abstractions;

namespace OpenActive.NET.Test
{
    // https://developers.google.com/search/docs/data-types/events
    public class RPDETest
    {
        private readonly ITestOutputHelper output;

        public RPDETest(ITestOutputHelper output)
        {
            this.output = output;
        }

        private static readonly SessionSeries @event = new OpenActive.NET.SessionSeries()
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
            Offers = new List<Offer>() { new Offer()
            {
                Url = new Uri("https://www.example.com/event_offer/12345_201803180430"),
                Price = 30,
                PriceCurrency = "USD",
                ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(-8))
            } },
            AttendeeInstructions = "Ensure you bring trainers and a bottle of water.",
            MeetingPoint = ""
        };

        private static readonly SessionSeries @fullFatSessionSeries = new SessionSeries
        {
            Category = new List<string> { "" },
            Name = "",
            AttendeeInstructions = "",
            Id = new Uri("https://example.com"),
            Identifier = (string)"",
            Duration = TimeSpan.FromHours(5),
            GenderRestriction = GenderRestrictionType.MaleOnly,
            EventSchedule = new List<Schedule> {
                new PartialSchedule()
                {
                    StartDate = "",
                    EndDate = "",
                    StartTime = DateTimeOffset.Now,
                    EndTime = DateTimeOffset.Now,
                    Duration = TimeSpan.FromHours(2),
                    TimeZone = "",
                    ByDay = new List<string>()
                }
            },
            // **** Price mapping ****
            Offers = new List<Offer> {
                new Offer
                {
                    Name = "",
                    Identifier = (string)"",
                    Description = "",
                    Price = 0,
                    AgeRange = new QuantitativeValue
                    {
                        MinValue = 0,
                        MaxValue = 2
                    },
                    PriceCurrency = "",
                    AcceptedPaymentMethod = new List<PaymentMethod> { PaymentMethod.Cash }
                }
            },
            // **** Place mapping ****
            Location = new Place
            {
                Identifier = (string)"",
                Address = new PostalAddress
                {
                    StreetAddress = "",
                    AddressLocality = "",
                    AddressRegion = "",
                    PostalCode = "",
                    AddressCountry = ""
                },
                Geo = new GeoCoordinates
                {
                    Latitude = (decimal)0.1,
                    Longitude = (decimal)0.2
                },
                Url = new Uri("https://example.com"),
                Name = "",
                Telephone = "",
                //Email = "",
                FormattedDescription = "",
                Description = "",
                Image = new List<ImageObject> {
                    new ImageObject() { Url = new Uri("https://example.com"), }
                },
                AmenityFeature = new List<LocationFeatureSpecification>
                {
                    new Showers
                    {
                        Name = "Showers",
                        Value = true
                    }
                }
            },
            AccessibilityInformation = "",
            IsWheelchairAccessible = false,
            Description = "",
            FormattedDescription = "",
            IsCoached = false,
            Video = new List<Schema.NET.VideoObject> { new Schema.NET.VideoObject() { Url = new Uri("https://example.com") } },
            AccessibilitySupport = new List<Concept> { },
            Level = new List<string> { "" },
            Image = new List<ImageObject> { new ImageObject() { Url = new Uri("https://example.com") } },
            Programme = new Brand()
              {
                  Id = new Uri("https://example.com"),
                  Name = "",
                  Description = "",
                  Url = new Uri("https://example.com"),
                  Logo =  new ImageObject() { Url = new Uri("https://example.com") },
                  Video = new List<Schema.NET.VideoObject> { new Schema.NET.VideoObject() { Url = new Uri("https://example.com") } }
              },
            AgeRange = new QuantitativeValue()
              {
                  Name = null,
                  MaxValue = 0,
                  MinValue = 2
              },
            Activity = new List<Concept>() {
                    new Concept()
                    {
                        Id = new Uri("https://example.com"),
                        PrefLabel = "",
                        InScheme = new Uri("https://example.com")
                    },
                    new Concept()
                    {
                        Id = new Uri("https://example.com"),
                        PrefLabel = "",
                        InScheme = new Uri("https://example.com")
                    },
                    new Concept()
                    {
                        Id = new Uri("https://example.com"),
                        PrefLabel = "",
                        InScheme = new Uri("https://example.com")
                    }
                },
            Organizer = new Organization()
            {
                Name = "",
                LegalName = "",
                Description = "",
                FormattedDescription = "",
                Telephone = "",
                Url = new Uri("https://example.com"),
                Logo = new ImageObject() { Url = new Uri("https://example.com") },
                Video = new List<Schema.NET.VideoObject> { new Schema.NET.VideoObject() { Url = new Uri("https://example.com") } },
                Email = "",
                SameAs = new List<Uri>() { new Uri("https://example.com"), new Uri("https://example.com") }
            }
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

        private readonly List<RpdeItem<string, SessionSeries>> @feedItems = new List<RpdeItem<string, SessionSeries>>
        {
            new RpdeItem<string, SessionSeries>
            {
                Id = "2",
                Modified = 4,
                State = RpdeState.Updated,
                Kind = RpdeKind.SessionSeries,
                Data = @event
            },
            new RpdeItem<string, SessionSeries>
            {
                Id = "1",
                Modified = 5,
                State = RpdeState.Deleted,
                Kind = RpdeKind.SessionSeries,
                Data = null
            }
        };

        

        [Fact]
        public void ToString_EventGoogleStructuredData_ReturnsExpectedJsonLd() {
            var feed = new RpdeBody<string, SessionSeries>("https://www.example.com/feed", 1, "1", @feedItems);

            output.WriteLine(feed.ToString());
            Assert.Equal(this.json, feed.ToString());
        }

        [Fact]
        public void ToString_EventEmptyStings_ReturnsExpectedJsonLd()
        {
            output.WriteLine(@fullFatSessionSeries.ToOpenActiveString());
            Assert.Equal(this.json, @fullFatSessionSeries.ToOpenActiveString());
        }

        [Fact]
        public void ToString_RpdeBodyUnorderedModified_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<string, SessionSeries>("https://www.example.com/feed", 1, "1", new List<RpdeItem<string, SessionSeries>>
            {
                new RpdeItem<string, SessionSeries>
                {
                    Id = "2",
                    Modified = 5,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<string, SessionSeries>
                {
                    Id = "1",
                    Modified = 4,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("Items must be ordered", ex.Message);
        }

        [Fact]
        public void ToString_RpdeBodyUnorderedID_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<string, SessionSeries>("https://www.example.com/feed", 1, "1", new List<RpdeItem<string, SessionSeries>>
            {
                new RpdeItem<string, SessionSeries>
                {
                    Id = "2",
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<string, SessionSeries>
                {
                    Id = "1",
                    Modified = 4,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("Items must be ordered", ex.Message);
        }

        [Fact]
        public void ToString_RpdeBodyDeletedWithData_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<string, SessionSeries>("https://www.example.com/feed", 1, "1", new List<RpdeItem<string, SessionSeries>>
            {
                new RpdeItem<string, SessionSeries>
                {
                    Id = "2",
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<string, SessionSeries>
                {
                    Id = "1",
                    Modified = 5,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                }
            })).ToString());

            
            Assert.StartsWith("Deleted items must not contain data", ex.Message);
        }


        [Fact]
        public void ToString_RpdeBodyFirstItemInFeed_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<string, SessionSeries>("https://www.example.com/feed", 4, "2", new List<RpdeItem<string, SessionSeries>>
            {
                new RpdeItem<string, SessionSeries>
                {
                    Id = "2",
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<string, SessionSeries>
                {
                    Id = "1",
                    Modified = 5,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("First item in the feed must never have same", ex.Message);
        }






        [Fact]
        public void ToString_RpdeBodyIntUnorderedModified_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 1, 1, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 5,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 4,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("Items must be ordered", ex.Message);
        }

        [Fact]
        public void ToString_RpdeBodyIntUnorderedID_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 1, 1, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 4,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("Items must be ordered", ex.Message);
        }

        [Fact]
        public void ToString_RpdeBodyIntDeletedWithData_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 1, 1, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 5,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                }
            })).ToString());

            
            Assert.StartsWith("Deleted items must not contain data", ex.Message);
        }


        [Fact]
        public void ToString_RpdeBodyIntFirstItemInFeed_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 4, 2, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 5,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("First item in the feed must never have same", ex.Message);
        }









        [Fact]
        public void ToString_RpdeBodyChangeNumberUnorderedModified_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 1, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 5,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 4,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("Items must be ordered", ex.Message);
        }

        [Fact]
        public void ToString_RpdeBodyChangeNumberUnorderedID_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 1, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 4,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("Items must be ordered", ex.Message);
        }

        [Fact]
        public void ToString_RpdeBodyChangeNumberDeletedWithData_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 1, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 5,
                    State = RpdeState.Deleted,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                }
            })).ToString());

            
            Assert.StartsWith("Deleted items must not contain data", ex.Message);
        }


        [Fact]
        public void ToString_RpdeBodyChangeNumberFirstItemInFeed_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 4, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 5,
                    Kind = RpdeKind.SessionSeries,
                    State = RpdeState.Deleted,
                    Data = null
                }
            })).ToString());

            
            Assert.StartsWith("First item in the feed must never have same", ex.Message);
        }


        [Fact]
        public void ToString_RpdeBodyMissingPros_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdeBody<int, SessionSeries>("https://www.example.com/feed", 1, new List<RpdeItem<int, SessionSeries>>
            {
                new RpdeItem<int, SessionSeries>
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Data = @event
                },
                new RpdeItem<int, SessionSeries>
                {
                    Id = 1,
                    Modified = 5,
                    State = RpdeState.Deleted,
                    Data = null
                }
            })).ToString());

            Assert.StartsWith("All RPDE feed items must include", ex.Message);
        }


    }
}
