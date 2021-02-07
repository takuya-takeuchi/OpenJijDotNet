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
        public static extern IntPtr graph_Chimera_double_new(uint num_row, uint num_column, double init_val);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void graph_Chimera_double_delete(IntPtr chimera);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_get_num_spins(IntPtr chimera, out uint spins);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_get_J(IntPtr chimera, uint r, uint c, uint i, ChimeraDirection dir, out double value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_set_J(IntPtr chimera, uint r, uint c, uint i, ChimeraDirection dir, double value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_get_h(IntPtr chimera, uint r, uint c, uint i, out double value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_set_h(IntPtr chimera, uint r, uint c, uint i, double value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_get_num_row(IntPtr chimera, out uint value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_get_num_column(IntPtr chimera, out uint value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_get_num_in_chimera(IntPtr chimera, out uint value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_get_spin(IntPtr chimera, uint r, uint c, uint i, out int value);
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int graph_Chimera_double_set_spin(IntPtr chimera, uint r, uint c, uint i, int value);

        #endregion

    }

}