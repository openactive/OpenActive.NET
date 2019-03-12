namespace OpenActive.NET
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A single or list of values which can be any of the specified types.
    /// </summary>
    /// <typeparam name="T1">The first type the values can take.</typeparam>
    /// <typeparam name="T2">The second type the values can take.</typeparam>
    /// <typeparam name="T3">The third type the values can take.</typeparam>
    /// <seealso cref="IValue" />
    public class SingleValues<T1, T2, T3> : IValue
    {
        private readonly T1 value1;
        private readonly T2 value2;
        private readonly T3 value3;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleValues{T1,T2,T3}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T1"/>.</param>
        public SingleValues(T1 value)
        {
            this.value1 = value;
            this.value2 = default;
            this.value3 = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleValues{T1,T2,T3}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T2"/>.</param>
        public SingleValues(T2 value)
        {
            this.value1 = default;
            this.value2 = value;
            this.value3 = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleValues{T1,T2,T3}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T3"/>.</param>
        public SingleValues(T3 value)
        {
            this.value1 = default;
            this.value2 = default;
            this.value3 = value;
        }

        /// <summary>
        /// Gets the value of type <typeparamref name="T1" />.
        /// </summary>
        public T1 Value1 => this.value1;

        /// <summary>
        /// Gets the value of type <typeparamref name="T2" />.
        /// </summary>
        public T2 Value2 => this.value2;

        /// <summary>
        /// Gets the value of type <typeparamref name="T3" />.
        /// </summary>
        public T3 Value3 => this.value3;

        /// <summary>
        /// Gets the non-null object representing the instance.
        /// </summary>
        object IValue.Value
        {
            get
            {
                if (this.value1 != default)
                {
                    return this.value1;
                }
                else if (this.value2 != default)
                {
                    return this.value2;
                }
                else if (this.value3 != default)
                {
                    return this.value3;
                }

                return null;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <typeparamref name="T1"/> to <see cref="SingleValues{T1,T2}"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator SingleValues<T1, T2, T3>(T1 item) => item == null || (item.GetType() == typeof(string) && string.IsNullOrWhiteSpace(item as string)) || (item as ICollection)?.Count == 0 ? null : new SingleValues<T1, T2, T3>(item);

        /// <summary>
        /// Performs an implicit conversion from <typeparamref name="T2"/> to <see cref="SingleValues{T1,T2}"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator SingleValues<T1, T2, T3>(T2 item) => item == null || (item.GetType() == typeof(string) && string.IsNullOrWhiteSpace(item as string)) || (item as ICollection)?.Count == 0 ? null : new SingleValues<T1, T2, T3>(item);

        /// <summary>
        /// Performs an implicit conversion from <typeparamref name="T3"/> to <see cref="SingleValues{T1,T2}"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator SingleValues<T1, T2, T3>(T3 item) => item == null || (item.GetType() == typeof(string) && string.IsNullOrWhiteSpace(item as string)) || (item as ICollection)?.Count == 0 ? null : new SingleValues<T1, T2, T3>(item);
    }
}
