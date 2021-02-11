using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Utilities
{
    
    public sealed class ClassicalConstraintUpdaterParameter : OpenJijObject
    {

        #region Constructors

        public ClassicalConstraintUpdaterParameter(double beta, double lambda)
        {
            this.NativePtr = NativeMethods.utility_ClassicalConstraintUpdaterParameter_new(beta, lambda);
        }

        internal ClassicalConstraintUpdaterParameter(IntPtr ptr, bool isEnabledDispose)
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
            NativeMethods.utility_ClassicalConstraintUpdaterParameter_get_tuple(this.NativePtr, out var item1, out var item2);
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

            NativeMethods.utility_ClassicalConstraintUpdaterParameter_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
