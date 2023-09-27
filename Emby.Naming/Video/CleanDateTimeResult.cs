using System;
using System.Numerics;

namespace Emby.Naming.Video
{
    /// <summary>
    /// Holder structure for name and year.
    /// </summary>
    public readonly struct CleanDateTimeResult : IEquatable<CleanDateTimeResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CleanDateTimeResult"/> struct.
        /// </summary>
        /// <param name="name">Name of video.</param>
        /// <param name="year">Year of release.</param>
        public CleanDateTimeResult(string name, int? year = null)
        {
            Name = name;
            Year = year;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public int? Year { get; }

        /// <inheritdoc cref="IEqualityOperators{TSelf,TOther,TResult}.op_Equality(TSelf, TOther)" />
        public static bool operator ==(CleanDateTimeResult left, CleanDateTimeResult right)
        {
            return left.Equals(right);
        }

        /// <inheritdoc cref="IEqualityOperators{TSelf,TOther,TResult}.op_Inequality(TSelf, TOther)" />
        public static bool operator !=(CleanDateTimeResult left, CleanDateTimeResult right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is not CleanDateTimeResult cleanDateTimeResult)
            {
                return false;
            }

            return Equals(cleanDateTimeResult);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(Name, Year);

        /// <summary>
        /// Determine whether the specified object equals to the current object.
        /// </summary>
        /// <param name="other">the object to compare to.</param>
        /// <returns>true if the the specified object is equal to the current object; otherwise false.</returns>
        public bool Equals(CleanDateTimeResult other) =>
            Name.Equals(other.Name, StringComparison.Ordinal)
            && Nullable.Equals(Year, other.Year);
    }
}
