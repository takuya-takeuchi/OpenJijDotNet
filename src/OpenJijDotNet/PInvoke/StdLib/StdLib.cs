﻿using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    internal sealed partial class NativeMethods
    {

        #region stdlib

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void stdlib_free(IntPtr ptr);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdlib_malloc(IntPtr size);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void stdlib_srand(uint seed);

        #endregion

        #region string

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr string_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr string_new2(StringBuilder c_str, int len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void string_append(IntPtr str, StringBuilder c_str, int len);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr string_c_str(IntPtr str);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void string_delete(IntPtr str);

        #endregion

        #region ostringstream

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr ostringstream_new();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr ostringstream_str(IntPtr str);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void ostringstream_delete(IntPtr str);

        #endregion

        #region vector

        #region int32

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_int32_new1();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_int32_new2(IntPtr size);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_int32_new3([In] int[] data, IntPtr dataLength);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_int32_getSize(IntPtr vector);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_int32_getPointer(IntPtr vector);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern int stdvector_int32_at(IntPtr vector, int index);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void stdvector_int32_delete(IntPtr vector);

        #endregion

        #region ulong

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_ulong_new1();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_ulong_new2(IntPtr size);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_ulong_new3([In] ulong[] data, IntPtr dataLength);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_ulong_getSize(IntPtr vector);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr stdvector_ulong_getPointer(IntPtr vector);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern ulong stdvector_ulong_at(IntPtr vector, int index);

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern void stdvector_ulong_delete(IntPtr vector);

        #endregion

        #endregion

    }

}