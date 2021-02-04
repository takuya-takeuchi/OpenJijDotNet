using System;
using System.Collections.Generic;
using System.Linq;

using OpenJijDotNet;
using OpenJijDotNet.Graphs;
using OpenJijDotNet.Systems;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Results
{

    public sealed class Result
    {

        #region Methods

        public static Spins GetSolution(Ising system)
        {
            if (system == null)
                throw new ArgumentNullException(nameof(system));
            
            system.ThrowIfDisposed();

            var ret = NativeMethods.result_get_solution(system.NativePtr,
                                                        system.IsingType,
                                                        system.GraphType,
                                                        system.FloatType,
                                                        out var spins);

            using(var vector = new StdVector<int>(spins))
                return new Spins(vector.ToArray().Select(v => new Spin(v)));
        }

        #endregion

    }

}
