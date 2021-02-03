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
        public static extern int algorithm_Algorithm_run(updater_types updater_type,
                                                         IntPtr ising,
                                                         IsingTypes ising_type,
                                                         GraphTypes graph_type,
                                                         FloatTypes float_type,
                                                         IntPtr random_number_engine,
                                                         IntPtr schedule_list)

    }

}