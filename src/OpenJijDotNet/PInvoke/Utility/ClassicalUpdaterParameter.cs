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

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr utility_ClassicalUpdaterParameter_new(double beta);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void utility_ClassicalUpdaterParameter_delete(IntPtr parameter);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern double utility_ClassicalUpdaterParameter_get_tuple(IntPtr parameter);

    }

}