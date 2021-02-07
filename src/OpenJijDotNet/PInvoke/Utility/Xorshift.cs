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
        public static extern IntPtr utility_Xorshift_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr utility_Xorshift_new2(uint seed);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void utility_Xorshift_delete(IntPtr xorshift);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint utility_Xorshift_operator(IntPtr xorshift);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint utility_Xorshift_max();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern uint utility_Xorshift_min();

    }

}