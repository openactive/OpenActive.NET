using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenActive.NET
{
    public static class OpenActiveSerializer
    {
        private const string ContextPropertyJson = "\"@context\":\"http://schema.org\",";
        private const string OpenActiveContextPropertyJson = "\"@context\":\"https://openactive.io/\",";
        private const string OpenActiveContextPropertyJsonWithBeta = "\"@context\":[\"https://openactive.io/\",\"https://openactive.io/ns-beta\"],";

        private const string SchemaIdJson = "\"@id\":";
        private const string OpenActiveIdJson = "\"id\":";
        private const string SchemaTypeJson = "\"@type\":";
        private const string OpenActiveTypeJson = "\"type\":";

        /// <summary>
        /// Default serializer settings used.
        /// </summary>
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter(),
                new DecimalConverter()
            },
            ContractResolver = NoEmptyStringsContractResolver.Instance
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
            ContractResolver = NoEmptyStringsContractResolver.Instance,
            StringEscapeHandling = StringEscapeHandling.EscapeHtml
        };


        /// <summary>
        /// Return null if the provided list is empty, otherwise return the list.
        /// </summary>
        public static List<TSource> ToListOrNullIfEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source != null && source.Count() > 0)
                return source.ToList();
            else
                return null;
        }

        /// <summary>
        /// Return null if the provided string IsNullOrWhiteSpace, otherwise return the string.
        /// </summary>
        public static string NullIfEmpty(this string source)
        {
            if (source != null && !string.IsNullOrWhiteSpace(source))
                return source;
            else
                return null;
        }
        

        /// <summary>
        /// Returns the JSON-LD representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public static string ToOpenActiveString(this Schema.NET.Thing thing) => ToString(thing, SerializerSettings);

        /// <summary>
        /// Returns the JSON-LD representation of this instance.
        ///
        /// This method should be used when you want to embed the output raw (as-is) into a web
        /// page. It uses serializer settings with HTML escaping to avoid Cross-Site Scripting (XSS)
        /// vulnerabilities if the object was constructed from an untrusted source.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public static string ToOpenActiveHtmlEscapedString(this Schema.NET.Thing thing) => ToString(thing, HtmlEscapedSerializerSettings);

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
        private static string ToString(Schema.NET.Thing thing, JsonSerializerSettings serializerSettings) =>
            RemoveAllButFirstContext(JsonConvert.SerializeObject(thing, serializerSettings));

        private static string RemoveAllButFirstContext(string json)
        {
            // Only include beta context if there are beta properties present
            var contextString = json.Contains("\"beta:") ?
                OpenActiveContextPropertyJsonWithBeta : OpenActiveContextPropertyJson;

            var stringBuilder = new StringBuilder(json);
            var startIndex = ContextPropertyJson.Length + 1; // We add the one to represent the opening curly brace.
            // Replace OpenActive context and properties
            stringBuilder.Replace(ContextPropertyJson, string.Empty, startIndex, stringBuilder.Length - startIndex);
            stringBuilder.Replace(ContextPropertyJson, contextString, 0, startIndex);
            stringBuilder.Replace(SchemaIdJson, OpenActiveIdJson, 0, stringBuilder.Length);
            stringBuilder.Replace(SchemaTypeJson, OpenActiveTypeJson, 0, stringBuilder.Length);
            return stringBuilder.ToString();
        }

        public static string Serialize(object obj) => RemoveAllButFirstContext(JsonConvert.SerializeObject(obj, SerializerSettings));

        public static T Deserialize<T>(string str) => JsonConvert.DeserializeObject<T>(PrepareForDeserialization(str));
        
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
