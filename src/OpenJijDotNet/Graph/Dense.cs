using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public sealed class Dense<T> : Graph
        where T: struct
    {

        #region Fields

        private Implement<T> _Implement;

        private IndexerJ<T> _IndexerJ;

        private IndexerH<T> _IndexerH;

        #endregion

        #region Constructors

        public Dense(uint spins)
        {
            if (!TryParse(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this.FloatType = type;
            this.NativePtr = this.Create(spins);
        }

        #endregion

        #region Properties

        internal override NativeMethods.FloatTypes FloatType
        {
            get;
        }

        internal override NativeMethods.GraphTypes GraphType
        {
            get => NativeMethods.GraphTypes.Dense;
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

        private IntPtr Create(uint spins)
        {
            this._Implement = CreateImp();
            var owner = this._Implement.Create(spins);
            this._IndexerJ = new IndexerJ<T>(owner, this._Implement);
            this._IndexerH = new IndexerH<T>(owner, this._Implement);
            return owner;
        }

        private static Implement<T> CreateImp()
        {
            if (GrpahElementTypesRepository.SupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case NativeMethods.FloatTypes.Double:
                        return new DoubleImplement() as Implement<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        #region Implement
    
        internal abstract class Implement<T>
        {

            #region Methods

            public abstract IntPtr Create(uint spins);

            public abstract void Dispose(IntPtr ptr);

            public abstract uint GetNumSpins(IntPtr ptr);

            public abstract T GetJ(IntPtr ptr, uint i, uint j);

            public abstract void SetJ(IntPtr ptr, uint i, uint j, T value);

            public abstract T GetH(IntPtr ptr, uint i);

            public abstract void SetH(IntPtr ptr, uint i, T value);

            #endregion

        }

        internal sealed class DoubleImplement : Implement<double>
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
            
            public override uint GetNumSpins(IntPtr ptr)
            {
                NativeMethods.graph_Dense_double_get_num_spins(ptr, out var spins);
                return spins;
            }

            public override double GetJ(IntPtr ptr, uint i, uint j)
            {
                NativeMethods.graph_Dense_double_get_J(ptr, i, j, out var value);
                return value;
            }

            public override void SetJ(IntPtr ptr, uint i, uint j, double value)
            {
                NativeMethods.graph_Dense_double_set_J(ptr, i, j, value);
            }

            public override double GetH(IntPtr ptr, uint i)
            {
                NativeMethods.graph_Dense_double_get_h(ptr, i, out var value);
                return value;
            }

            public override void SetH(IntPtr ptr, uint i, double value)
            {
                NativeMethods.graph_Dense_double_set_h(ptr, i, value);
            }

            #endregion

        }

        #endregion

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

}
