using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    internal sealed class Indexer<T>
    {

        #region Fields

        protected readonly Implement<T> _Implement;

        public readonly IntPtr _Owner;

        #endregion

        #region Constructors 

        public Indexer(IntPtr owner, Implement<T> implement)
        {
            if (implement == null)
                throw new ArgumentNullException(nameof(implement));

            this._Owner = owner;
            this._Implement = implement;
        }

        #endregion

        #region Properties

        public T this[uint i, uint j]
        {
            get
            {
                return this._Implement.GetJ(this._Owner, i, j);
            }
            set
            {
                this._Implement.SetJ(this._Owner, i, j, value);
            }
        }

        public T this[uint i]
        {
            get
            {
                return this._Implement.GetH(this._Owner, i);
            }
            set
            {
                this._Implement.SetH(this._Owner, i, value);
            }
        }

        #endregion

    }

}
