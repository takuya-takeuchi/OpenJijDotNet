using System;
using System.Collections.Generic;

using OpenJijDotNet;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Utilities
{

    public sealed class ClassicalScheduleList : ScheduleList
    {

        #region Constructors

        internal ClassicalScheduleList(IntPtr ptr, bool isEnabledDispose)
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

            NativeMethods.utility_schedule_list_ClassicalScheduleList_delete(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
