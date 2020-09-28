namespace OpenActive.NET
{
    using System;
    using System.Reflection;
    using System.Xml;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts an <see cref="IValue"/> object to JSON. If the <see cref="IValue"/> contains a TimeSpan, converts it
    /// to ISO 8601 format first.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public class OpenActiveTimeSpanToISO8601DurationValuesConverter : ValuesConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType) => objectType == typeof(TimeSpan);

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
            else if (value is TimeSpan duration)
            {
                // Truncate the duration to ensure that it does not include excess precision
                var truncatedDuration = new TimeSpan(duration.Days, duration.Hours, duration.Minutes, duration.Seconds);
                writer.WriteValue(XmlConvert.ToString(truncatedDuration));
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
            if (valuesType != null && valuesType == typeof(TimeSpan))
            {
                return XmlConvert.ToTimeSpan(reader.Value.ToString());
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
