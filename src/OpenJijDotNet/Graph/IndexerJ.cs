using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public sealed class IndexerJ<T>
    {

        #region Fields

        private readonly Implement<T> _Implement;

        private readonly IntPtr _Owner;

        #endregion

        #region Constructors 

        internal IndexerJ(IntPtr owner, Implement<T> implement)
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

        #endregion

    }

}
