﻿using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    internal sealed partial class NativeMethods
    {

        #region Fields

        /// <summary>
        /// Native library file name.
        /// If Linux, it will be converted to  libOpenJijDotNetNative.so
        /// If MacOSX, it will be converted to  libOpenJijDotNetNative.dylib
        /// If Windows, it will be available after call LoadLibrary.
        /// And this file name must not contain period. If it does,
        /// CLR does not add extension (.dll) and CLR fails to load library
        /// </summary>
        public const string NativeLibrary = "OpenJijDotNetNative";

        public const CallingConvention CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl;

        private static readonly WindowsLibraryLoader WindowsLibraryLoader = new WindowsLibraryLoader();

        #endregion

        #region Constructors

        static NativeMethods()
        {
            WindowsLibraryLoader.LoadLibraries(new[]
            {
                $"{NativeLibrary}"
            });
        }

        #endregion

    }

}