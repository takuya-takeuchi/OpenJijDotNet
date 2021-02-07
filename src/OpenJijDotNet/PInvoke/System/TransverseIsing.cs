using System;
using System.Runtime.InteropServices;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using int64_t = System.Int64;
using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    internal sealed partial class NativeMethods
    {

        #region Dense<double>

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr system_TransverseIsing_Dense_double_new(IntPtr spins, IntPtr graph);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void system_TransverseIsing_Dense_double_delete(IntPtr sparse);

        #endregion

    }

}