
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Event](https://schema.org/Event), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class ScheduledSession : Event
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "ScheduledSession";

        
        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Schedule> EventSchedule { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Event> SubEvent { get; set; }


        /// <summary>
        /// Relates a child event to a parent event. Properties describing the parent event can be assumed to apply to the child, unless otherwise specified. A parent event might specify a recurring schedule, of which the child event is one specific instance
        /// </summary>
        [DataMember(Name = "superEvent", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<Uri, Event> SuperEvent { get; set; }

    }
}
