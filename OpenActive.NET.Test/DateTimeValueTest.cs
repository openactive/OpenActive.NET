using Newtonsoft.Json;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
namespace OpenActive.NET.Test
{
    public class DateTimeValueTest
    {
        private readonly ITestOutputHelper output;

        public DateTimeValueTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DateTimeValue_SetDateTimeOffset_Value()
        {
            var now = DateTimeOffset.Now;
            DateTimeValue value = now;
            Assert.Equal(new DateTimeValue(now, false), value);
        }

        [Fact]
        public void DateTimeValue_SetDateTimeOffset_Null()
        {
            DateTimeValue value = (DateTimeOffset?)null;
            Assert.Equal(default, value);
        }

        [Fact]
        public void DateTimeValue_SetString_Value()
        {
            var now = "1998-01-01";
            var nowDate = DateTimeOffset.Parse(now);
            DateTimeValue value = now;
            Assert.Equal(new DateTimeValue(nowDate, true), value);
        }

        [Fact]
        public void DateTimeValue_SetString_Null()
        {
            DateTimeValue value = (string)null;
            Assert.Equal(default, value);
        }

        [Fact]
        public void ToString_DateTimeValue_Date()
        {
            var json =
            "{" +
                "\"@context\":\"https://openactive.io/\"," +
                "\"@type\":\"Event\"," +
                "\"startDate\":\"2019-03-01\"" +
            "}";

            var ev = new Event
            {
                StartDate = "2019-03-01"
            };

            Assert.Equal(json, ev.ToString());

            var @event = OpenActiveSerializer.Deserialize<Event>(json);

            Assert.True(@event.StartDate.IsDateOnly);
            Assert.Equal(2019, @event.StartDate.Value.Year);
            Assert.Equal(3, @event.StartDate.Value.Month);
        }

        [Fact]
        public void ToString_DateTimeValue_DateTime()
        {
            var json =
            "{" +
                "\"@context\":\"https://openactive.io/\"," +
                "\"@type\":\"Event\"," +
                "\"startDate\":\"2019-03-01T03:03:00+00:00\"" +
            "}";

            var ev = new Event
            {
                StartDate = DateTimeOffset.Parse("2019-03-01T03:03:00+00:00")
            };

            Assert.Equal(json, ev.ToString());

            var @event = OpenActiveSerializer.Deserialize<Event>(json);

            Assert.False(@event.StartDate.IsDateOnly);
            Assert.Equal(2019, @event.StartDate.Value.Year);
            Assert.Equal(3, @event.StartDate.Value.Month);
        }

        [Fact]
        public void ToString_DateTimeValue_Exception()
        {
            var json =
            "{" +
                "\"@context\":\"https://openactive.io/\"," +
                "\"@type\":\"ScheduledSession\"," +
                "\"startDate\":\"2019-03-01\"" +
            "}";

            Assert.Throws(typeof(JsonSerializationException), () => OpenActiveSerializer.Deserialize<Event>(json));
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new ScheduledSession
            {
                StartDate = "2019-03-01"
            });
        }
    }
}
