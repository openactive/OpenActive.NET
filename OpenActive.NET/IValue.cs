using System;

namespace OpenActive.NET
{
    /// <summary>
    /// Get a single value from one or more values.
    /// </summary>
    public interface IValue
    {
        /// <summary>
        /// Gets the non-null object representing the instance, useful for switch statements
        /// </summary>
        object Value { get; }

        /// <summary>
        /// Gets the nullable primative representing the instance, if it is of the type specified.
        /// </summary>
        Nullable<T> GetPrimative<T>() where T : struct;

        /// <summary>
        /// Gets the object representing the instance, if it is of the type specified.
        /// </summary>
        T GetClass<T>() where T : class;

        /// <summary>
        /// Checks whether the instance represents the specified type
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        /// <returns>true/false if the matching type does / does not have a value, throws exception if T is unknown</returns>
        bool HasValueOfType<T>();
    }
}
