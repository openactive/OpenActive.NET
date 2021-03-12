namespace OpenActive.NET
{
    using System;
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A single or list of values which can be any of the specified types.
    /// </summary>
    /// <typeparam name="T">The first type the values can take.</typeparam>
    /// <typeparam name="Uri">The second type the values can take.</typeparam>
    /// <seealso cref="IValue" />
    public struct ReferenceValue<T> : IValue, IEquatable<ReferenceValue<T>> where T : class
    {
        private readonly T valueObject;
        private readonly Uri valueId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceValue{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T"/>.</param>
        public ReferenceValue(T value)
        {
            this.valueObject = value;
            this.valueId = default;
            this.HasValueObject = true;
            this.HasValueId = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceValue{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type Uri.</param>
        public ReferenceValue(Uri value)
        {
            this.valueObject = default;
            this.valueId = value;
            this.HasValueObject = false;
            this.HasValueId = true;
        }

        /// <summary>
        /// Gets the JSON-LD object representing the instance.
        /// </summary>
        public T Object
        {
            get
            {
                if (HasValueObject)
                {
                    return this.valueObject;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the Url representing the instance.
        /// </summary>
        public Uri Id
        {
            get
            {
                if (HasValueId)
                {
                    return this.valueId;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the Url or JSON-LD object representing the instance.
        /// </summary>
        public object Value
        {
            get
            {
                if (HasValueObject)
                {
                    return this.valueObject;
                }
                else if (HasValueId)
                {
                    return this.valueId;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has a value.
        /// </summary>
        public bool HasValue => this.HasValueObject || this.HasValueId;

        /// <summary>
        /// Gets whether the value of type <typeparamref name="T" /> has a value. This is internal as the order of values may change over time.
        /// </summary>
        internal bool HasValueObject { get; }

        /// <summary>
        /// Gets whether the value of type Uri has a value. This is internal as the order of values may change over time.
        /// </summary>
        internal bool HasValueId { get; }

        /// <summary>
        /// Performs an implicit conversion from <typeparamref name="T"/> to <see cref="ReferenceValue{T}"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ReferenceValue<T>(T item) => item.IsNullEmptyOrWhiteSpace() ? default : new ReferenceValue<T>(item);

        /// <summary>
        /// Performs an implicit conversion from Uri to <see cref="ReferenceValue{T}"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ReferenceValue<T>(Uri item) => item.IsNullEmptyOrWhiteSpace() ? default : new ReferenceValue<T>(item);


        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(ReferenceValue<T> left, ReferenceValue<T> right) => left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(ReferenceValue<T> left, ReferenceValue<T> right) => !(left == right);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(ReferenceValue<T> other)
        {
            if (other.HasValueObject)
            {
                if (this.HasValueObject)
                {
                    return this.valueObject.Equals(other.valueObject);
                }
            }
            else if (other.HasValueId)
            {
                if (this.HasValueId)
                {
                    return this.valueId.Equals(other.valueId);
                }
            }
            else if (!other.HasValue && !this.HasValue)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is ReferenceValue<T> ? this.Equals((ReferenceValue<T>)obj) : false;

        /// <summary>
        /// Implements ToString
        /// </summary>
        /// <returns>
        /// A string representing the relevant value
        /// </returns>
        public override string ToString()
        {
            if (this.HasValueObject)
            {
                return this.valueObject.ToString();
            }
            else if (this.HasValueId)
            {
                return this.valueId.ToString();
            }
            return ((string)null).ToString();
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => Schema.NET.HashCode.Of(this.valueObject).And(this.valueId);
    }
}
