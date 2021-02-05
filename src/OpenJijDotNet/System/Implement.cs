using System;
using OpenJijDotNet.Graphs;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Systems
{
    
    internal abstract class Implement<T>
        where T: Graph
    {

        #region Methods

        public abstract IntPtr Create(Spins initSpins, T initInteraction);

        public abstract void Dispose(IntPtr ptr);

        #endregion

    }

}
