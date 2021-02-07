// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Updaters
{

    public sealed class ContinuousTimeSwendsenWang : Updater
    {

        #region Properties

        internal override NativeMethods.UpdaterTypes UpdaterType
        {
            get => NativeMethods.UpdaterTypes.ContinuousTimeSwendsenWang;
        }

        #endregion

    }

}