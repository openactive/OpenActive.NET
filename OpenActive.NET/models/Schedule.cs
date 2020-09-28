
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from https://pending.schema.org/Schedule.
    /// </summary>
    [DataContract]
    public partial class Schedule : Schema.NET.JsonLdObject
    {
        /// <summary>
        /// Returns the JSON-LD representation of this instance.
        /// This method overrides Schema.NET ToString() to serialise using OpenActiveSerializer.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents the JSON-LD representation of this instance.</returns>
        public override string ToString()
        {
            return OpenActiveSerializer.Serialize(this);
        }

        /// <summary>
        /// Returns the JSON-LD representation of this instance, including "https://schema.org" in the "@context".
        ///
        /// This method must be used when you want to embed the output raw (as-is) into a web
        /// page. It uses serializer settings with HTML escaping to avoid Cross-Site Scripting (XSS)
        /// vulnerabilities if the object was constructed from an untrusted source.
        /// 
        /// This method overrides Schema.NET ToHtmlEscapedString() to serialise using OpenActiveSerializer.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public new string ToHtmlEscapedString()
        {
            return OpenActiveSerializer.SerializeToHtmlEmbeddableString(this);
        }

        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Schedule";

        
        /// <summary>
        /// Defines the day of the week upon which the Event takes place. 
        /// When using string values, this MUST conform to iCal BYDAY rule.
        /// </summary>
        /// <example>
        /// <code>
        /// "byDay": [
        ///   "https://schema.org/Monday"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "byDay", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual SingleValues<List<string>, List<Schema.NET.DayOfWeek>> ByDay { get; set; }


        /// <summary>
        /// Defines the months of the year on which the Event takes place. Specified as an integer between 1 and 12, with 1 representing January.
        /// </summary>
        /// <example>
        /// <code>
        /// "byMonth": [
        ///   2
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "byMonth", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<long> ByMonth { get; set; }


        /// <summary>
        /// Defines the days of the month on which the Event takes place. Specified as an integer between 1 and 31
        /// </summary>
        /// <example>
        /// <code>
        /// "byMonthDay": [
        ///   28
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "byMonthDay", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<long> ByMonthDay { get; set; }


        /// <summary>
        /// The duration of the event given in [ISO8601] format.
        /// </summary>
        /// <example>
        /// <code>
        /// "duration": "PT1H"
        /// </code>
        /// </example>
        [DataMember(Name = "duration", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? Duration { get; set; }


        /// <summary>
        /// The end time of the event.
        /// </summary>
        /// <example>
        /// <code>
        /// "endTime": "12:00:00"
        /// </code>
        /// </example>
        [DataMember(Name = "endTime", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(OpenActiveDateTimeOffsetToISO8601TimeValuesConverter))]
        public virtual DateTimeOffset? EndTime { get; set; }


        /// <summary>
        /// Exception dates where the schedule should not generate an event.
        /// </summary>
        /// <example>
        /// <code>
        /// "exceptDate": [
        ///   "2016-04-13T17:10:00Z",
        ///   "2016-09-14T17:10:00Z",
        ///   "2016-12-14T18:10:00Z",
        ///   "2016-12-21T18:10:00Z",
        ///   "2016-12-28T18:10:00Z",
        ///   "2017-01-04T18:10:00Z"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "exceptDate", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual SingleValues<List<DateTimeOffset>, List<string>> ExceptDate { get; set; }


        /// <summary>
        /// An RFC6570 compliant URI template that can be used to generate a unique identifier (`@id`) for every event described by the schedule. This property is required if the data provider is supporting third-party booking via the Open Booking API, or providing complimentary individual `subEvent`s.
        /// </summary>
        /// <example>
        /// <code>
        /// "idTemplate": "https://api.example.org/session-series/123/{startDate}"
        /// </code>
        /// </example>
        [DataMember(Name = "idTemplate", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string IdTemplate { get; set; }


        /// <summary>
        /// Defines the number of times a recurring Event will take place.
        /// </summary>
        /// <example>
        /// <code>
        /// "repeatCount": 3
        /// </code>
        /// </example>
        [DataMember(Name = "repeatCount", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual long? RepeatCount { get; set; }


        /// <summary>
        /// Defines the frequency at which Events will occur according to a Schedule. The intervals between events should be defined as a Duration of time.
        /// </summary>
        /// <example>
        /// <code>
        /// "repeatFrequency": "P1D"
        /// </code>
        /// </example>
        [DataMember(Name = "repeatFrequency", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? RepeatFrequency { get; set; }


        /// <summary>
        /// The type of event this schedule related to.
        /// </summary>
        /// <example>
        /// <code>
        /// "scheduledEventType": "Event"
        /// </code>
        /// </example>
        [DataMember(Name = "scheduledEventType", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string ScheduledEventType { get; set; }


        /// <summary>
        /// Indicates the timezone for which the time(s) indicated in the Schedule are given. The value provided should be among those listed in the IANA Time Zone Database.
        /// </summary>
        /// <example>
        /// <code>
        /// "scheduleTimezone": "Europe/London"
        /// </code>
        /// </example>
        [DataMember(Name = "scheduleTimezone", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string ScheduleTimezone { get; set; }


        /// <summary>
        /// The start date of the event.
        /// </summary>
        /// <example>
        /// <code>
        /// "startDate": "2018-01-27"
        /// </code>
        /// </example>
        [DataMember(Name = "startDate", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string StartDate { get; set; }


        /// <summary>
        /// The end date of the schedule.
        /// </summary>
        /// <example>
        /// <code>
        /// "endDate": "2018-01-27"
        /// </code>
        /// </example>
        [DataMember(Name = "endDate", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string EndDate { get; set; }


        /// <summary>
        /// The start time of the event.
        /// </summary>
        /// <example>
        /// <code>
        /// "startTime": "12:00:00"
        /// </code>
        /// </example>
        [DataMember(Name = "startTime", EmitDefaultValue = false, Order = 20)]
        [JsonConverter(typeof(OpenActiveDateTimeOffsetToISO8601TimeValuesConverter))]
        public virtual DateTimeOffset? StartTime { get; set; }


        /// <summary>
        /// An RFC6570 compliant URI template that can be used to generate a unique `url` for every event described by the schedule. This property is required if the data provider wants to provide participants with a unique URL to book to attend an event.
        /// </summary>
        /// <example>
        /// <code>
        /// "urlTemplate": "https://example.org/session-series/123/{startDate}"
        /// </code>
        /// </example>
        [DataMember(Name = "urlTemplate", EmitDefaultValue = false, Order = 21)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string UrlTemplate { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// [DEPRECATED: This beta property is now deprecated, please use `schema:scheduleTimezone` instead.] The time zone used to generate occurrences, same as iCal TZID. E.g. 'Europe/London'.
        /// 
        /// If you are using this property, please join the discussion at proposal [#197](https://github.com/openactive/modelling-opportunity-data/issues/197).
        /// </summary>
        [DataMember(Name = "beta:timeZone", EmitDefaultValue = false, Order = 1022)]
        [JsonConverter(typeof(ValuesConverter))]
        [Obsolete("DEPRECATED: This beta property is now deprecated, please use `schema:scheduleTimezone` instead.", false)]
        public virtual string TimeZone { get; set; }

    }
}
