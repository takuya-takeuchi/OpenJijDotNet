using System;
using System.Runtime.InteropServices;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using int64_t = System.Int64;
using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;

using OpenJijDotNet.Graphs;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    internal sealed partial class NativeMethods
    {

        #region double

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr graph_Square_double_new(uint num_row, uint num_column, double init_val);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void graph_Square_double_delete(IntPtr square);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_get_num_spins(IntPtr square, out uint spins);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_get_J(IntPtr square, uint r, uint c, Direction dir, out double value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_set_J(IntPtr square, uint r, uint c, Direction dir, double value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_get_h(IntPtr square, uint r, uint c, out double value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_set_h(IntPtr square, uint r, uint c, double value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_get_num_row(IntPtr square, out uint value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_get_num_column(IntPtr square, out uint value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_get_spin(IntPtr square, uint r, uint c, out int value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_set_spin(IntPtr square, uint r, uint c, int value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_to_ind(IntPtr square, uint r, uint c, out uint value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Square_double_to_rc(IntPtr square, uint value, out uint r, out uint c);

        #endregion

    }

}