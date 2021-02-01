using System;
using System.Runtime.InteropServices;

namespace OpenJijDotNet.Interop
{

    internal static class InteropHelper
    {

        public static void Copy(IntPtr ptrSource, ulong[] dest, uint elements)
        {
            Copy(ptrSource, dest, 0, elements);
        }

        public static unsafe void Copy(IntPtr ptrSource, ulong[] dest, int startIndex, uint elements)
        {
            fixed (ulong* ptrDest = &dest[startIndex])
                NativeMethods.cstd_memcpy((IntPtr)ptrDest, ptrSource, (int)(elements * sizeof(ulong)));
        }

        public static unsafe void Copy(ulong[] source, IntPtr ptrDest, uint elements)
        {
            fixed (ulong* ptrSource = &source[0])
                NativeMethods.cstd_memcpy(ptrDest, (IntPtr)ptrSource, (int)(elements * sizeof(ulong)));
        }

    }

}
