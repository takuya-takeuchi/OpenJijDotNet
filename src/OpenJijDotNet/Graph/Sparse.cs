using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public sealed partial class Sparse<T> : Graph
    {

        #region Fields

        private Implement<T> _Implement;

        private IndexerJ<T> _IndexerJ;

        private IndexerH<T> _IndexerH;

        #endregion

        #region Constructors

        public Sparse(uint spins) :
            base(spins)
        {
            if (!TryParse(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this.FloatType = type;
        }

        #endregion

        #region Properties

        internal override NativeMethods.FloatTypes FloatType
        {
            get;
        }

        internal override NativeMethods.GraphTypes GraphType
        {
            get => NativeMethods.GraphTypes.Sparse;
        }

        public IndexerH<T> H
        {
            get
            {
                this.ThrowIfDisposed();
                return this._IndexerH;
            }
        }

        public IndexerJ<T> J
        {
            get
            {
                this.ThrowIfDisposed();
                return this._IndexerJ;
            }
        }

        public override uint Spins
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Implement.GetNumSpins(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        internal static bool TryParse<T>(out NativeMethods.FloatTypes result)
            where T : struct
        {
            return TryParse(typeof(T), out result);
        }

        #region Overrides

        protected override IntPtr Create(uint spins)
        {
            this._Implement = CreateImp();
            var owner = this._Implement.Create(spins);
            this._IndexerJ = new IndexerJ<T>(owner, this._Implement);
            this._IndexerH = new IndexerH<T>(owner, this._Implement);
            return owner;
        }

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            this._Implement?.Dispose(this.NativePtr);
        }

        #endregion

        #region Helpers

        private static Implement<T> CreateImp()
        {
            if (GrpahElementTypesRepository.SupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case GrpahElementTypesRepository.ElementTypes.Double:
                        return new SparseDoubleImp() as Implement<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        #region Implement

        private sealed class SparseDoubleImp : Implement<double>
        {

            #region Methods

            public override IntPtr Create(uint spins)
            {
                return NativeMethods.graph_Sparse_double_new(spins);
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.graph_Sparse_double_delete(ptr);
            }
            public override uint GetNumSpins(IntPtr ptr)
            {
                NativeMethods.graph_Sparse_double_get_num_spins(ptr, out var spins);
                return spins;
            }

            public override double GetJ(IntPtr ptr, uint i, uint j)
            {
                NativeMethods.graph_Sparse_double_get_J(ptr, i, j, out var value);
                return value;
            }

            public override void SetJ(IntPtr ptr, uint i, uint j, double value)
            {
                NativeMethods.graph_Sparse_double_set_J(ptr, i, j, value);
            }

            public override double GetH(IntPtr ptr, uint i)
            {
                NativeMethods.graph_Sparse_double_get_h(ptr, i, out var value);
                return value;
            }

            public override void SetH(IntPtr ptr, uint i, double value)
            {
                NativeMethods.graph_Sparse_double_set_h(ptr, i, value);
            }

            #endregion

        }

        #endregion

    }

}
