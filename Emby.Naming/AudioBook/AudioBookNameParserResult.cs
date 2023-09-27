using System;
using System.Numerics;

namespace Emby.Naming.AudioBook
{
    /// <summary>
    /// Data object used to pass result of name and year parsing.
    /// </summary>
    public struct AudioBookNameParserResult : IEquatable<AudioBookNameParserResult>
    {
        /// <summary>
        /// Gets or sets name of audiobook.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets optional year of release.
        /// </summary>
        public int? Year { get; set; }

        /// <inheritdoc cref="IEqualityOperators{TSelf,TOther,TResult}.op_Equality(TSelf, TOther)" />
        public static bool operator ==(AudioBookNameParserResult left, AudioBookNameParserResult right)
        {
            return left.Equals(right);
        }

        /// <inheritdoc cref="IEqualityOperators{TSelf,TOther,TResult}.op_Inequality(TSelf, TOther)" />
        public static bool operator !=(AudioBookNameParserResult left, AudioBookNameParserResult right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is not AudioBookNameParserResult audioBookNameParserResult)
            {
                return false;
            }

            return Equals(audioBookNameParserResult);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(Name, Year);

        /// <summary>
        /// Determine whether the specified object equals to the current object.
        /// </summary>
        /// <param name="other">the object to compare to.</param>
        /// <returns>true if the the specified object is equal to the current object; otherwise false.</returns>
        public bool Equals(AudioBookNameParserResult other) =>
            Name.Equals(other.Name, StringComparison.Ordinal) && Nullable.Equals(Year, other.Year);
    }
}
