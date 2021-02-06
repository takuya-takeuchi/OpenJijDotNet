using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public sealed class Square<T> : Sparse<T>
        where T: struct
    {

        #region Fields

        private Implement<T> _Implement;

        private IndexerJ<T> _IndexerJ;

        private IndexerH<T> _IndexerH;

        #endregion

        #region Constructors

        public Square(uint row, uint column, T initValue)
        {
            if (!TryParse(typeof(T), out var type))
                throw new NotSupportedException($"{typeof(T).Name} does not support");

            this.FloatType = type;
            this.NativePtr = this.Create(row, column, initValue);
        }

        #endregion

        #region Properties

        internal override NativeMethods.FloatTypes FloatType
        {
            get;
        }

        internal override NativeMethods.GraphTypes GraphType
        {
            get => NativeMethods.GraphTypes.Square;
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

        private IntPtr Create(uint row, uint column, T initValue)
        {
            this._Implement = CreateImp();
            var owner = this._Implement.Create(row, column, initValue);
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
                    case GrpahElementTypesRepository.ElementTypes.Double:
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

            public abstract IntPtr Create(uint numRow, uint numColumn, T initVal);

            public abstract void Dispose(IntPtr ptr);

            public abstract uint GetNumSpins(IntPtr ptr);

            public abstract T GetJ(IntPtr ptr, uint r, uint c, Direction direction);

            public abstract void SetJ(IntPtr ptr, uint r, uint c, Direction direction, T value);

            public abstract T GetH(IntPtr ptr, uint r, uint c);

            public abstract void SetH(IntPtr ptr, uint r, uint c, T value);
            
            public abstract uint GetNumRow(IntPtr ptr);
            
            public abstract uint GetNumColumn(IntPtr ptr);
            
            public abstract Spin GetSpin(IntPtr ptr, uint r, uint c);
            
            public abstract void SetSpin(IntPtr ptr, uint r, uint c, Spin spin);

            #endregion

        }

        internal sealed class DoubleImplement : Implement<double>
        {

            #region Methods

            public override IntPtr Create(uint numRow, uint numColumn, double initVal)
            {
                return NativeMethods.graph_Square_double_new(numRow, numColumn, initVal);
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.graph_Square_double_delete(ptr);
            }
            
            public override uint GetNumSpins(IntPtr ptr)
            {
                NativeMethods.graph_Square_double_get_num_spins(ptr, out var spins);
                return spins;
            }

            public override double GetJ(IntPtr ptr, uint r, uint c, Direction direction)
            {
                NativeMethods.graph_Square_double_get_J(ptr, r, c, direction, out var value);
                return value;
            }

            public override void SetJ(IntPtr ptr, uint r, uint c, Direction direction, double value)
            {
                NativeMethods.graph_Square_double_set_J(ptr, r, c, direction, value);
            }

            public override double GetH(IntPtr ptr, uint r, uint c)
            {
                NativeMethods.graph_Square_double_get_h(ptr, r, c, out var value);
                return value;
            }

            public override void SetH(IntPtr ptr, uint r, uint c, double value)
            {
                NativeMethods.graph_Square_double_set_h(ptr, r, c, value);
            }
            
            public override uint GetNumRow(IntPtr ptr)
            {
                NativeMethods.graph_Square_double_get_num_row(ptr, out var value);
                return value;
            }
            
            public override uint GetNumColumn(IntPtr ptr)
            {
                NativeMethods.graph_Square_double_get_num_column(ptr, out var value);
                return value;
            }
            
            public override Spin GetSpin(IntPtr ptr, uint r, uint c)
            {
                NativeMethods.graph_Square_double_get_spin(ptr, r, c, out var spin);
                return new Spin(spin);
            }
            
            public override void SetSpin(IntPtr ptr, uint r, uint c, Spin spin)
            {
                NativeMethods.graph_Square_double_set_spin(ptr, r, c, spin.Value);
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

            public T this[uint row, uint column, Direction direction]
            {
                get
                {
                    return this._Implement.GetJ(this._Owner, row, column, direction);
                }
                set
                {
                    this._Implement.SetJ(this._Owner, row, column, direction, value);
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

            public T this[uint row, uint column]
            {
                get
                {
                    return this._Implement.GetH(this._Owner, row, column);
                }
                set
                {
                    this._Implement.SetH(this._Owner, row, column, value);
                }
            }

            #endregion

        }

    }

}
