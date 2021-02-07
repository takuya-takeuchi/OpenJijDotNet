using System;
using System.Collections.Generic;

using OpenJijDotNet;
using OpenJijDotNet.Graphs;
using OpenJijDotNet.Systems;

using UpdaterAttribute = System.Tuple<OpenJijDotNet.NativeMethods.IsingTypes, OpenJijDotNet.NativeMethods.GraphTypes, OpenJijDotNet.NativeMethods.FloatTypes>;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    internal static class UpdaterElementTypesRepository
    {

        #region Fields

        public static readonly Dictionary<Type, UpdaterAttribute> SupportTypes = new Dictionary<Type, UpdaterAttribute>();

        #endregion

        #region Constructors
        
        static UpdaterElementTypesRepository()
        {
            // var types = new[]
            // {
            //     new { Type = typeof(SingleSpinFlip<ClassicalIsing<Dense<double>>>),                   IsingType = NativeMethods.IsingTypes.Classical,      GraphType = NativeMethods.GraphTypes.Dense,  FloatType = NativeMethods.FloatTypes.Double },
            //     new { Type = typeof(SingleSpinFlip<TransverseIsing<Dense<double>>>),                  IsingType = NativeMethods.IsingTypes.Transverse,     GraphType = NativeMethods.GraphTypes.Dense,  FloatType = NativeMethods.FloatTypes.Double },
            //     new { Type = typeof(SingleSpinFlip<ClassicalIsing<Sparse<double>>>),                  IsingType = NativeMethods.IsingTypes.Classical,      GraphType = NativeMethods.GraphTypes.Sparse, FloatType = NativeMethods.FloatTypes.Double },
            //     new { Type = typeof(SingleSpinFlip<TransverseIsing<Sparse<double>>>),                 IsingType = NativeMethods.IsingTypes.Transverse,     GraphType = NativeMethods.GraphTypes.Sparse, FloatType = NativeMethods.FloatTypes.Double },
            //     new { Type = typeof(SwendsenWang<ClassicalIsing<Sparse<double>>>),                    IsingType = NativeMethods.IsingTypes.Classical,      GraphType = NativeMethods.GraphTypes.Sparse, FloatType = NativeMethods.FloatTypes.Double },
            //     new { Type = typeof(ContinuousTimeSwendsenWang<ContinuousTimeIsing<Sparse<double>>>), IsingType = NativeMethods.IsingTypes.ContinuousTime, GraphType = NativeMethods.GraphTypes.Sparse, FloatType = NativeMethods.FloatTypes.Double }
            // };

            // foreach (var type in types)
            //     SupportTypes.Add(type.Type, new UpdaterAttribute(type.IsingType, type.GraphType, type.FloatType));
        }

        #endregion

    }

}
