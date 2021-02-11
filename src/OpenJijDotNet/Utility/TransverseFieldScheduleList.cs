using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Utilities
{

    public sealed class TransverseFieldScheduleList : ScheduleList
    {

        #region Constructors

        internal TransverseFieldScheduleList(IntPtr ptr, bool isEnabledDispose)
            : base(ptr, isEnabledDispose)
        {
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

            NativeMethods.utility_schedule_list_TransverseFieldScheduleList_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
