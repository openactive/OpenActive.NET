using Newtonsoft.Json;
using Schema.NET;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    public class Event : Schema.NET.Event
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Event";

        [DataMember(Name = "startDate", Order = 130)]
        public new DateTimeOffset? StartDate { get; set; }

        [DataMember(Name = "endDate", Order = 131)]
        public new DateTimeOffset? EndDate { get; set; }

        [DataMember(Name = "duration", Order = 115)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public new TimeSpan Duration { get; set; }

        [DataMember(Name = "remainingAttendeeCapacity", Order = 127)]
        public new int? RemainingAttendeeCapacity { get; set; }
        
        [DataMember(Name = "attendeeInstructions", Order = 1001)]
        public string AttendeeInstructions { get; set; }

        [DataMember(Name = "category", Order = 1002)]
        public List<string> Category { get; set; }

        [DataMember(Name = "meetingPoint", Order = 1003)]
        public string MeetingPoint { get; set; }
    }

    public class SessionSeries : Event
    {
        [DataMember(Name = "meetingPoint", Order = 1003)]
        public new string MeetingPoint { get; set; }
    }
}
