using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public struct RowColumn : IEquatable<RowColumn>
    {

        #region Constructors
        
        public RowColumn(uint row, uint column)
        {
            this.Row = row;
            this.Column = column;
        }

        #endregion

        #region Properties

        public uint Row
        {
            get;
        }

        public uint Column
        {
            get;
        }

        #endregion

        #region Methods

        public bool Equals(RowColumn other)
        {
            return this.Row == other.Row &&
                   this.Column == other.Column;
        }

        #region Overrids

        public override bool Equals(object obj)
        {
            return obj is RowColumn && Equals((RowColumn)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + this.Row.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Column.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(RowColumn rowColumn1, RowColumn rowColumn2)
        {
            return rowColumn1.Equals(rowColumn2);
        }

        public static bool operator !=(RowColumn rowColumn1, RowColumn rowColumn2)
        {
            return !(rowColumn1 == rowColumn2);
        }

        #endregion

        #endregion

    }

}