// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Updaters
{

    public abstract class Updater : OpenJijObject
    {

        #region Properties

        internal abstract NativeMethods.UpdaterTypes UpdaterType
        {
            get;
        }

        #endregion

    }

}
