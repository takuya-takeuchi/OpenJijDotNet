

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Updaters
{

    public sealed class SingleSpinFlip : Updater
    {

        internal override NativeMethods.UpdaterTypes UpdaterType
        {
            get => NativeMethods.UpdaterTypes.SingleSpinFlip;
        }

    }

}