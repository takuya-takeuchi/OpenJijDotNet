using OpenJijDotNet.Systems;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Updaters
{

    public sealed class SingleSpinFlip<T> : Updater
        where T: Ising
    {

        #region Properties

        internal override NativeMethods.UpdaterTypes UpdaterType
        {
            get => NativeMethods.UpdaterTypes.SingleSpinFlip;
        }

        #endregion

    }

}