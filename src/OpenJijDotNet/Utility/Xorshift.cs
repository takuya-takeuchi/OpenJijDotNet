using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Utilities
{

    public class Xorshift : OpenJijObject
    {

        #region Constructors

        public Xorshift()
        {
            this.NativePtr = NativeMethods.utility_Xorshift_new();
        }

        public Xorshift(uint seed)
        {
            this.NativePtr = NativeMethods.utility_Xorshift_new2(seed);
        }

        #endregion

        #region Methods

        public static uint Max()
        {
            return NativeMethods.utility_Xorshift_max();
        }

        public static uint Min()
        {
            return NativeMethods.utility_Xorshift_min();
        }

        public uint Operator()
        {
            this.ThrowIfDisposed();
            return NativeMethods.utility_Xorshift_operator(this.NativePtr);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.utility_Xorshift_delete(this.NativePtr);
        }

        #endregion

    }

}
