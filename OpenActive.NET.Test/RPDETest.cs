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
                Price = 0,
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
                    StartTime = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(0)),
                    EndTime = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(0)),
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
                  Name = (string)null,
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
        "{\"@context\":[\"https://openactive.io/\",\"https://openactive.io/ns-beta\"],\"@type\":\"SessionSeries\",\"@id\":\"https://example.com\",\"accessibilitySupport\":[],\"activity\":[{\"@type\":\"Concept\",\"@id\":\"https://example.com\",\"inScheme\":\"https://example.com\"},{\"@type\":\"Concept\",\"@id\":\"https://example.com\",\"inScheme\":\"https://example.com\"},{\"@type\":\"Concept\",\"@id\":\"https://example.com\",\"inScheme\":\"https://example.com\"}],\"ageRange\":{\"@type\":\"QuantitativeValue\",\"maxValue\":0,\"minValue\":2},\"category\":[\"\"],\"duration\":\"PT5H\",\"eventSchedule\":[{\"@type\":\"PartialSchedule\",\"duration\":\"PT2H\",\"endTime\":\"16:20\",\"startTime\":\"16:20\"}],\"genderRestriction\":\"https://openactive.io/MaleOnly\",\"image\":[{\"@type\":\"ImageObject\",\"url\":\"https://example.com\"}],\"isCoached\":false,\"level\":[\"\"],\"location\":{\"@type\":\"Place\",\"address\":{\"@type\":\"PostalAddress\"},\"amenityFeature\":[{\"@type\":\"Showers\",\"name\":\"Showers\",\"value\":true}],\"geo\":{\"@type\":\"GeoCoordinates\",\"latitude\":0.1,\"longitude\":0.2},\"image\":[{\"@type\":\"ImageObject\",\"url\":\"https://example.com\"}],\"url\":\"https://example.com\"},\"offers\":[{\"@type\":\"Offer\",\"acceptedPaymentMethod\":[\"http://purl.org/goodrelations/v1#Cash\"],\"ageRange\":{\"@type\":\"QuantitativeValue\",\"maxValue\":2,\"minValue\":0},\"price\":0}],\"organizer\":{\"@type\":\"Organization\",\"logo\":{\"@type\":\"ImageObject\",\"url\":\"https://example.com\"},\"sameAs\":[\"https://example.com\",\"https://example.com\"],\"url\":\"https://example.com\",\"beta:video\":[{\"@type\":\"VideoObject\",\"url\":\"https://example.com\"}]},\"programme\":{\"@type\":\"Brand\",\"@id\":\"https://example.com\",\"logo\":{\"@type\":\"ImageObject\",\"url\":\"https://example.com\"},\"url\":\"https://example.com\",\"beta:video\":[{\"@type\":\"VideoObject\",\"url\":\"https://example.com\"}]},\"beta:video\":[{\"@type\":\"VideoObject\",\"url\":\"https://example.com\"}],\"beta:isWheelchairAccessible\":false}";

        private readonly List<RpdeItem> @feedItems = new List<RpdeItem>
        {
            new RpdeItem
            {
                Id = "2",
                Modified = 4,
                State = RpdeState.Updated,
                Kind = RpdeKind.SessionSeries,
                Data = @event
            },
            new RpdeItem
            {
                Id = "1",
                Modified = 5,
                State = RpdeState.Deleted,
                Kind = RpdeKind.SessionSeries,
                Data = null
            }
        };

        private readonly string jsonRpde =
        "{\"next\":\"https://www.example.com/feed?afterTimestamp=5&afterId=1\",\"items\":[{\"state\":\"updated\",\"kind\":\"SessionSeries\",\"id\":\"2\",\"modified\":4,\"data\":{\"@context\":\"https://openactive.io/\",\"@type\":\"SessionSeries\",\"name\":\"Virtual BODYPUMP\",\"description\":\"This is the virtual version of the original barbell class, which will help you get lean, toned and fit - fast. Les Mills™ Virtual classes are designed for people who cannot get access to our live classes or who want to get a ‘taste’ of a Les Mills™ class before taking a live class with an instructor. The classes are played on a big video screen, with dimmed lighting and pumping surround sound, and are led onscreen by the people who actually choreograph the classes.\",\"attendeeInstructions\":\"Ensure you bring trainers and a bottle of water.\",\"duration\":\"P1D\",\"image\":[{\"@type\":\"ImageObject\",\"url\":\"http://www.example.com/event_image/12345\"}],\"location\":{\"@type\":\"Place\",\"name\":\"Santa Clara City Library, Central Park Library\",\"address\":{\"@type\":\"PostalAddress\",\"addressCountry\":\"US\",\"addressLocality\":\"Santa Clara\",\"addressRegion\":\"CA\",\"postalCode\":\"95051\",\"streetAddress\":\"2635 Homestead Rd\"}},\"offers\":[{\"@type\":\"Offer\",\"price\":0,\"priceCurrency\":\"USD\",\"url\":\"https://www.example.com/event_offer/12345_201803180430\",\"validFrom\":\"2017-01-20T16:20:00-08:00\"}],\"startDate\":\"2017-04-24T19:30:00-08:00\",\"endDate\":\"2017-04-24T23:00:00-08:00\"}},{\"state\":\"deleted\",\"kind\":\"SessionSeries\",\"id\":\"1\",\"modified\":5}],\"license\":\"https://creativecommons.org/licenses/by/4.0/\"}";

        private readonly string jsonRpdeEveryoneActive =
        "{\"next\":\"https://opendata.leisurecloud.live/api/feeds/EveryoneActive-test-session-series?afterTimestamp=28577192&afterId=1217CRP17000217\",\"items\":[{\"state\":\"updated\",\"kind\":\"SessionSeries\",\"id\" :\"1502CMX20000216\",\"modified\":15529138,\"data\":{\"@context\":\"https://openactive.io/\",\"type\":\"SessionSeries\",\"id\":\"https://tst.myeveryoneactive.com/OpenActive/api/session-series/1502CMX20000216\",\"identifier\":\"1502CMX20000216\",\"name\":\"Mega Mix Tue20.00\",\"category\":[\"Group Exercise 16+ Yrs\"],\"duration\":\"PT1H\",\"eventSchedule\":[{\"type\":\"PartialSchedule\",\"byDay\":[\"http://schema.org/Tuesday\"],\"duration\":\"PT1H\",\"endTime\":\"21:00\",\"startDate\":\"2016-06-21\",\"endDate\":\"2022-12-31\",\"startTime\":\"20:00\"}],\"location\":{\"type\":\"Place\",\"identifier\":\"0150\",\"name\":\"Surrey Docks Water Sports\",\"address\":{\"type\":\"PostalAddress\"}},\"organizer\":{\"type\":\"Organization\",\"name\":\"EveryoneActive\",\"legalName\":\"EveryoneActive\"}}}],\"license\":\"https://creativecommons.org/licenses/by/4.0/\"}";

        [Fact]
        public void ToString_EventGoogleStructuredData_ReturnsExpectedJsonLd() {
            var feed = new RpdePage(new Uri("https://www.example.com/feed"), 1, "1", @feedItems);

            output.WriteLine(feed.ToString());
            Assert.Equal(this.jsonRpde, feed.ToString());
        }

        [Fact]
        public void DeserializeRpdePageEveryoneActive()
        {
            var page = OpenActiveSerializer.DeserializeRpdePage(this.jsonRpdeEveryoneActive);
            var json = OpenActiveSerializer.SerializeRpdePage(page);

            output.WriteLine(json);
            Assert.Equal(this.jsonRpdeEveryoneActive.Replace("http://", "https://").Replace("\"type\"", "\"@type\"").Replace("\"id\":", "\"@id\":").Replace("\"id\" :", "\"id\":"), json);
        }

        [Fact]
        public void DeserializeRpdePage()
        {
            var page = OpenActiveSerializer.DeserializeRpdePage(this.jsonRpde);
            var json = OpenActiveSerializer.SerializeRpdePage(page);

            output.WriteLine(json);
            Assert.Equal(this.jsonRpde, json);
        }

        [Fact]
        public void ToString_EventEmptyStings_ReturnsExpectedJsonLd()
        {
            output.WriteLine(@fullFatSessionSeries.ToString());
            Assert.Equal(this.json, @fullFatSessionSeries.ToString());
        }

        [Fact]
        public void ToString_RpdeBodyUnorderedModified_ReturnsExpectedException()
        {
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, "1", new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = "2",
                    Modified = 5,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, "1", new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = "2",
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, "1", new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = "2",
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 4, "2", new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = "2",
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, 1, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 5,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, 1, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, 1, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 4, 2, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 5,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 4, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Kind = RpdeKind.SessionSeries,
                    Data = @event
                },
                new RpdeItem
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
            Exception ex = Assert.Throws<SerializationException>(() => (new RpdePage(new Uri("https://www.example.com/feed"), 1, new List<RpdeItem>
            {
                new RpdeItem
                {
                    Id = 2,
                    Modified = 4,
                    State = RpdeState.Updated,
                    Data = @event
                },
                new RpdeItem
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
