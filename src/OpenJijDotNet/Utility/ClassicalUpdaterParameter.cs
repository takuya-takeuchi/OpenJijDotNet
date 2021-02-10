using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Utilities
{
    
    public abstract class ClassicalUpdaterParameter : OpenJijObject
    {

        #region Constructors

        public ClassicalUpdaterParameter(double beta)
        {
            this.NativePtr = NativeMethods.utility_ClassicalUpdaterParameter_new(beta);
        }

        protected ClassicalUpdaterParameter(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(ptr));

            this.NativePtr = ptr;
        }

        #endregion

        #region Methods

        public double GetTuple()
        {            
            this.ThrowIfDisposed();
            return NativeMethods.utility_ClassicalUpdaterParameter_get_tuple(this.NativePtr);
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

            NativeMethods.utility_ClassicalUpdaterParameter_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
