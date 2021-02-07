using System;
using OpenJijDotNet.Graphs;
using OpenJijDotNet.Systems;
using OpenJijDotNet.Updaters;
using OpenJijDotNet.Utilities;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Algorithms
{

    public sealed class Algorithm<T>
            where T : Updater
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

            if (!UpdaterElementTypesRepository.SupportTypes.TryGetValue(typeof(T), out var types))
                throw new NotSupportedException($"{typeof(T).Name} does not support");
            if (types.Item2 != system.IsingType)
                throw new NotSupportedException($"{typeof(T).Name} supports only {system.IsingType}");
            if (types.Item3 != system.GraphType)
                throw new NotSupportedException($"{typeof(T).Name} supports only {system.GraphType}");
            if (types.Item4 != system.FloatType)
                throw new NotSupportedException($"{typeof(T).Name} supports only {system.FloatType}");

            var updaterType = types.Item1;
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
