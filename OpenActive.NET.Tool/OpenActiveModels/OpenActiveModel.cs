using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenActive.NET.Tool.Models
{
    public partial class OpenActiveModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("derivedFrom")]
        public Uri DerivedFrom { get; set; }

        [JsonProperty("fields")]
        public List<OpenActiveField> Fields { get; set; }

        [JsonProperty("subClassOf", NullValueHandling = NullValueHandling.Ignore)]
        public string SubClassOf { get; set; }
    }

    public partial class OpenActiveField
    {
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }

        [JsonProperty("models")]
        public List<string> Models { get; set; }

        [JsonProperty("requiredContent", NullValueHandling = NullValueHandling.Ignore)]
        public string RequiredContent { get; set; }

        [JsonProperty("sameAs", NullValueHandling = NullValueHandling.Ignore)]
        public Uri SameAs { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Description { get; set; }
    }

    public partial class OpenActiveModel
    {
        public static List<OpenActiveModel> FromJson(string json) => JsonConvert.DeserializeObject<List<OpenActiveModel>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<OpenActiveModel> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
