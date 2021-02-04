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
        public static extern IntPtr utility_schedule_list_make_classical_schedule_list(double beta_min,
                                                                                       double beta_max,
                                                                                       uint one_mc_step,
                                                                                       uint num_call_updater);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void utility_schedule_list_ClassicalScheduleList_delete(IntPtr list);

    }

}