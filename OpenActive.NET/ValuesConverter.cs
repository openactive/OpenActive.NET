namespace OpenActive.NET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converts an <see cref="IValue"/> object to JSON.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public class ValuesConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType) => objectType == typeof(IValue);

        /// <summary>
        /// Writes the specified <see cref="IValue"/> object using the JSON writer.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The <see cref="IValue"/> object.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var values = (IValue)value;
            var obj = values.Value;
            if (obj == null)
            {
                writer.WriteNull();
            }
            else
            {
                this.WriteObject(writer, obj, serializer);
            }
        }

        /// <summary>
        /// Writes the object retrieved from <see cref="IValue"/> when one is found.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public virtual void WriteObject(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var token = JToken.FromObject(value, serializer);
            token.WriteTo(writer);
        }

        private static object SanitizeReaderValue(JsonReader reader, JsonToken tokenType) =>
            tokenType == JsonToken.Integer ? Convert.ToInt32(reader.Value) : reader.Value;

        private static string GetTypeNameFromToken(JToken token)
        {
            var typeNameToken = token.Values().FirstOrDefault(t => t.Path.EndsWith("@type"));
            return typeNameToken?.Value<string>();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
