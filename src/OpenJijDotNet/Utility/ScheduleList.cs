using System;
using System.Collections.Generic;

using OpenJijDotNet;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Utilities
{

    public abstract class ScheduleList : OpenJijObject
    {

        #region Constructors

        protected ScheduleList(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(ptr));

            this.NativePtr = ptr;
        }

        #endregion

    }

}
