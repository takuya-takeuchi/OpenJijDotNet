using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    public sealed class StdMt19937 : OpenJijObject
    {

        #region Constructors

        public StdMt19937(StdRandomDevice device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            this.NativePtr = NativeMethods.std_mt19937_new(device.NativePtr);
        }

        #endregion

        #region Methods

        #region Overrides 

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            NativeMethods.std_mt19937_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
