using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using OpenActive.NET.Rpde.Version1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenActive.NET
{
    public static class OpenActiveSerializer
    {
        private const string ContextPropertyJson = "\"@context\":\"https://schema.org\",";
        private const string OpenActiveContextPropertyJson = "\"@context\":\"https://openactive.io/\",";
        private const string OpenActiveContextPropertyJsonWithBeta = "\"@context\":[\"https://openactive.io/\",\"https://openactive.io/ns-beta\"],";
        private const string OpenActiveContextPropertyJsonWithSchema = "\"@context\":[\"https://schema.org/\",\"https://openactive.io/\"],";
        private const string OpenActiveContextPropertyJsonWithBetaAndSchema = "\"@context\":[\"https://schema.org/\",\"https://openactive.io/\",\"https://openactive.io/ns-beta\"],";

        private const string SchemaIdJson = "\"@id\":";
        private const string OpenActiveIdJson = "\"id\":";
        private const string SchemaTypeJson = "\"@type\":";
        private const string OpenActiveTypeJson = "\"type\":";

        /// <summary>
        /// Default serializer settings used.
        /// </summary>
        private static readonly JsonSerializerSettings InternalSerializerSettings = new JsonSerializerSettings()
        {
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter(),
                new DecimalConverter()
            },
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            ContractResolver = NoEmptyStringsContractResolver.Instance,
            // The ASP.NET MVC framework defaults to 32(so 32 levels deep in the JSON structure)
            // to prevent stack overflow caused by malicious complex JSON requests.
            MaxDepth = 32

        };

        /// <summary>
        /// Serializer settings used when trying to avoid XSS vulnerabilities where user-supplied data is used
        /// and the output of the serialization is embedded into a web page raw.
        /// </summary>
        private static readonly JsonSerializerSettings HtmlEscapedSerializerSettings = new JsonSerializerSettings()
        {
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter(),
                new DecimalConverter()
            },
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            ContractResolver = NoEmptyStringsContractResolver.Instance,
            StringEscapeHandling = StringEscapeHandling.EscapeHtml,
            // The ASP.NET MVC framework defaults to 32(so 32 levels deep in the JSON structure)
            // to prevent stack overflow caused by malicious complex JSON requests.
            MaxDepth = 32
        };

        /// <summary>
        /// Serializer settings used when deserializing.
        /// </summary>
        private static readonly JsonSerializerSettings DeserializerSettings = new JsonSerializerSettings()
        {
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter(),
                new ValuesConverter()
            },
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            // The ASP.NET MVC framework defaults to 32(so 32 levels deep in the JSON structure)
            // to prevent stack overflow caused by malicious complex JSON requests.
            MaxDepth = 32
        };


        /// <summary>
        /// Returns the JSON-LD representation of a JsonLdObject.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of the JsonLdObject.
        /// </returns>
        public static string Serialize<T>(T obj) where T : Schema.NET.JsonLdObject => SerializeWithSettings(obj, InternalSerializerSettings, false);

        /// <summary>
        /// Returns the JSON-LD representation of a list of JsonLdObject.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of the JsonLdObject.
        /// </returns>
        public static string SerializeList<T>(List<T> obj) where T : Schema.NET.JsonLdObject => SerializeWithSettings(obj, InternalSerializerSettings, false);


        /// <summary>
        /// Returns the JSON-LD representation of an RpdePage.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON representation of the RPDE page.
        /// </returns>
        public static string SerializeRpdePage(RpdePage obj) => JsonConvert.SerializeObject(obj, RpdePage.SerializerSettings);


        /// <summary>
        /// Returns the JSON-LD representation of an JsonLdObject, including "https://schema.org" in the "@context",
        /// to make the output compatible with search engines, for SEO.
        ///
        /// This method should be used when you want to embed the output raw (as-is) into a web
        /// page. It uses serializer settings with HTML escaping to avoid Cross-Site Scripting (XSS)
        /// vulnerabilities if the object was constructed from an untrusted source.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of the JsonLdObject.
        /// </returns>
        public static string SerializeToHtmlEmbeddableString<T>(T obj) where T : Schema.NET.JsonLdObject => SerializeWithSettings(obj, HtmlEscapedSerializerSettings, true);


        /// <summary>
        /// Returns a strongly typed model of the JSON-LD representation provided.
        /// 
        /// Note this will return null if the deserialized JSON-LD class cannot be assigned to `T`.
        /// </summary>
        /// <typeparam name="T">Type of schema.org object to deserialize (can use Thing for any)</typeparam>
        /// <param name="str">JSON string</param>
        /// <returns>Strongly typed schema.org model</returns>
        public static T Deserialize<T>(string str) where T : Schema.NET.JsonLdObject => JsonConvert.DeserializeObject<T>(PrepareForDeserialization(str), DeserializerSettings);

        /// <summary>
        /// Returns a strongly typed list of models of the given type of the JSON-LD representation provided.
        /// </summary>
        /// <typeparam name="T">Type of schema.org List to deserialize (can use Thing for any)</typeparam>
        /// <param name="str">JSON string</param>
        /// <returns>Strongly typed schema.org model</returns>
        public static List<T> DeserializeList<T>(string str) where T : Schema.NET.JsonLdObject => JsonConvert.DeserializeObject<List<T>>(PrepareForDeserialization(str), DeserializerSettings);

        /// <summary>
        /// Returns a strongly typed model of the PPDE page representation provided.
        /// </summary>
        /// <param name="str">JSON string</param>
        /// <returns>Strongly typed RPDE model</returns>
        public static RpdePage DeserializeRpdePage(string str) => JsonConvert.DeserializeObject<RpdePage>(str, RpdePage.SerializerSettings);


        /// <summary>
        /// Returns the JSON-LD representation of this instance using the <see cref="JsonSerializerSettings"/> provided.
        ///
        /// Caution: You should ensure your <paramref name="serializerSettings"/> has
        /// <see cref="JsonSerializerSettings.StringEscapeHandling"/> set to <see cref="StringEscapeHandling.EscapeHtml"/>
        /// if you plan to embed the output using @Html.Raw anywhere in a web page, else you open yourself up a possible
        /// Cross-Site Scripting (XSS) attack if untrusted data is set on any of this object's properties.
        /// </summary>
        /// <param name="serializerSettings">Serialization settings.</param>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        private static string SerializeWithSettings(object obj, JsonSerializerSettings serializerSettings, bool maintainSchemaContext) =>
            RemoveAllButFirstContext(JsonConvert.SerializeObject(obj, serializerSettings), maintainSchemaContext);

        private static string RemoveAllButFirstContext(string json, bool maintainSchemaContext)
        {
            // Only include beta context if there are beta properties present
            var contextString = json.Contains("\"beta:") ?
                (maintainSchemaContext ? OpenActiveContextPropertyJsonWithBetaAndSchema : OpenActiveContextPropertyJsonWithBeta) :
                (maintainSchemaContext ? OpenActiveContextPropertyJsonWithSchema : OpenActiveContextPropertyJson);

            var stringBuilder = new StringBuilder(json);
            var startIndex = json[0] == '[' ?
                0 : // If the result is an array, remove all "@context"
                ContextPropertyJson.Length + 1; // We add the one to represent the opening curly brace.
            // Replace OpenActive context and properties
            stringBuilder.Replace(ContextPropertyJson, string.Empty, startIndex, stringBuilder.Length - startIndex);
            stringBuilder.Replace(ContextPropertyJson, contextString, 0, startIndex);
            return stringBuilder.ToString();
        }

        private static string PrepareForDeserialization(string json)
        {
            var stringBuilder = new StringBuilder(json);
            stringBuilder.Replace(OpenActiveIdJson, SchemaIdJson, 0, stringBuilder.Length);
            stringBuilder.Replace(OpenActiveTypeJson, SchemaTypeJson, 0, stringBuilder.Length);
            return stringBuilder.ToString();
        }

        internal class DecimalConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(decimal) || objectType == typeof(decimal?));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                // Note this does not get called during deserialisation due to ValuesConverter, so is not required.
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value as Decimal? == 0)
                {
                    // Use simple zero "0" to represent a decimal in JSON, instead of the default "0.0".
                    JToken.FromObject(0).WriteTo(writer);
                }
                else
                {
                    JToken.FromObject(value).WriteTo(writer);
                }
            }
        }

        // This is used for OpenActive strings, which are not handled by IValue types so may have empty strings
        public class NoEmptyStringsContractResolver : DefaultContractResolver
        {
            public static readonly NoEmptyStringsContractResolver Instance = new NoEmptyStringsContractResolver();

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);

                if (property.PropertyType == typeof(string))
                {
                    // Do not include empty strings in JSON output (as per OpenActive Modelling Specification)
                    property.ShouldSerialize = instance =>
                    {
                        var type = instance.GetType();
                        var colName = member.Name;
                        var usefulValues = type.GetRuntimeProperties().Where(x => x.Name == colName && !string.IsNullOrWhiteSpace(x.GetValue(instance, null) as string));
                        return usefulValues.Count() > 0;
                    };
                }

                /*
                if (property.PropertyType == typeof(Schema.NET.OneOrMany<string>?))
                {
                    // Do not include empty strings in JSON output (as per OpenActive Modelling Specification)
                    property.ShouldSerialize = instance =>
                    {
                        var type = instance.GetType();
                        var colName = member.Name;
                        var usefulValues = type.GetRuntimeProperties().Where(x => x.Name == colName && ContainsUsefulValues(x.GetValue(instance, null) as Schema.NET.OneOrMany<string>?));
                        return usefulValues.Count() > 0;
                    };
                }

                if (property.PropertyType == typeof(List<string>))
                {
                    // Do not include empty strings in JSON output (as per OpenActive Modelling Specification)
                    property.ShouldSerialize = instance =>
                    {
                        var type = instance.GetType();
                        var colName = member.Name;
                        var usefulValues = type.GetRuntimeProperties().Where(x => x.Name == colName && ContainsUsefulValues(x.GetValue(instance, null) as List<string>));
                        return usefulValues.Count() > 0;
                    };
                }
                */

                return property;
            }

            /*
            private bool ContainsUsefulValues(Schema.NET.OneOrMany<string>? str)
            {
                return str.HasValue && str.Value.Where(x => !string.IsNullOrWhiteSpace(x)).Count() > 0;
            }

            private bool ContainsUsefulValues(List<string> str)
            {
                return str != null && str.Where(x => !string.IsNullOrWhiteSpace(x)).Count() > 0;
            }
            */
        }
    }
}
