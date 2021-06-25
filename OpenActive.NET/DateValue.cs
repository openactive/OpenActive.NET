namespace OpenActive.NET
{
    using System;
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// A value representing a DateTimeOffset that is parsed and rendered as either a date or a date with a time
    /// </summary>
    /// <seealso cref="IValue" />
    public struct DateValue : IValue, INullableValue, IEquatable<DateValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateValue"/> class.
        /// </summary>
        /// <param name="value">The value of property.</param>
        public DateValue(DateTimeOffset? value)
        {
            if (value.HasValue && (value.Value.Hour != 0 || value.Value.Minute != 0 || value.Value.Second != 0 || value.Value.Millisecond != 0))
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must not include a time component.");
            }
            this.NullableValue = value;
        }

        public DateValue(int year, int month, int day) : this(new DateTimeOffset(year, month, day, 0, 0, 0, new TimeSpan()))
        {
        }

        public DateValue(string value)
        {
            if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces, out DateTime result))
            {
                this.NullableValue = new DateTimeOffset(result);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Date parsing failed for '{value}'");
            }
        }

        /// <summary>
        /// Gets the value of the current DateValue object if it has been assigned an underlying value.
        /// </summary>
        public DateTimeOffset Value { get => NullableValue.Value; }

        /// <summary>
        /// Gets the value of the underlying DateTimeOffset? object as a Nullable<> type.
        /// </summary>
        public DateTimeOffset? NullableValue { get; private set; }

        /// <summary>
        /// Gets the value indicating whether the DateValue object has a valid value of its underlying type
        /// </summary>
        public bool HasValue { get => NullableValue.HasValue; }

        /// <summary>
        /// Retrieves the value of the current object or the object's default value
        /// </summary>
        public DateTimeOffset GetValueOrDefault()
        {
            return NullableValue.GetValueOrDefault();
        }

        /// <summary>
        /// Gets the value
        /// </summary>
        object IValue.Value
        {
            get => this.NullableValue;
        }

        /// <summary>
        /// Performs an implicit conversion from DateTimeOffset to <see cref="DateValue"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DateValue(DateTimeOffset? item) => !item.HasValue ? default : new DateValue(item);

        /// <summary>
        /// Performs an implicit conversion from string to <see cref="DateValue"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DateValue(string item) => item.IsNullEmptyOrWhiteSpace() ? default : new DateValue(item);

        /// <summary>
        /// Performs an implicit conversion from DateValue to DateTimeOffset.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DateTimeOffset?(DateValue item) => item.NullableValue;

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(DateValue left, DateValue right) => left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(DateValue left, DateValue right) => !(left == right);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(DateValue other) => this.NullableValue.Equals(other.NullableValue);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is DateValue ? this.Equals((DateValue)obj) : false;

        /// <summary>
        /// Returns the value in "yyyy-MM-dd" format
        /// </summary>
        /// <returns>
        /// A string representing the relevant value
        /// </returns>
        public override string ToString()
        {
            if (this.NullableValue.HasValue) {
                return this.NullableValue.Value.ToString("yyyy-MM-dd");
            }
            return null;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => Schema.NET.HashCode.Of(this.NullableValue);
    }
}
