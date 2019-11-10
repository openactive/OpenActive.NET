namespace OpenActive.NET
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Xml;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts an <see cref="IValue"/> object to JSON. If the <see cref="IValue"/> contains a TimeSpan, converts it
    /// to ISO 8601 format first.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public class OpenActiveDateTimeOffsetToISO8601TimeValuesConverter : ValuesConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType) => objectType == typeof(DateTimeOffset);

        /// <summary>
        /// Writes the object retrieved from <see cref="IValue"/> when one is found.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else if (value is DateTimeOffset time)
            {
                writer.WriteValue(time.ToString("HH:mm"));
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            if (objectType == null)
            {
                throw new ArgumentNullException(nameof(objectType));
            }

            if (serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            var valuesType = objectType.GetUnderlyingTypeFromNullable();
            if (valuesType != null && valuesType == typeof(DateTimeOffset))
            {
                return new DateTimeOffset(DateTime.ParseExact(reader.Value.ToString(), "HH:mm", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AssumeUniversal | DateTimeStyles.AllowWhiteSpaces));
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
