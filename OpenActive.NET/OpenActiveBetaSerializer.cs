using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenActive.NET.Beta
{
    public static class OpenActiveBetaSerializer
    {
        private const string OpenActiveContextPropertyJson = "\"@context\":\"https://openactive.io\",";
        private const string OpenActiveBetaContext = "https://openactive.io/ns-beta";
        /// <summary>
        /// Returns the JSON-LD representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public static string ToOpenActiveBetaString(this Schema.NET.Thing thing) => thing.ToOpenActiveBetaString(new List<string> { OpenActiveBetaContext } );
        public static string ToOpenActiveBetaString(this Schema.NET.Thing thing, List<string> contexts) => ReplaceContext(thing.ToOpenActiveString(), contexts);

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
        public static string ToOpenActiveBetaHtmlEscapedString(this Schema.NET.Thing thing) => thing.ToOpenActiveBetaString(new List<string> { OpenActiveBetaContext });
        public static string ToOpenActiveBetaHtmlEscapedString(this Schema.NET.Thing thing, List<string> contexts) => ReplaceContext(thing.ToOpenActiveHtmlEscapedString(), contexts);

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
        private static string ReplaceContext(string json, List<string> contexts)
        {
            var stringBuilder = new StringBuilder(json);
            var endIndex = OpenActiveContextPropertyJson.Length + 1; // We add the one to represent the opening curly brace.
            stringBuilder.Replace(OpenActiveContextPropertyJson, $"\"@context\":{JsonConvert.ToString(contexts)}, ", 0, endIndex);
            return stringBuilder.ToString();
        }


    }
}
