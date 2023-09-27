using System;
using System.Numerics;

namespace Emby.Naming.AudioBook
{
    /// <summary>
    /// Represents a single video file.
    /// </summary>
    public class AudioBookFileInfo : IComparable<AudioBookFileInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioBookFileInfo"/> class.
        /// </summary>
        /// <param name="path">Path to audiobook file.</param>
        /// <param name="container">File type.</param>
        /// <param name="partNumber">Number of part this file represents.</param>
        /// <param name="chapterNumber">Number of chapter this file represents.</param>
        public AudioBookFileInfo(string path, string container, int? partNumber = default, int? chapterNumber = default)
        {
            Path = path;
            Container = container;
            PartNumber = partNumber;
            ChapterNumber = chapterNumber;
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; }

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>The container.</value>
        public string Container { get; }

        /// <summary>
        /// Gets the part number.
        /// </summary>
        /// <value>The part number.</value>
        public int? PartNumber { get; }

        /// <summary>
        /// Gets the chapter number.
        /// </summary>
        /// <value>The chapter number.</value>
        public int? ChapterNumber { get; }

        /// <inheritdoc cref="IEqualityOperators{TSelf,TOther,TResult}.op_Equality(TSelf, TOther)" />
        public static bool operator ==(AudioBookFileInfo left, AudioBookFileInfo right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <inheritdoc cref="IEqualityOperators{TSelf,TOther,TResult}.op_Inequality(TSelf, TOther)" />
        public static bool operator !=(AudioBookFileInfo left, AudioBookFileInfo right)
        {
            return !(left == right);
        }

        /// <inheritdoc cref="IComparisonOperators{TSelf,TOther,TResult}.op_LessThan(TSelf, TOther)" />
        public static bool operator <(AudioBookFileInfo left, AudioBookFileInfo right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <inheritdoc cref="IComparisonOperators{TSelf,TOther,TResult}.op_LessThanOrEqual(TSelf, TOther)" />
        public static bool operator <=(AudioBookFileInfo left, AudioBookFileInfo right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <inheritdoc cref="IComparisonOperators{TSelf,TOther,TResult}.op_GreaterThan(TSelf, TOther)" />
        public static bool operator >(AudioBookFileInfo left, AudioBookFileInfo right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <inheritdoc cref="IComparisonOperators{TSelf,TOther,TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
        public static bool operator >=(AudioBookFileInfo left, AudioBookFileInfo right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

        /// <inheritdoc />
        public int CompareTo(AudioBookFileInfo? other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            var chapterNumberComparison = Nullable.Compare(ChapterNumber, other.ChapterNumber);
            if (chapterNumberComparison != 0)
            {
                return chapterNumberComparison;
            }

            var partNumberComparison = Nullable.Compare(PartNumber, other.PartNumber);
            if (partNumberComparison != 0)
            {
                return partNumberComparison;
            }

            return string.Compare(Path, other.Path, StringComparison.Ordinal);
        }

        /// <summary>
        /// Determine whether the specified object equals to the current object.
        /// </summary>
        /// <param name="other">the object to compare to.</param>
        /// <returns>true if the the specified object is equal to the current object; otherwise false.</returns>
        private bool Equals(AudioBookFileInfo? other)
        {
            return CompareTo(other) == 0;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is not AudioBookFileInfo audioBookFileInfo)
            {
                return false;
            }

            return CompareTo(audioBookFileInfo) == 0;
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(Path, Container, PartNumber, ChapterNumber);
    }
}
