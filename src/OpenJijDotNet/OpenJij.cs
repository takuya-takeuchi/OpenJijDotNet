using System.Text;

namespace OpenJijDotNet
{

    /// <summary>
    /// Provides the methods of OpenJij.
    /// </summary>
    public static partial class OpenJij
    {

        #region Methods

        public static string GetNativeVersion()
        {
            return StringHelper.FromStdString(NativeMethods.get_version(), true);
        }

        #endregion

        #region Properties

        private static Encoding _Encoding = Encoding.UTF8;

        public static Encoding Encoding
        {
            get => _Encoding;
            set => _Encoding = value ?? Encoding.UTF8;
        }

        public static bool IsSupportCuda => NativeMethods.is_support_cuda();

        #endregion

    }

}