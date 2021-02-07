// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Updaters
{

    public sealed class SwendsenWang : Updater
    {

        #region Properties

        internal override NativeMethods.UpdaterTypes UpdaterType
        {
            get => NativeMethods.UpdaterTypes.SwendsenWang;
        }

        #endregion

    }

}