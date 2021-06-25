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
    public struct TimeValue : IValue, INullableValue, IEquatable<TimeValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeValue"/> class.
        /// The date and timezone component of the supplied DateTimeOffset will be truncated.
        /// </summary>
        /// <param name="value">The value of property.</param>
        public TimeValue(DateTimeOffset? value)
        {
            if (value.HasValue)
            {
                this.NullableValue = new DateTimeOffset(1, 1, 1, value.Value.Hour, value.Value.Minute, 0, TimeSpan.Zero);
            }
            else
            {
                this.NullableValue = null;
            }
        }

        public TimeValue(int hours, int minutes)
        {
            DateTimeOffset dateTime = DateTimeOffset.MinValue;
            dateTime.AddHours(hours);
            dateTime.AddMinutes(minutes);
            this.NullableValue = dateTime;
        }

        public TimeValue(string value)
        {
            if (DateTime.TryParseExact(value, "HH:mm", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces, out var result))
            {
                this.NullableValue = new DateTimeOffset(result);
            }
            else if (DateTime.TryParseExact(value, "HH:mm:ss", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces, out var i))
            {
                this.NullableValue = new DateTimeOffset(i);
            } 
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Time parsing failed for '{value}'");
            }
        }

        /// <summary>
        /// Gets the value of the current TimeValue object if it has been assigned an underlying value.
        /// </summary>
        public DateTimeOffset Value { get => NullableValue.Value; }

        /// <summary>
        /// Gets the value of Hour of the current TimeValue object if it has been assigned an underlying value.
        /// </summary>
        public int? Hour { get => NullableValue?.Hour; }

        /// <summary>
        /// Gets the value of Minute of the current TimeValue object if it has been assigned an underlying value.
        /// </summary>
        public int? Minute { get => NullableValue?.Minute; }

        /// <summary>
        /// Gets the value of the underlying DateTimeOffset? object as a Nullable<> type.
        /// </summary>
        public DateTimeOffset? NullableValue { get; private set; }

        /// <summary>
        /// Gets the value indicating whether the TimeValue object has a valid value of its underlying type
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
        /// Performs an implicit conversion from DateTimeOffset to <see cref="TimeValue"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TimeValue(DateTimeOffset? item) => !item.HasValue ? default : new TimeValue(item);

        /// <summary>
        /// Performs an implicit conversion from string to <see cref="TimeValue"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator TimeValue(string item) => item.IsNullEmptyOrWhiteSpace() ? default : new TimeValue(item);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(TimeValue left, TimeValue right) => left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(TimeValue left, TimeValue right) => !(left == right);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(TimeValue other) => this.NullableValue.Equals(other.NullableValue);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is TimeValue ? this.Equals((TimeValue)obj) : false;

        /// <summary>
        /// Returns the value in "HH:mm" format
        /// </summary>
        /// <returns>
        /// A string representing the relevant value
        /// </returns>
        public override string ToString()
        {
            if (this.NullableValue.HasValue) {
                return this.NullableValue.Value.ToString("HH:mm");
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
