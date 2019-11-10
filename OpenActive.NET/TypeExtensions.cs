using System;
using System.Collections;
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
    }
}
