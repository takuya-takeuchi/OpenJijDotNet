using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Utilities
{
    
    public abstract class TransverseFieldUpdaterParameter : OpenJijObject
    {

        #region Constructors

        public TransverseFieldUpdaterParameter(double beta, double s)
        {
            this.NativePtr = NativeMethods.utility_TransverseFieldUpdaterParameter_new(beta, s);
        }

        protected TransverseFieldUpdaterParameter(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(ptr));

            this.NativePtr = ptr;
        }

        #endregion

        #region Methods

        public Tuple<double, double> GetTuple()
        {            
            this.ThrowIfDisposed();
            NativeMethods.utility_TransverseFieldUpdaterParameter_get_tuple(this.NativePtr, out var item1, out var item2);
            return new Tuple<double, double>(item1, item2);
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

            NativeMethods.utility_TransverseFieldUpdaterParameter_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
