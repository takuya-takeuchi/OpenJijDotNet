using System;
using System.Collections.Generic;
using System.Linq;

using OpenJijDotNet;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Updaters
{

    public abstract class Updater : OpenJijObject
    {

        internal abstract NativeMethods.UpdaterTypes UpdaterType
        {
            get;
        }

    }

}
