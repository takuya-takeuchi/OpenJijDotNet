using System;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenJijDotNet
{
    public readonly struct Spin
    {

        #region Constructors

        public Spin(int value)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        public int Value
        {
            get;
        }

        #endregion

        #region Methods

        #region Overrids

        /// <summary>
        /// Specifies whether this <see cref="Spin"/> contains the same coordinates as the specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns><code>true</code> if <paramref name="obj"/> is a <see cref="Spin"/> and has the same coordinates as this <see cref="Spin"/>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Spin && Equals((Spin)obj);
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Spin"/>.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Spin"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Value * 397);
            }
        }

        /// <summary>
        /// Compares two <see cref="Spin"/> objects. The result specifies whether the values of the <see cref="Value"/> properties of the two <see cref="Spin"/> objects are equal.
        /// </summary>
        /// <param name="left">A <see cref="Spin"/> to compare.</param>
        /// <param name="right">A <see cref="Spin"/> to compare.</param>
        /// <returns><code>true</code> if the <see cref="Value"/> values of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <code>false</code>.</returns>
        public static bool operator ==(Spin left, Spin right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="Spin"/> objects. The result specifies whether the values of the <see cref="Value"/> properties of the two <see cref="Spin"/> objects are unequal.
        /// </summary>
        /// <param name="left">A <see cref="Spin"/> to compare.</param>
        /// <param name="right">A <see cref="Spin"/> to compare.</param>
        /// <returns><code>true</code> if the values of either the <see cref="H"/> properties or the <see cref="S"/> properties or the <see cref="I"/> properties of <paramref name="left"/> and <paramref name="right"/> differ; otherwise, <code>false</code>.</returns>
        public static bool operator !=(Spin left, Spin right)
        {
            return !left.Equals(right);
        }

        #endregion

        #endregion

    }

}