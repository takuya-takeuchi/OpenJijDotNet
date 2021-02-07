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

        internal enum FloatTypes
        {
            Float = 0,
            Double,
        };

        internal enum GraphTypes
        {
            Dense = 0,
            Sparse,
            Square,
            Chimera,
        };

        internal enum IsingTypes
        {
            Classical = 0,
            ContinuousTime,
            Transverse
        };

        internal enum ScheduleListTypes
        {
            Classical = 0,
            Transverse
        };

        internal enum UpdaterTypes
        {
            SingleSpinFlip = 0,
            SwendsenWang,
            ContinuousTimeSwendsenWang,
        };

        internal enum ErrorType
        {

            OK = 0x00000000,

            #region General

            GeneralError = 0x76000000,

            GeneralFileIOError      = -(GeneralError | 0x00000001),

            GeneralFileImageLoad    = -(GeneralError | 0x00000002),

            GeneralSerialization    = -(GeneralError | 0x00000003),

            GeneralInvalidParameter = -(GeneralError | 0x00000004),

            GeneralNotSupport       = -(GeneralError | 0x00000005),

            #endregion

            #region Array2D

            Array2DError = 0x7B000000,

            Array2DTypeTypeNotSupport = -(Array2DError | 0x00000001),

            #endregion

            #region Matrix

            MatrixError = 0x7C000000,

            MatrixElementTypeNotSupport         = -(MatrixError | 0x00000001),

            MatrixElementTemplateSizeNotSupport = -(MatrixError | 0x00000002),

            MatrixOpTypeNotSupport              = -(MatrixError | 0x00000003),

            #endregion

            //InputOutputArrayNotSameSize = -8,

            //InputOutputMatrixNotSameSize = -9

            #region Mlp

            MlpError = 0x7A000000,

            MlpKernelNotSupport = -(MlpError | 0x00000001),

            #endregion

            #region RunningStats

            RunningStatsError = 0x78000000,

            RunningStatsTypeNotSupport = -(RunningStatsError | 0x00000001),

            #endregion

            #region Vector

            VectorError = 0x79000000,

            VectorTypeNotSupport = -(VectorError | 0x00000001),

            #endregion

            #region FHog

            FHogError = 0x7D000000,

            FHogNotSupportExtractor = -(FHogError | 0x00000001),

            #endregion

            #region Pyramid

            PyramidError = 0x7E000000,

            PyramidNotSupportRate = -(PyramidError | 0x00000001),

            PyramidNotSupportType = -(PyramidError | 0x00000002),

            #endregion

            #region Dnn

            DnnError = 0x7F000000,

            DnnNotSupportNetworkType = -(DnnError | 0x00000001),

            DnnPropagateException    = -(DnnError | 0x00000002),

            #endregion

            #region Cuda

            CudaError = 0x77000000,

            // "C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v10.0\include\driver_types.h"
            // 
            // Any unhandled CUDA driver error is added to this value and returned via
            // the runtime. Production releases of CUDA should not return such errors.
            // \deprecated
            // This error return is deprecated as of CUDA 4.1.
            // cudaErrorApiFailureBase = 10000
            CudaErrorApiFailureBase = -(CudaError | 10000),

            #endregion

            #region Svm

            SvmError                  =              0x75000000,
                                      
            SvmKernelNotSupport       = -(SvmError | 0x00000001),
                                      
            SvmFunctionNotSupport     = -(SvmError | 0x00000002),
                                      
            SvmTrainerNotSupport      = -(SvmError | 0x00000003),

            SvmBatchTrainerNotSupport = -(SvmError | 0x00000004),

            #endregion

        }
        
        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        public static extern IntPtr get_version();

        [DllImport(NativeLibrary, CallingConvention = CallingConvention)]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool is_support_cuda();

    }

}