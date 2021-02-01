using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    public sealed class StdRandomDevice : OpenJijObject
    {

        #region Constructors

        public StdRandomDevice()
        {
            this.NativePtr = NativeMethods.std_random_device_new();
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

            NativeMethods.std_random_device_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
