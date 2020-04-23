using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenActive.NET
{
    /// <summary>
    /// Extensions provided to the library use that are useful for creating values to set in the model
    /// </summary>
    public static class ValuesExtensions
    {
        /// <summary>
        /// Return null if the provided URL is empty, otherwise return null.
        /// </summary>
        public static Uri ParseUrlOrNull(this string str)
        {
            if (Uri.TryCreate(str, UriKind.Absolute, out Uri url))
            {
                return url;
            }
            else
            {
                return null;
            }
        }

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
    }
}
