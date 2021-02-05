

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Systems
{

    public abstract class Ising : OpenJijObject
    {

        internal abstract NativeMethods.IsingTypes IsingType
        {
            get;
        }

        internal abstract NativeMethods.FloatTypes FloatType
        {
            get;
        }

        internal abstract NativeMethods.GraphTypes GraphType
        {
            get;
        }

    }

}
