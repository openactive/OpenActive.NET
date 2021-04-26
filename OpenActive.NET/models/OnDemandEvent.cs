using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/OnDemandEvent, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class OnDemandEvent : Event
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
        public override string Type => "OnDemandEvent";

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override EventAttendanceModeEnumeration? EventAttendanceMode { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Schema.NET.EventStatusType? EventStatus { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Place Location { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override long? MaximumAttendeeCapacity { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override long? MaximumVirtualAttendeeCapacity { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override string MeetingPoint { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override long? RemainingAttendeeCapacity { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override string SchedulingNote { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override SingleValues<string, DateTimeOffset?> StartDate { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override SingleValues<string, DateTimeOffset?> EndDate { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Event> SubEvent { get; set; }

        /// <summary>
        /// Relates an `OnDemandEvent` to an `EventSeries`.
        /// </summary>
        [DataMember(Name = "superEvent", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public override Event SuperEvent { get; set; }

        /// <summary>
        /// A video, audio or other media that represents the actual recording of the `OnDemandEvent`.
        /// </summary>
        /// <example>
        /// <code>
        /// "workFeatured": {
        ///   "@type": "VideoObject",
        ///   "url": "https://www.youtube.com/watch?v=3fbCs0GVjgQ",
        ///   "embedUrl": "https://www.youtube.com/embed/3fbCs0GVjgQ",
        ///   "thumbnail": [
        ///     {
        ///       "@type": "ImageObject",
        ///       "url": "http://example.com/static/image/speedball_thumbnail.jpg"
        ///     }
        ///   ]
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "workFeatured", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual MediaObject WorkFeatured { get; set; }
    }
}
