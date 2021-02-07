// ReSharper disable once CheckNamespace

using OpenJijDotNet.Systems;

namespace OpenJijDotNet.Updaters
{

    public sealed class SwendsenWang<T> : Updater
        where T : Ising
    {

        #region Properties

        internal override NativeMethods.UpdaterTypes UpdaterType
        {
            get => NativeMethods.UpdaterTypes.SwendsenWang;
        }

        #endregion

    }

}