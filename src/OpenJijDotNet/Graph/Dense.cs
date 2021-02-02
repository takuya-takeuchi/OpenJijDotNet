using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public sealed partial class Dense<TItem> : Graph
    {

        #region Fields

        private readonly DenseImp<TItem> _Imp;

        #endregion

        #region Constructors

        public Dense(uint spins) :
            base(spins)
        {
            this._Imp = CreateImp();
        }

        #endregion

        #region Properties

        public override uint Spins
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.GetNumSpins(this.NativePtr);
            }
        }

        // public TItem J[uint i, uint j]
        // {
        //     get
        //     {
        //         return default(TItem);
        //     }
        // }

        #endregion

        #region Methods

        #region Overrides

        protected override IntPtr Create(uint spins)
        {
            return this._Imp.Create(spins);
        }

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            this._Imp?.Dispose(this.NativePtr);
        }

        #endregion

        #region Helpers

        private static DenseImp<TItem> CreateImp()
        {
            if (DenseElementTypesRepository.SupportTypes.TryGetValue(typeof(TItem), out var type))
            {
                switch (type)
                {
                    case DenseElementTypesRepository.ElementTypes.Double:
                        return new DenseDoubleImp() as DenseImp<TItem>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        #region DenseImp

        private abstract class DenseImp<T>
        {

            #region Methods

            public abstract IntPtr Create(uint spins);

            public abstract void Dispose(IntPtr ptr);

            public abstract uint GetNumSpins(IntPtr dense);

            #endregion

        }

        private sealed class DenseDoubleImp : DenseImp<double>
        {

            #region Methods

            public override IntPtr Create(uint spins)
            {
                return NativeMethods.graph_Dense_double_new(spins);
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.graph_Dense_double_delete(ptr);
            }
            public override uint GetNumSpins(IntPtr dense)
            {
                NativeMethods.graph_Dense_double_get_num_spins(dense, out var spins);
                return spins;
            }

            #endregion

        }

        #endregion

    }

}
