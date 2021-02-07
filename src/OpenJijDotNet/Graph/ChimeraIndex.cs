using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public struct ChimeraIndex : IEquatable<ChimeraIndex>
    {

        #region Constructors
        
        public ChimeraIndex(uint row, uint column, uint inChimera)
        {
            this.Row = row;
            this.Column = column;
            this.InChimera = inChimera;
        }

        #endregion

        #region Properties

        public uint Column
        {
            get;
        }

        public uint InChimera
        {
            get;
        }

        public uint Row
        {
            get;
        }

        #endregion

        #region Methods

        public bool Equals(ChimeraIndex other)
        {
            return this.Row == other.Row &&
                   this.Column == other.Column &&
                   this.InChimera == other.InChimera;
        }

        #region Overrids

        public override bool Equals(object obj)
        {
            return obj is ChimeraIndex && Equals((ChimeraIndex)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + this.Row.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Column.GetHashCode();
            hashCode = hashCode * -1521134295 + this.InChimera.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(ChimeraIndex chimeraInderow1, ChimeraIndex chimeraInderow2)
        {
            return chimeraInderow1.Equals(chimeraInderow2);
        }

        public static bool operator !=(ChimeraIndex chimeraInderow1, ChimeraIndex chimeraInderow2)
        {
            return !(chimeraInderow1 == chimeraInderow2);
        }

        #endregion

        #endregion

    }

}