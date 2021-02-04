using System;
using System.IO;
using System.Linq;
using System.Text;

using OpenJijDotNet.Graphs;
using OpenJijDotNet.Systems;

namespace OpenJijDotNet
{

    /// <summary>
    /// Provides the methods of OpenJij.
    /// </summary>
    public static partial class OpenJij
    {

        #region Methods

        public static ClassicalIsing<T> MakeClassicalIsing<T>(Spins initSpin, T initInteraction)
            where T: Graph
        {
            if (initSpin == null)
                throw new ArgumentNullException(nameof(initSpin));
            if (initInteraction == null)
                throw new ArgumentNullException(nameof(initInteraction));
            
            initInteraction.ThrowIfDisposed();

            return ClassicalIsing<T>.Create(initSpin, initInteraction);
        }

        #endregion

    }

}