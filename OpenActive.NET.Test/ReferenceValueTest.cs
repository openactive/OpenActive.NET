using Newtonsoft.Json;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
namespace OpenActive.NET.Test
{
    public class ReferenceValueTest
    {
        private readonly ITestOutputHelper output;

        public ReferenceValueTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly string eventJson = "{\"@context\":\"https://openactive.io/\",\"@type\":\"ScheduledSession\",\"@id\":\"https://opensessions.io/api/session-series/1402CBP20150217#/subEvent/C5EE1E55-2DE6-44F7-A865-42F268A82C63\",\"identifier\":\"C5EE1E55-2DE6-44F7-A865-42F268A82C63\"}";

        private readonly ScheduledSession @event = new OpenActive.NET.ScheduledSession()
        {
            Id = new Uri("https://opensessions.io/api/session-series/1402CBP20150217#/subEvent/C5EE1E55-2DE6-44F7-A865-42F268A82C63"),
            Identifier = "C5EE1E55-2DE6-44F7-A865-42F268A82C63"
        };

        private readonly string referencedEventJson = "{\"@context\":\"https://openactive.io/\",\"@type\":\"ScheduledSession\",\"@id\":\"https://opensessions.io/api/session-series/1402CBP20150217#/subEvent/C5EE1E55-2DE6-44F7-A865-42F268A82C63\",\"identifier\":\"C5EE1E55-2DE6-44F7-A865-42F268A82C63\",\"superEvent\":\"https://opensessions.io/api/session-series/1402CBP20150217\"}";

        private readonly ScheduledSession referencedEvent = new OpenActive.NET.ScheduledSession()
        {
            Id = new Uri("https://opensessions.io/api/session-series/1402CBP20150217#/subEvent/C5EE1E55-2DE6-44F7-A865-42F268A82C63"),
            Identifier = "C5EE1E55-2DE6-44F7-A865-42F268A82C63",
            SuperEvent = new Uri("https://opensessions.io/api/session-series/1402CBP20150217")
        };

        private readonly string embeddedEventJson = "{\"@context\":\"https://openactive.io/\",\"@type\":\"ScheduledSession\",\"@id\":\"https://opensessions.io/api/session-series/1402CBP20150217#/subEvent/C5EE1E55-2DE6-44F7-A865-42F268A82C63\",\"identifier\":\"C5EE1E55-2DE6-44F7-A865-42F268A82C63\",\"superEvent\":{" +
                "\"@type\":\"SessionSeries\"," +
                "\"name\":\"Super!\"" +
            "}}";

        private readonly ScheduledSession embeddedEvent = new OpenActive.NET.ScheduledSession()
        {
            Id = new Uri("https://opensessions.io/api/session-series/1402CBP20150217#/subEvent/C5EE1E55-2DE6-44F7-A865-42F268A82C63"),
            Identifier = "C5EE1E55-2DE6-44F7-A865-42F268A82C63",
            SuperEvent = new SessionSeries
            {
                Name = "Super!"
            }
        };

        [Fact]
        public void ToString_EventWithNull_ReturnsExpectedJsonLd()
        {
            output.WriteLine(this.@event.ToString());
            Assert.Equal(this.eventJson, this.@event.ToString());
        }

        [Fact]
        public void ToString_ReferencedEvent_ReturnsExpectedJsonLd()
        {
            output.WriteLine(this.referencedEvent.ToString());
            Assert.Equal(this.referencedEventJson, this.referencedEvent.ToString());
        }

        [Fact]
        public void ToString_EmbeddedEvent_ReturnsExpectedJsonLd()
        {
            output.WriteLine(this.embeddedEvent.ToString());
            Assert.Equal(this.embeddedEventJson, this.embeddedEvent.ToString());
        }

        [Fact]
        public void ScheduledSession_EventWithNull_Deserialize()
        {
            // Should recognise subclasses of Event when deserialising
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(eventJson);
            output.WriteLine(eventJson);
            output.WriteLine("");
            output.WriteLine(decode.ToString());

            // Test superEvent
            Assert.False(decode.SuperEvent.HasValue);
            Assert.Null(decode.SuperEvent.IdReference);
            Assert.Null(decode.SuperEvent.Object);
        }

        [Fact]
        public void ScheduledSession_ReferencedEvent_Deserialize()
        {
            // Should recognise subclasses of Event when deserialising
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(referencedEventJson);
            output.WriteLine(referencedEventJson);
            output.WriteLine("");
            output.WriteLine(decode.ToString());

            // Test superEvent
            Assert.True(decode.SuperEvent.HasValue);
            Assert.Equal(new Uri("https://opensessions.io/api/session-series/1402CBP20150217"), decode.SuperEvent.IdReference);
            Assert.Null(decode.SuperEvent.Object);
        }

        [Fact]
        public void ScheduledSession_EmbeddedEvent_Deserialize()
        {
            // Should recognise subclasses of Event when deserialising
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(embeddedEventJson);
            output.WriteLine(embeddedEventJson);
            output.WriteLine("");
            output.WriteLine(decode.ToString());

            // Test superEvent
            Assert.True(decode.SuperEvent.HasValue);
            Assert.NotNull(decode.SuperEvent.Object);
            Assert.Equal("Super!", decode.SuperEvent.Object.Name);
        }

        [Fact]
        public void ScheduledSession_EventWithNull_EncodeDecode()
        {
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(eventJson);
            var encode = OpenActiveSerializer.Serialize(decode);

            output.WriteLine(eventJson);
            output.WriteLine(encode);
            Assert.Equal(eventJson, encode);
        }

        [Fact]
        public void ScheduledSession_ReferencedEvent_EncodeDecode()
        {
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(referencedEventJson);
            var encode = OpenActiveSerializer.Serialize(decode);

            output.WriteLine(referencedEventJson);
            output.WriteLine(encode);
            Assert.Equal(referencedEventJson, encode);
        }

        [Fact]
        public void ScheduledSession_EmbeddedEvent_EncodeDecode()
        {
            var decode = OpenActiveSerializer.Deserialize<ScheduledSession>(embeddedEventJson);
            var encode = OpenActiveSerializer.Serialize(decode);

            output.WriteLine(embeddedEventJson);
            output.WriteLine(encode);
            Assert.Equal(embeddedEventJson, encode);
        }

        [Fact]
        public void ReferenceValue_Object()
        {
            ReferenceValue<Event> sessionSeries = new SessionSeries();
            ReferenceValue<Event> @event = new Event();

            Assert.NotNull(sessionSeries.Object);
            Assert.NotNull(@event.Object);
        }
    }
}
