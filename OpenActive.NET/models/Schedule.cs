
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Schedule](https://pending.schema.org/Schedule), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class Schedule 
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public virtual string Type => "Schedule";

        
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
        [DataMember(Name = "byDay", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public virtual Schema.NET.Values<List<string>, List<Schema.NET.DayOfWeek?>> ByDay { get; set; }


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
        [DataMember(Name = "byMonth", Order = 115)]
        public virtual List<int?> ByMonth { get; set; }


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
        [DataMember(Name = "byMonthDay", Order = 115)]
        public virtual List<int?> ByMonthDay { get; set; }


        /// <summary>
        /// The duration of the event given in [ISO8601] format.
        /// </summary>
        /// <example>
        /// <code>
        /// "duration": "PT1H"
        /// </code>
        /// </example>
        [DataMember(Name = "duration", Order = 115)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? Duration { get; set; }


        /// <summary>
        /// The end date of the schedule.
        /// </summary>
        /// <example>
        /// <code>
        /// "endDate": "2018-01-27"
        /// </code>
        /// </example>
        [DataMember(Name = "endDate", Order = 115)]
        public virtual DateTimeOffset? EndDate { get; set; }


        /// <summary>
        /// The end time of the event.
        /// </summary>
        /// <example>
        /// <code>
        /// "endTime": "12:00:00"
        /// </code>
        /// </example>
        [DataMember(Name = "endTime", Order = 115)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? EndTime { get; set; }


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
        [DataMember(Name = "exceptDate", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public virtual Schema.NET.Values<List<DateTimeOffset?>, List<DateTimeOffset?>> ExceptDate { get; set; }


        /// <summary>
        /// An RFC6570 compliant URI template that can be used to generate a unique identifier (@id) for every event described by the schedule (see below for more information). This property is required if the data provider is supporting third-party booking via the Open Booking API.
        /// </summary>
        /// <example>
        /// <code>
        /// "idTemplate": "https://example.com/event{/id}"
        /// </code>
        /// </example>
        [DataMember(Name = "idTemplate", Order = 115)]
        public virtual Uri IdTemplate { get; set; }


        /// <summary>
        /// Defines the number of times a recurring Event will take place.
        /// </summary>
        /// <example>
        /// <code>
        /// "repeatCount": 3
        /// </code>
        /// </example>
        [DataMember(Name = "repeatCount", Order = 115)]
        public virtual int? RepeatCount { get; set; }


        /// <summary>
        /// Defines the frequency at which Events will occur according to a Schedule. The intervals between events should be defined as a Duration of time.
        /// </summary>
        /// <example>
        /// <code>
        /// "repeatFrequency": "P1D"
        /// </code>
        /// </example>
        [DataMember(Name = "repeatFrequency", Order = 115)]
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
        [DataMember(Name = "scheduledEventType", Order = 115)]
        public virtual string ScheduledEventType { get; set; }


        /// <summary>
        /// The start date of the event.
        /// </summary>
        /// <example>
        /// <code>
        /// "startDate": "2018-01-27"
        /// </code>
        /// </example>
        [DataMember(Name = "startDate", Order = 115)]
        public virtual DateTimeOffset? StartDate { get; set; }


        /// <summary>
        /// The start time of the event.
        /// </summary>
        /// <example>
        /// <code>
        /// "startTime": "12:00:00"
        /// </code>
        /// </example>
        [DataMember(Name = "startTime", Order = 115)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? StartTime { get; set; }


        /// <summary>
        /// An RFC6570 compliant URI template that can be used to generate a unique URL (schema:url) for every event described by the schedule (see below for more information). This property is required if the data provider wants to provide participants with a unique URL to book to attend an event.
        /// </summary>
        /// <example>
        /// <code>
        /// "urlTemplate": "https://example.com/event{/id}"
        /// </code>
        /// </example>
        [DataMember(Name = "urlTemplate", Order = 115)]
        public virtual Uri UrlTemplate { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// The time zone used to generate occurrences, same as iCal TZID. E.g. 'Europe/London'.
        /// 
        /// If you are using this property, please join the discussion at proposal [#197](https://github.com/openactive/modelling-opportunity-data/issues/197).
        /// </summary>
        [DataMember(Name = "beta:timeZone", Order = 115)]
        public virtual string TimeZone { get; set; }

    }
}
