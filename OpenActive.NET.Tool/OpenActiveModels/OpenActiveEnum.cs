using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenActive.NET.Tool.Models
{

    public partial class OpenActiveEnum
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("namespace")]
        public Uri Namespace { get; set; }

        [JsonProperty("values")]
        public List<string> Values { get; set; }
    }

    public partial class OpenActiveEnum
    {
        public static List<OpenActiveEnum> FromJson(string json) => JsonConvert.DeserializeObject<List<OpenActiveEnum>>(json, Converter.Settings);
    }
}
