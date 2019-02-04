
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
    public class SessionSeries : Event
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "SessionSeries";

        
        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override int? RemainingAttendeeCapacity { get; set; }


        /// <summary>
        /// Relates a parent event to a child event. Properties describing the parent event can be assumed to apply to the child, unless otherwise specified. A child event might be a specific instance of an Event within a schedule
        /// </summary>
        [DataMember(Name = "subEvent", EmitDefaultValue = false, Order = 8)]
        public new virtual List<ScheduledSession> SubEvent { get; set; }

    }
}
