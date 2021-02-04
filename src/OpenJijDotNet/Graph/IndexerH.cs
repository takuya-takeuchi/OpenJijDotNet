using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public sealed class IndexerH<T>
    {

        #region Fields

        private readonly Implement<T> _Implement;

        private readonly IntPtr _Owner;

        #endregion

        #region Constructors 

        internal IndexerH(IntPtr owner, Implement<T> implement)
        {
            if (implement == null)
                throw new ArgumentNullException(nameof(implement));

            this._Owner = owner;
            this._Implement = implement;
        }

        #endregion

        #region Properties

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
