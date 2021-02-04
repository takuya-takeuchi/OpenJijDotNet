using System;
using System.Collections.Generic;

using OpenJijDotNet;
using OpenJijDotNet.Updaters;
using OpenJijDotNet.Systems;
using OpenJijDotNet.Utilities;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Algorithms
{

    public sealed class Algorithm<T>
            where T: Updater
    {

        #region Methods

        public static void Run(Ising system, StdMt19937 randomNumberEngine, ScheduleList scheduleList)
        {
            if (system == null)
                throw new ArgumentNullException(nameof(system));
            if (randomNumberEngine == null)
                throw new ArgumentNullException(nameof(randomNumberEngine));
            if (scheduleList == null)
                throw new ArgumentNullException(nameof(scheduleList));
            
            system.ThrowIfDisposed();
            randomNumberEngine.ThrowIfDisposed();
            scheduleList.ThrowIfDisposed();

            var updaterType = NativeMethods.UpdaterTypes.SingleSpinFlip;
            var ret = NativeMethods.algorithm_Algorithm_run(updaterType,
                                                            system.NativePtr,
                                                            system.IsingType,
                                                            system.GraphType,
                                                            system.FloatType,
                                                            randomNumberEngine.NativePtr,
                                                            scheduleList.NativePtr);
        }

        #endregion

    }

}
