namespace OpenActive.NET
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
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

        private const string NamespacePrefix = "OpenActive.NET.";

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType) => objectType == typeof(IValue) || typeof(Schema.NET.JsonLdObject).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        /// <summary>
        /// Writes the specified <see cref="IValue"/> object using the JSON writer.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The <see cref="IValue"/> object.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = value;

            if (value as IValue != null)
            {
                var values = (IValue)value;
                obj = values.Value;
            }
            
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
        /*
        public virtual void WriteObject(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var token = JToken.FromObject(value, serializer);
            token.WriteTo(writer);
        }*

        private static object SanitizeReaderValue(JsonReader reader, JsonToken tokenType) =>
            tokenType == JsonToken.Integer ? Convert.ToInt32(reader.Value) : reader.Value;

        /*
        private static string GetTypeNameFromToken(JToken token)
        {
            var typeNameToken = token.Values().FirstOrDefault(t => t.Path.EndsWith("@type"));
            return typeNameToken?.Value<string>();
        }
        */

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
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

            var mainType = objectType.GetUnderlyingTypeFromNullable();

            object argument = null;

            var tokenType = reader.TokenType;
            var value = reader.Value;

            var token = JToken.Load(reader);
            var count = token.Children().Count();

            // Primitive type
            if (!mainType.GetTypeInfo().IsGenericType) {
                if (tokenType == JsonToken.StartArray)
                {
                    throw new JsonSerializationException("Found array where expected single item");
                } else
                {
                    return ParseTokenArguments(token, tokenType, mainType, value);
                }
            }
            // List<> of primitives
            else if (mainType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var type = mainType.GenericTypeArguments[0];
                if (tokenType == JsonToken.StartArray)
                {
                    var unwrappedType = type.GetUnderlyingTypeFromNullable();
                    argument = ReadJsonArray(token, unwrappedType);
                }
                else
                {
                    argument = ParseTokenArguments(token, tokenType, type, value);
                }
            }
            // SingleValues<>
            else
            {
                if (tokenType == JsonToken.StartArray)
                {

                    var total = 0;
                    argument = new List<object>();
                    for (var i = mainType.GenericTypeArguments.Length - 1; i >= 0; i--)
                    {
                        var type = mainType.GenericTypeArguments[i];
                        var unwrappedType = type.GetUnderlyingTypeFromNullable();

                        // If it's a list, pull out the actual type
                        if (unwrappedType.GetTypeInfo().IsGenericType && unwrappedType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            unwrappedType = unwrappedType.GenericTypeArguments[0].GetUnderlyingTypeFromNullable();
                        }

                        // only read as many items as there are tokens left
                        var args = ReadJsonArray(token, unwrappedType, count - total);

                        if (args != null && args.Count > 0)
                        {
                            if (args.Count == count)
                            {
                                // If the number of items is as expected
                                argument = args;
                                break;
                            } else
                            {
                                throw new JsonSerializationException("Mixed types within one List<> are not currently supported by the OpenActive.NET");
                            }
                            /*
                            var genericType = typeof(List<>).MakeGenericType(type);
                            var item = (IValue)Activator.CreateInstance(genericType, args);
                            items.Add(item);

                            total += args.Count;

                            if (total >= count)
                            {
                                // if we have deserialized enough items as there are tokens, break
                                break;
                            }*/
                        }
                    }

                    
                }
                else
                {
                    for (var i = mainType.GenericTypeArguments.Length - 1; i >= 0; i--)
                    {
                        var type = mainType.GenericTypeArguments[i];

                        try
                        {
                            argument = ParseTokenArguments(token, tokenType, type, value);

                            /*if (args != null)
                            {
                                var genericType = typeof(OneOrMany<>).MakeGenericType(type);
                                argument = Activator.CreateInstance(genericType, args);
                            }*/
                        }
#pragma warning disable CA1031 // Do not catch general exception types
                        catch (Exception e)
                        {
                            // Nasty, but we're trying brute force as a last resort, to
                            // see which type has the right constructor for this value
                            Debug.WriteLine(e);
                        }
#pragma warning restore CA1031 // Do not catch general exception types

                        if (argument != null)
                        {
                            // return first valid argument, going from right to left in generic type arguments
                            break;
                        }
                    }
                }
            }

            object instance = null;
            try
            {
                instance = Activator.CreateInstance(mainType, argument);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
#pragma warning restore CA1031 // Do not catch general exception types

            return instance;
        }

        /// <summary>
        /// Writes the specified <see cref="IValues"/> object using the JSON writer.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The <see cref="IValues"/> object.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /*
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            var values = (IValue)value;
            this.WriteObject(writer, values.Value, serializer);
        }*/

        /// <summary>
        /// Writes the object retrieved from <see cref="IValues"/> when one is found.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public virtual void WriteObject(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            serializer.Serialize(writer, value);
        }

        public static object ParseEnum(JToken token, Type unwrappedType)
        {
            const string SCHEMA_ORG = "http://schema.org/";
            const int SCHEMA_ORG_LENGTH = 18; // equivalent to "http://schema.org/".Length
            const string SCHEMA_ORG_HTTPS = "https://schema.org/";
            const int SCHEMA_ORG_HTTPS_LENGTH = 19; // equivalent to "https://schema.org/".Length
            const string OPENACTIVE_IO = "https://openactive.io/";
            const int OPENACTIVE_IO_LENGTH = 22; // equivalent to "https://openactive.io/".Length
            const string GOOD_RELATIONS = "http://purl.org/goodrelations/v1#";
            const int GOOD_RELATIONS_LENGTH = 33; // equivalent to "http://purl.org/goodrelations/v1#".Length

            var en = token.ToString();
            var enumString = en.Contains(OPENACTIVE_IO) ? en.Substring(OPENACTIVE_IO_LENGTH) :
                en.Contains(SCHEMA_ORG) ? en.Substring(SCHEMA_ORG_LENGTH) :
                en.Contains(SCHEMA_ORG_HTTPS) ? en.Substring(SCHEMA_ORG_HTTPS_LENGTH) :
                en.Contains(GOOD_RELATIONS) ? en.Substring(GOOD_RELATIONS_LENGTH) : en;
            return Enum.Parse(unwrappedType, enumString);
        }

        private static object ParseTokenArguments(JToken token, JsonToken tokenType, Type type, object value)
        {
            object args;
            var unwrappedType = type.GetUnderlyingTypeFromNullable();
            if (unwrappedType.GetTypeInfo().IsEnum)
            {
                args = ParseEnum(token, unwrappedType);
            }
            else
            {
                if (tokenType == JsonToken.StartObject)
                {
                    args = ParseTokenObjectArguments(token, type, unwrappedType);
                }
                else
                {
                    args = ParseTokenValueArguments(token, tokenType, type, unwrappedType, value);
                }
            }

            return args;
        }

        internal static object ParseTokenObjectArguments(JToken token, Type type, Type unwrappedType)
        {
            object args = null;
            var typeName = GetTypeNameFromToken(token);
            if (string.IsNullOrEmpty(typeName))
            {
                args = token.ToObjectWithoutContext(unwrappedType);
            }
            else if (typeName == type.Name)
            {
                args = token.ToObjectWithoutContext(type);
            }
            else
            {
                var builtType = Type.GetType($"{NamespacePrefix}{typeName}");
                if (builtType != null && type.GetTypeInfo().IsAssignableFrom(builtType.GetTypeInfo()))
                {
                    args = token.ToObjectWithoutContext(builtType);
                }
            }

            return args;
        }

        private static object ParseTokenValueArguments(JToken token, JsonToken tokenType, Type type, Type unwrappedType, object value)
        {
            object args = null;
            if (unwrappedType.IsPrimitiveType())
            {
                if (value is string)
                {
                    if (unwrappedType == typeof(string))
                    {
                        args = value;
                    }
                    else if (unwrappedType == typeof(int))
                    {
                        if (int.TryParse((string)value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i))
                        {
                            args = i;
                        }
                    }
                    else if (unwrappedType == typeof(long))
                    {
                        if (long.TryParse((string)value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i))
                        {
                            args = i;
                        }
                    }
                    else if (unwrappedType == typeof(float))
                    {
                        if (float.TryParse((string)value, NumberStyles.Float, CultureInfo.InvariantCulture, out var i))
                        {
                            args = i;
                        }
                    }
                    else if (unwrappedType == typeof(double))
                    {
                        if (double.TryParse((string)value, NumberStyles.Float, CultureInfo.InvariantCulture, out var i))
                        {
                            args = i;
                        }
                    }
                    else if (unwrappedType == typeof(bool))
                    {
                        if (bool.TryParse((string)value, out var i))
                        {
                            args = i;
                        }
                    }
                }
                else if (value is short || value is int || value is long || value is float || value is double)
                {
                    // Can safely convert between numeric types
                    if (unwrappedType == typeof(short) || unwrappedType == typeof(int) || unwrappedType == typeof(long) || unwrappedType == typeof(float) || unwrappedType == typeof(double))
                    {
                        args = Convert.ChangeType(value, unwrappedType, CultureInfo.InvariantCulture);
                    }
                }
                else if (value is bool)
                {
                    if (unwrappedType == typeof(bool))
                    {
                        args = value;
                    }
                }
                else if (value is DateTime || value is DateTimeOffset)
                {
                    // NO-OP: can't put a date into a primitive type
                }
                else
                {
                    args = value;
                }
            }
            else if (unwrappedType == typeof(decimal))
            {
                if (value is string)
                {
                    if (decimal.TryParse((string)value, NumberStyles.Currency, CultureInfo.InvariantCulture, out var i))
                    {
                        args = i;
                    }
                }
                else
                {
                    args = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
                }
            }
            else if (unwrappedType == typeof(DateTime))
            {
                if (value is string)
                {
                    if (DateTime.TryParse((string)value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var i))
                    {
                        args = i;
                    }
                }
                else if (value is DateTime)
                {
                    args = value;
                }
                else if (value is DateTimeOffset)
                {
                    args = ((DateTimeOffset)value).DateTime;
                }
                else if (value is short || value is int || value is long || value is float || value is double)
                {
                    // NO-OP: can't put a primitive type into a date
                }
                else
                {
                    args = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                }
            }
            else if (unwrappedType == typeof(DateTimeOffset))
            {
                if (value is string)
                {
                    if (DateTimeOffset.TryParse((string)value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var i))
                    {
                        args = i;
                    }
                }
                else if (value is DateTime)
                {
                    args = new DateTimeOffset((DateTime)value);
                }
                else if (value is DateTimeOffset)
                {
                    args = value;
                }
                else
                {
                    args = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                }
            }
            else
            {
                var classType = ToClass(type);
                if (tokenType == JsonToken.String)
                {
                    if (classType == typeof(Uri))
                    {
                        // REVIEW: Avoid invalid URIs being assigned as URI (Should we only allow absolute URIs?)
                        if (Uri.TryCreate((string)value, UriKind.Absolute, out var i))
                        {
                            args = i;
                        }
                    }
                }

                // REVIEW: If argument still not assigned, only use ToObject if not casting primitive to interface or class
                if (args == null)
                {
                    if (!type.GetTypeInfo().IsInterface && !type.GetTypeInfo().IsClass)
                    {
                        args = token.ToObjectWithoutContext(classType); // This is expected to throw on some case
                    }
                }
            }

            return args;
        }

        /// <summary>
        /// Gets the class type definition.
        /// </summary>
        /// <param name="type">The type under consideration.</param>
        /// <returns>
        /// The implementing class for <paramref name="type" /> or <paramref name="type" /> if it is already a class.
        /// </returns>
        private static Type ToClass(Type type)
        {
            if (type.GetTypeInfo().IsInterface)
            {
                return Type.GetType($"{type.Namespace}.{type.Name.Substring(1)}");
            }

            return type;
        }


        private static IList ReadJsonArray(JToken token, Type type, int? count = null)
        {
            var classType = ToClass(type);
            var listType = typeof(List<>).MakeGenericType(type); // always read into list of interfaces
            var list = Activator.CreateInstance(listType);
            var i = 0;

            if (count == null)
            {
                // if maximum item count not assigned, set to count of child tokens
                count = token.Children().Count();
            }

            foreach (var childToken in token.Children())
            {
                var typeName = GetTypeNameFromToken(childToken);
                if (string.IsNullOrEmpty(typeName))
                {
                    // Edge case for strings, to ensure assignment to objects is not attempted if the object is not a string or enum
                    if (childToken.Type == JTokenType.String && classType != typeof(string) && !classType.GetTypeInfo().IsEnum)
                    {
                        // Do nothing, as this child type does not match
                    }
                    else
                    {
                        var child = classType.GetTypeInfo().IsEnum ? 
                            ParseEnum(childToken, type) 
                            : childToken.ToObjectWithoutContext(classType);
                        var method = listType.GetRuntimeMethod(nameof(List<object>.Add), new[] { classType });

                        if (method != null)
                        {
                            method.Invoke(list, new object[] { child });

                            i++;
                        }
                    }
                }
                else
                {
                    var builtType = Type.GetType($"{NamespacePrefix}{typeName}");
                    if (builtType != null && type.GetTypeInfo().IsAssignableFrom(builtType.GetTypeInfo()))
                    {
                        var child = (Schema.NET.JsonLdObject)childToken.ToObjectWithoutContext(builtType);
                        var method = listType.GetRuntimeMethod(nameof(List<object>.Add), new[] { classType });

                        if (method != null)
                        {
                            method.Invoke(list, new object[] { child });

                            i++;
                        }
                    }
                }

                if (i == count)
                {
                    break;
                }
            }

            return (IList)list;
        }

        private static string GetTypeNameFromToken(JToken token)
        {
            var o = token as JObject;
            return o?.SelectToken("@type")?.ToString().Replace("beta:", ""); // Ignore beta type prefix
        }
    }

    public static class TokenExtensions
    {
        public static object ToObjectWithoutContext(this JToken token, Type objectType)
        {
            //Remove the "@context" from the object to ensure it is properly set during serialisation
            //(as serialisation uses a basic find/replace approach assuming the context is set to its default value)
            var o = token as JObject;
            var p = o?.SelectToken("@context")?.Parent;
            if (p != null) p.Remove();

            return token.ToObject(objectType);
        }
    }
}
