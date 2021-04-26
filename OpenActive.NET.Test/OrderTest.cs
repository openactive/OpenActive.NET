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
    public class OrderTest
    {
        private readonly ITestOutputHelper output;

        public OrderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        private static readonly string NullString = null;
        private static readonly RequiredStatusType? NullRequiredStatusType = null;
        private static readonly Person NullPerson = null;

        private readonly SessionSeries @event = new OpenActive.NET.SessionSeries()
        {
            Name = "Virtual BODYPUMP",
            Description = "This is the virtual version of the original barbell class, which will help you get lean, toned and fit - fast. Les Mills? Virtual classes are designed for people who cannot get access to our live classes or who want to get a ?taste? of a Les Mills? class before taking a live class with an instructor. The classes are played on a big video screen, with dimmed lighting and pumping surround sound, and are led onscreen by the people who actually choreograph the classes.",
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
                OpenBookingInAdvance = NullRequiredStatusType, // Test that null types are deserialised correctly
                Url = new Uri("https://www.example.com/event_offer/12345_201803180430"),
                Price = 30,
                PriceCurrency = "USD",
                ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(-8)),
                Category = NullString
            } },
            Organizer = NullPerson,
            AttendeeInstructions = "Ensure you bring trainers and a bottle of water.",
            MeetingPoint = "",
            AccessibilityInformation = NullString
        };

        private readonly string json =
        "{" +
            "\"@context\":\"https://openactive.io/\"," +
            "\"@type\":\"OrderQuote\"," +
            "\"broker\":{" +
            "\"@type\":\"Organization\"," +
            "\"name\":\"MyFitnessApp\"," +
            "\"description\":\"A fitness app for all the community\"," +
            "\"address\":{" +
                "\"@type\":\"PostalAddress\"," +
                "\"addressCountry\":\"GB\"," +
                "\"addressLocality\":\"Village East\"," +
                "\"addressRegion\":\"Middlesbrough\"," +
                "\"postalCode\":\"TS4 3AE\"," +
                "\"streetAddress\":\"Alan Peacock Way\"" +
            "}," +
            "\"logo\":{" +
                "\"@type\":\"ImageObject\"," +
                "\"url\":\"http://data.myfitnessapp.org.uk/images/logo.png\"" +
            "}," +
            "\"url\":\"https://myfitnessapp.example.com\"" +
            "}," +
            "\"brokerRole\":\"https://openactive.io/ResellerBroker\"," +
            "\"customer\":{" +
            "\"@type\":\"Person\"," +
            "\"email\":\"geoffcapes@example.com\"," +
            "\"familyName\":\"Capes\"," +
            "\"givenName\":\"Geoff\"," +
            "\"telephone\":\"020 811 8055\"" +
            "}," +
            "\"orderedItem\":[" +
            "{" +
                "\"@type\":\"OrderItem\"," +
                "\"acceptedOffer\":{" +
                "\"@type\":\"Offer\"," +
                "\"@id\":\"https://www.example.com/offer/1\"" +
                "}," +
                "\"orderedItem\":{" +
                "\"@type\":\"ScheduledSession\"," +
                "\"@id\":\"https://www.example.com/sessionseries/1\"" +
                "}" +
            "}" +
            "]," +
            "\"seller\":{" +
            "\"@type\":\"Organization\"," +
            "\"@id\":\"https://www.example.com/seller/1\"" +
            "}" +
        "}";

        [Fact]
        public void OrderQuote_Deserialize_Accessors()
        {
            OrderQuote orderQuote = OpenActiveSerializer.Deserialize<OrderQuote>(json);
            Assert.Equal(new Uri("https://www.example.com/offer/1"), orderQuote.OrderedItem[0].AcceptedOffer.Object.Id);
            Assert.Equal(new Uri("https://www.example.com/sessionseries/1"), orderQuote.OrderedItem[0].OrderedItem.Object.Id);
            Assert.Equal(new Uri("https://www.example.com/seller/1"), orderQuote.Seller.Object.Id);
            Assert.Equal(BrokerType.ResellerBroker, orderQuote.BrokerRole);
            Assert.Equal("Alan Peacock Way", orderQuote?.Broker?.Address?.StreetAddress);
            Assert.Equal("Geoff", orderQuote.Customer.GivenName);
        }

        [Fact]
        public void OrderQuote_EncodeDecode()
        {
            var decode = OpenActiveSerializer.Deserialize<OrderQuote>(json);
            var encode = OpenActiveSerializer.Serialize(decode);

            // Should cast this to ScheduledSession instead of Event
            Assert.IsType<ScheduledSession>(decode.OrderedItem[0].OrderedItem.Object);

            output.WriteLine(json);
            output.WriteLine(encode);
            Assert.Equal(json, encode);
        }

        private readonly string complexJson = "{" +
            "\"@context\":\"https://openactive.io/\"," +
            "\"@type\":\"Order\"," +
            "\"@id\":\"https://example.com/api/orders/e11429ea-467f-4270-ab62-e47368996fe8\"," +
            "\"identifier\":\"e11429ea-467f-4270-ab62-e47368996fe8\"," +
            "\"bookingService\":{" +
                "\"@type\":\"BookingService\"," +
                "\"name\":\"Playwaze\"," +
                "\"termsOfService\":[" +
                    "{" +
                        "\"@type\":\"Terms\"," +
                        "\"url\":\"https://brokerexample.com/terms.html\"" +
                    "}" +
                "]," +
                "\"url\":\"http://www.playwaze.com\"" +
            "}," +
            "\"broker\":{" +
                "\"@type\":\"Organization\"," +
                "\"name\":\"MyFitnessApp\"," +
                "\"description\":\"A fitness app for all the community\"," +
                "\"address\":{" +
                    "\"@type\":\"PostalAddress\"," +
                    "\"addressCountry\":\"GB\"," +
                    "\"addressLocality\":\"Village East\"," +
                    "\"addressRegion\":\"Middlesbrough\"," +
                    "\"postalCode\":\"TS4 3AE\"," +
                    "\"streetAddress\":\"Alan Peacock Way\"" +
                "}," +
                "\"logo\":{" +
                    "\"@type\":\"ImageObject\"," +
                    "\"url\":\"http://data.myfitnessapp.org.uk/images/logo.png\"" +
                "}," +
                "\"url\":\"https://myfitnessapp.example.com\"" +
            "}," +
            "\"brokerRole\":\"https://openactive.io/AgentBroker\"," +
            "\"customer\":{" +
                "\"@type\":\"Person\"," +
                "\"email\":\"geoffcapes@example.com\"," +
                "\"familyName\":\"Capes\"," +
                "\"givenName\":\"Geoff\"," +
                "\"telephone\":\"020 811 8055\"" +
            "}," +
            "\"orderedItem\":[" +
            "{" +
                "\"@type\":\"OrderItem\"," +
                "\"@id\":\"https://example.com/api/orders/123e4567-e89b-12d3-a456-426655440000/order-items/1234\"," +
                "\"acceptedOffer\":{" +
                    "\"@type\":\"Offer\"," +
                    "\"@id\":\"https://example.com/events/452#/offers/878\"," +
                    "\"name\":\"Speedball winger position\"," +
                    "\"description\":\"Winger space for Speedball.\"," +
                    "\"allowCustomerCancellationFullRefund\":true," +
                    "\"latestCancellationBeforeStartDate\":\"P1D\"," +
                    "\"price\":0," +
                    "\"priceCurrency\":\"GBP\"," +
                    "\"validFromBeforeStartDate\":\"P6D\"" +
                "}," +
                "\"accessPass\":[" +
                    "{" +
                        "\"@type\":\"Barcode\"," +
                        "\"text\":\"0123456789\"" +
                    "}" +
                "]," +
                "\"orderedItem\":{" +
                    "\"@type\":\"ScheduledSession\"," +
                    "\"@id\":\"https://example.com/events/452/subEvents/132\"," +
                    "\"startDate\":\"2018-10-30T11:00:00+00:00\"," +
                    "\"identifier\":123," +
                    "\"endDate\":\"2018-10-30T12:00:00+00:00\"," +
                    "\"superEvent\":{" +
                        "\"@type\":\"SessionSeries\"," +
                        "\"@id\":\"https://example.com/events/452\"," +
                        "\"name\":\"Speedball\"," +
                        "\"location\":{" +
                            "\"@type\":\"Place\"," +
                            "\"identifier\":\"0140\"," +
                            "\"name\":\"Middlesbrough Sports Village\"," +
                            "\"address\":{" +
                                "\"@type\":\"PostalAddress\"," +
                                "\"addressCountry\":\"GB\"," +
                                "\"addressLocality\":\"Village East\"," +
                                "\"addressRegion\":\"Middlesbrough\"," +
                                "\"postalCode\":\"TS4 3AE\"," +
                                "\"streetAddress\":\"Alan Peacock Way\"" +
                            "}," +
                            "\"geo\":{" +
                                "\"@type\":\"GeoCoordinates\"," +
                                "\"latitude\":54.543964," +
                                "\"longitude\":-1.20978500000001" +
                            "}," +
                            "\"url\":\"https://www.everyoneactive.com/centres/Middlesbrough-Sports-Village\"" +
                        "}," +
                        "\"organizer\":{" +
                            "\"@type\":\"Organization\"," +
                            "\"name\":\"Central Speedball Association\"," +
                            "\"url\":\"http://www.speedball-world.com\"" +
                        "}" +
                    "}," +
                    "\"duration\":\"PT1H\"," +
                    "\"eventStatus\":\"https://schema.org/EventScheduled\"" +
                "}," +
                "\"orderItemStatus\":\"https://openactive.io/OrderItemConfirmed\"," +
                "\"unitTaxSpecification\":[" +
                    "{" +
                        "\"@type\":\"TaxChargeSpecification\"," +
                        "\"identifier\":[" +
                        "{" +
                            "\"@type\":\"PropertyValue\"," +
                            "\"name\":\"EUCODE\"," +
                            "\"value\":\"TC\"" +
                        "}," +
                        "{" +
                            "\"@type\":\"PropertyValue\"," +
                            "\"name\":\"UKCODE\"," +
                            "\"value\":\"EU0\"" +
                        "}" +
                        "]," +
                        "\"name\":\"VAT at 0% for EU transactions\"," +
                        "\"price\":1.0," +
                        "\"priceCurrency\":\"GBP\"," +
                        "\"rate\":0.2" +
                    "}" +
                "]" +
            "}" +
            "]," +
            "\"orderNumber\":\"AB000001\"," +
            "\"payment\":{" +
                "\"@type\":\"Payment\"," +
                "\"identifier\":\"1234567890npduy2f\"," +
                "\"name\":\"AcmeBroker Points\"" +
            "}," +
            "\"seller\":{" +
                "\"@type\":\"Organization\"," +
                "\"@id\":\"https://example.com/api/organisations/123\"," +
                "\"identifier\":\"CRUOZWJ1\"," +
                "\"name\":\"Better\"," +
                "\"description\":\"A charitable social enterprise for all the community\"," +
                "\"address\":{" +
                    "\"@type\":\"PostalAddress\"," +
                    "\"addressCountry\":\"GB\"," +
                    "\"addressLocality\":\"Village East\"," +
                    "\"addressRegion\":\"Middlesbrough\"," +
                    "\"postalCode\":\"TS4 3AE\"," +
                    "\"streetAddress\":\"Alan Peacock Way\"" +
                "}," +
                "\"email\":\"customerservices@gll.org\"," +
                "\"legalName\":\"Greenwich Leisure Limited\"," +
                "\"logo\":{" +
                    "\"@type\":\"ImageObject\"," +
                    "\"url\":\"http://data.better.org.uk/images/logo.png\"" +
                "}," +
                "\"taxMode\":\"https://openactive.io/TaxGross\"," +
                "\"telephone\":\"020 3457 8700\"," +
                "\"termsOfService\":[" +
                    "{" +
                        "\"@type\":\"PrivacyPolicy\"," +
                        "\"name\":\"Privacy Policy\"," +
                        "\"url\":\"https://example.com/privacy-policy\"" +
                    "}," +
                    "{" +
                        "\"@type\":\"TermsOfUse\"," +
                        "\"name\":\"Terms and Conditions\"," +
                        "\"url\":\"https://example.com/terms-and-conditions\"" +
                    "}" +
                "]," +
                "\"url\":\"https://www.better.org.uk\"," +
                "\"vatID\":\"GB 789 1234 56\"" +
            "}," +
            "\"totalPaymentDue\":{" +
                "\"@type\":\"PriceSpecification\"," +
                "\"price\":5.0," +
                "\"priceCurrency\":\"GBP\"" +
            "}," +
            "\"totalPaymentTax\":[" +
                "{" +
                    "\"@type\":\"TaxChargeSpecification\"," +
                    "\"name\":\"VAT at 20%\"," +
                    "\"price\":1.0," +
                    "\"priceCurrency\":\"GBP\"," +
                    "\"rate\":0.2" +
                "}" +
            "]" +
        "}";

        [Fact]
        public void Order_Deserialize_Accessors()
        {
            Order order = OpenActiveSerializer.Deserialize<Order>(complexJson);
            Assert.IsType<Order>(order);
            Assert.Equal(new Guid("e11429ea-467f-4270-ab62-e47368996fe8"), order.Identifier);
            Assert.Equal(new Uri("https://example.com/events/452#/offers/878"), order.OrderedItem[0].AcceptedOffer.Object.Id);
            Assert.IsType<ScheduledSession>(order.OrderedItem[0].OrderedItem.Object);
            Assert.Equal("ScheduledSession", order.OrderedItem[0].OrderedItem.Object.Type);
            Assert.Equal(new Uri("https://example.com/events/452/subEvents/132"), order.OrderedItem[0].OrderedItem.Object.Id);
            Assert.Equal(new Uri("https://example.com/api/organisations/123"), order.Seller.Object.Id);
            Assert.True(order.Seller.Object.IsOrganization);
            Assert.Equal(BrokerType.AgentBroker, order.BrokerRole);
            Assert.Equal("Alan Peacock Way", order?.Broker?.Address?.StreetAddress);
            Assert.Equal("Geoff", order?.Customer.GivenName);
            Assert.Equal("EUCODE", order?.OrderedItem?[0]?.UnitTaxSpecification?[0]?.Identifier.GetClass<List<PropertyValue>>()?[0].Name);
            Assert.Equal(new TimeSpan(6, 0, 0, 0), order?.OrderedItem?[0]?.AcceptedOffer.Object?.ValidFromBeforeStartDate);
            Assert.Equal(new DateTimeOffset(2018, 10, 30, 11, 00, 00, 00, new TimeSpan()), ((ScheduledSession)order?.OrderedItem?[0]?.OrderedItem.Object)?.StartDate);
        }

        [Fact]
        public void Order_EncodeDecode()
        {
            var decode = OpenActiveSerializer.Deserialize<Order>(complexJson);
            var encode = OpenActiveSerializer.Serialize(decode);

            output.WriteLine(complexJson);
            output.WriteLine(encode);
            Assert.Equal(complexJson, encode);
        }

        [Fact]
        public void Order_LeaseEncode()
        {
            var leaseExpires = DateTimeOffset.UtcNow + new TimeSpan(0, 5, 0);
            var encode = OpenActiveSerializer.Serialize(new OrderQuote { Lease = new Lease { LeaseExpires = leaseExpires } });

            var expectedLeaseJson = "{" +
            "\"@context\":\"https://openactive.io/\"," +
            "\"@type\":\"OrderQuote\"," +
            "\"lease\":{" +
                "\"@type\":\"Lease\"," +
                $"\"leaseExpires\":\"{leaseExpires.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz")}\"" +
            "}" +
            "}";

            output.WriteLine(encode);
            output.WriteLine(expectedLeaseJson);

            Assert.Equal(expectedLeaseJson, encode);

            var decode = OpenActiveSerializer.Deserialize<OrderQuote>(encode);
            // Truncate milliseconds from leaseExpires
            Assert.Equal(leaseExpires.AddTicks(-(leaseExpires.Ticks % TimeSpan.TicksPerSecond)), decode.Lease.LeaseExpires);
        }
    }
}
