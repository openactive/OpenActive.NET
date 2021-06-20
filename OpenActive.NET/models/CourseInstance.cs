using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/CourseInstance, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class CourseInstance : Event
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
        public override string Type => "CourseInstance";

        /// <summary>
        /// A an array of oa:Schedule or oa:PartialSchedule, which represents a recurrence pattern.
        /// </summary>
        /// <example>
        /// <code>
        /// "eventSchedule": [
        ///   {
        ///     "@type": "PartialSchedule",
        ///     "repeatFrequency": "P1W",
        ///     "startTime": "20:15",
        ///     "endTime": "20:45",
        ///     "byDay": [
        ///       "http://schema.org/Tuesday"
        ///     ],
        ///     "scheduleTimezone": "Europe/London"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "eventSchedule", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Schedule> EventSchedule { get; set; }

        /// <summary>
        /// The description of the Course for which this is a distinct instance.
        /// </summary>
        [DataMember(Name = "instanceOfCourse", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Course InstanceOfCourse { get; set; }

        /// <summary>
        /// The start date of this course.
        /// </summary>
        /// <example>
        /// <code>
        /// "startDate": "2018-01-06"
        /// </code>
        /// </example>
        [DataMember(Name = "startDate", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(OpenActiveDateTimeValuesConverter))]
        public override DateTimeValue StartDate { get { return base.StartDate; } set { if (!value.IsDateOnly) throw new ArgumentOutOfRangeException("This property must be set to a date without a time"); base.StartDate = value; } }

        /// <summary>
        /// The end date of this course.
        /// </summary>
        /// <example>
        /// <code>
        /// "endDate": "2018-01-27"
        /// </code>
        /// </example>
        [DataMember(Name = "endDate", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(OpenActiveDateTimeValuesConverter))]
        public override DateTimeValue EndDate { get { return base.EndDate; } set { if (!value.IsDateOnly) throw new ArgumentOutOfRangeException("This property must be set to a date without a time"); base.EndDate = value; } }

        /// <summary>
        /// The occurrences of this CourseInstance.
        /// </summary>
        [DataMember(Name = "subEvent", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public override List<Event> SubEvent { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Event SuperEvent { get; set; }

        /// <summary>
        /// [DEPRECATED: This term has graduated from the beta namespace and is highly likely to be removed in future versions of this library, please use `instanceOfCourse` instead.]
        /// This course for which this is an offering.
        /// 
        /// If you are using this property, please join the discussion at proposal [#164](https://github.com/openactive/modelling-opportunity-data/issues/164).
        /// </summary>
        [DataMember(Name = "beta:course", EmitDefaultValue = false, Order = 1013)]
        [JsonConverter(typeof(ValuesConverter))]
        [Obsolete("This term has graduated from the beta namespace and is highly likely to be removed in future versions of this library, please use `instanceOfCourse` instead.", false)]
        public virtual Course Course { get; set; }
    }
}
