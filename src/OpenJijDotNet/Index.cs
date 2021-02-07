namespace OpenJijDotNet
{
    public readonly struct Index
    {

        #region Constructors

        public Index(ulong value)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        public ulong Value
        {
            get;
        }

        #endregion

        #region Methods

        public bool Equals(Index other)
        {
            return this.Value == other.Value;
        }

        #region Overrids

        /// <summary>
        /// Specifies whether this <see cref="Index"/> contains the same coordinates as the specified <see cref="object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to test.</param>
        /// <returns><code>true</code> if <paramref name="obj"/> is a <see cref="Index"/> and has the same coordinates as this <see cref="Index"/>.</returns>
        public override bool Equals(object obj)
        {
            return obj is Index other && Equals(other);
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Index"/>.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Index"/>.</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{nameof(this.Value)}: {this.Value}";
        }

        /// <summary>
        /// Compares two <see cref="Index"/> objects. The result specifies whether the values of the <see cref="Value"/> properties of the two <see cref="Index"/> objects are equal.
        /// </summary>
        /// <param name="left">A <see cref="Index"/> to compare.</param>
        /// <param name="right">A <see cref="Index"/> to compare.</param>
        /// <returns><code>true</code> if the <see cref="Value"/> values of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <code>false</code>.</returns>
        public static bool operator ==(Index left, Index right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="Index"/> objects. The result specifies whether the values of the <see cref="Value"/> properties of the two <see cref="Index"/> objects are unequal.
        /// </summary>
        /// <param name="left">A <see cref="Index"/> to compare.</param>
        /// <param name="right">A <see cref="Index"/> to compare.</param>
        /// <returns><code>true</code> if the values of either the <see cref="H"/> properties or the <see cref="S"/> properties or the <see cref="I"/> properties of <paramref name="left"/> and <paramref name="right"/> differ; otherwise, <code>false</code>.</returns>
        public static bool operator !=(Index left, Index right)
        {
            return !left.Equals(right);
        }

        #endregion

        #endregion

    }

}