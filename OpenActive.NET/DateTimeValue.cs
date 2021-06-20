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
    public struct DateTimeValue : IValue, INullableValue, IEquatable<DateTimeValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeValue"/> class.
        /// </summary>
        /// <param name="value">The value of property.</param>
        /// <param name="isDateOnly">Whether or not the value represents only a date.</param>
        public DateTimeValue(DateTimeOffset? value, bool isDateOnly)
        {
            if (isDateOnly && value.HasValue && (value.Value.Hour != 0 || value.Value.Minute != 0 || value.Value.Second != 0 || value.Value.Millisecond != 0))
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must not include a time component if isDateOnly is used.");
            }
            this.NullableValue = value;
            this.IsDateOnly = isDateOnly;
        }

        public DateTimeValue(string value)
        {
            if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces, out var result))
            {
                this.NullableValue = new DateTimeOffset(result);
                this.IsDateOnly = true;
            }
            else if(DateTime.TryParse((string)value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var i))
            {
                this.NullableValue = new DateTimeOffset(i);
                this.IsDateOnly = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Date/time parsing failed for '{value}'");
            }
        }
        

        /// <summary>
        /// Gets the value of the current DateTimeValue object if it has been assigned an underlying value.
        /// </summary>
        public DateTimeOffset Value { get => NullableValue.Value; }

        /// <summary>
        /// Gets the value of the underlying DateTimeOffset? object as a Nullable<> type.
        /// </summary>
        public DateTimeOffset? NullableValue { get; private set; }

        /// <summary>
        /// Gets the value indicating whether the DateTimeValue object has a valid value
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
        /// Indicating whether the value represents only a date (true) or a date with time (false).
        /// </summary>
        public bool IsDateOnly { get; set; }

        /// <summary>
        /// Performs an implicit conversion from DateTimeOffset to <see cref="DateTimeValue"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DateTimeValue(DateTimeOffset? item) => !item.HasValue ? default : new DateTimeValue(item, false);

        /// <summary>
        /// Performs an implicit conversion from string to <see cref="DateTimeValue"/>.
        /// </summary>
        /// <param name="item">The single item value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DateTimeValue(string item) => item.IsNullEmptyOrWhiteSpace() ? default : new DateTimeValue(new DateTimeOffset(DateTime.ParseExact(item, "yyyy-MM-dd", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces)), true);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(DateTimeValue left, DateTimeValue right) => left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(DateTimeValue left, DateTimeValue right) => !(left == right);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(DateTimeValue other) => this.NullableValue.Equals(other.NullableValue) && this.IsDateOnly.Equals(other.IsDateOnly);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is DateTimeValue ? this.Equals((DateTimeValue)obj) : false;

        /// <summary>
        /// Returns the value in "yyyy-MM-dd" format (if IsDateOnly) or "yyyy-MM-ddTHH:mm:sszzz" format otherwise
        /// </summary>
        /// <returns>
        /// A string representing the relevant value
        /// </returns>
        public override string ToString()
        {
            if (this.NullableValue.HasValue) {
                return IsDateOnly ? this.NullableValue.Value.ToString("yyyy-MM-dd") : this.NullableValue.Value.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
            }
            return null;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => Schema.NET.HashCode.Of(this.NullableValue).And(this.IsDateOnly);
    }
}
