
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Schedule](https://pending.schema.org/Schedule).
    /// </summary>
    [DataContract]
    public partial class PartialSchedule : Schedule
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "PartialSchedule";

        
        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// The time zone used to generate occurrences, same as iCal TZID. E.g. 'Europe/London'.
        /// 
        /// If you are using this property, please join the discussion at proposal [#197](https://github.com/openactive/modelling-opportunity-data/issues/197).
        /// </summary>
        [DataMember(Name = "beta:timeZone", EmitDefaultValue = false, Order = 1007)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string TimeZone { get; set; }

    }
}
