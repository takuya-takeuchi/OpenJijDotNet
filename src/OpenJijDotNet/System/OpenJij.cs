using System;
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

        public static ContinuousTimeIsing<T> MakeContinuousTimeIsing<T>(Spins initSpin, T initInteraction, double gamma)
            where T: Graph
        {
            if (initSpin == null)
                throw new ArgumentNullException(nameof(initSpin));
            if (initInteraction == null)
                throw new ArgumentNullException(nameof(initInteraction));
            
            initInteraction.ThrowIfDisposed();

            return ContinuousTimeIsing<T>.Create(initSpin, initInteraction, gamma);
        }

        public static TransverseIsing<T> MakeTransverseIsing<T>(Spins initSpin, T initInteraction, double gamma, ulong numTrotterSlices)
            where T: Graph
        {
            if (initSpin == null)
                throw new ArgumentNullException(nameof(initSpin));
            if (initInteraction == null)
                throw new ArgumentNullException(nameof(initInteraction));
            
            initInteraction.ThrowIfDisposed();

            return TransverseIsing<T>.Create(initSpin, initInteraction, gamma, numTrotterSlices);
        }

        #endregion

    }

}