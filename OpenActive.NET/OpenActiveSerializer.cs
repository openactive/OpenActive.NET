using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
                new StringEnumConverter()
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
                new StringEnumConverter()
            },
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = NoEmptyStringsContractResolver.Instance,
            StringEscapeHandling = StringEscapeHandling.EscapeHtml
        };

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
            var stringBuilder = new StringBuilder(json);
            var startIndex = ContextPropertyJson.Length + 1; // We add the one to represent the opening curly brace.
            stringBuilder.Replace(ContextPropertyJson, string.Empty, startIndex, stringBuilder.Length - startIndex);
            // Replace OpenActive context and properties
            stringBuilder.Replace(ContextPropertyJson, string.Empty, startIndex, stringBuilder.Length - startIndex);
            stringBuilder.Replace(ContextPropertyJson, OpenActiveContextPropertyJson, 0, startIndex);
            stringBuilder.Replace(SchemaIdJson, OpenActiveIdJson, 0, stringBuilder.Length);
            stringBuilder.Replace(SchemaTypeJson, OpenActiveTypeJson, 0, stringBuilder.Length);
            return stringBuilder.ToString();
        }


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
                        var all = type.GetRuntimeProperties().Where(x => x.Name == colName);
                        var info = all.FirstOrDefault(x => x.DeclaringType == type) ?? all.First();

                        return !string.IsNullOrWhiteSpace(info.GetValue(instance, null) as string);
                    };
                }

                return property;
            }
        }
    }
}
