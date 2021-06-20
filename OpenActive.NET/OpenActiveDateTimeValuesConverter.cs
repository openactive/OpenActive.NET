namespace OpenActive.NET
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Xml;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts an <see cref="IValue"/> object to JSON when it is a Time.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public class OpenActiveDateTimeValuesConverter : ValuesConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType) => objectType == typeof(DateTimeValue) || objectType == typeof(DateValue) || objectType == typeof(TimeValue);

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
            else if (value is INullableValue nullableValue && !nullableValue.HasValue)
            {
                writer.WriteNull();
            }
            else if (value is DateTimeValue dateTime)
            {
                writer.WriteValue(dateTime.ToString());
            }
            else if (value is DateValue date)
            {
                writer.WriteValue(date.ToString());
            }
            else if (value is TimeValue time)
            {
                writer.WriteValue(time.ToString());
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
            if (valuesType != null && valuesType == typeof(DateTimeValue))
            {
                // Json.NET Will auto-covert values to DateTimeOffset if they appear to be in date format
                if (reader.Value is DateTimeOffset dateTimeOffset)
                {
                    return new DateTimeValue(dateTimeOffset, false);
                }
                else
                {
                    return new DateTimeValue(reader.Value.ToString());
                }
            }
            else if (valuesType != null && valuesType == typeof(DateValue))
            {
                // Json.NET will auto-covert values to DateTimeOffset if they appear to be in date format
                if (reader.Value is DateTimeOffset)
                {
                    throw new JsonSerializationException("DateValue must be a date without time components");
                }
                else
                {
                    return new DateValue(reader.Value.ToString());
                }
            }
            else if (valuesType != null && valuesType == typeof(TimeValue))
            {
                if (reader.Value is DateTimeOffset)
                {
                    throw new JsonSerializationException("TimeValue must be a time without date components");
                }
                else
                {
                    return new TimeValue(reader.Value.ToString());
                }
                
            }

            throw new NotImplementedException();
        }
    }
}
