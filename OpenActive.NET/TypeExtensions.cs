using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace OpenActive.NET
{
    internal static class TypeExtensions
    {
        public static bool IsNullable(this Type type) =>
            type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

        public static bool IsPrimitiveType(this Type type) => type.GetTypeInfo().IsPrimitive || type == typeof(string);

        public static Type GetUnderlyingTypeFromNullable(this Type type) =>
            type.IsNullable() ? Nullable.GetUnderlyingType(type) : type;

        /// <summary>
        /// Checks whether the generic T item is a string that is either null or contains whitespace.
        /// </summary>
        /// <returns>
        /// Returns true if the supplied item is a string that is null or contains whitespace.
        /// </returns>
        public static bool IsNullEmptyOrWhiteSpace<T>(this T item) => 
            item == null 
            || (item != null && item.GetType() == typeof(string) && string.IsNullOrWhiteSpace(item as string)) 
            || (item as ICollection)?.Count == 0;

        /// <summary>
        /// Checks whether the instance represents the specified type
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        /// <returns>true/false if the matching type does / does not have a value that is assignable to T, throws exception if T is unknown</returns>
        public static bool HasValueOfType<T>(List<(Type Tx, bool hasValue, object value)> list)
        {
            foreach((Type Tx, bool hasValue, object value) in list)
            {
                if (typeof(T) == Tx || typeof(T).GetTypeInfo().IsSubclassOf(Tx))
                {
                    if (hasValue && value != null)
                    {
                        return typeof(T).GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo());
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            throw new TypeAccessException("HasValueOfType was used with a type that is not available.");
        }

        /// <summary>
        /// Gets the object representing the instance, if it is of the type specified.
        /// </summary>
        public static T GetClass<T>(List<(Type Tx, bool hasValue, object value)> list) where T : class
        {
            foreach ((Type Tx, bool hasValue, object value) in list)
            {
                if (typeof(T) == Tx || typeof(T).GetTypeInfo().IsSubclassOf(Tx))
                {
                    if (hasValue && value != null)
                    {
                        if (typeof(T).GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo()))
                        {
                            return (T)value;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            throw new TypeAccessException("GetClass was used with a type that is not available.");
        }
    }
}
