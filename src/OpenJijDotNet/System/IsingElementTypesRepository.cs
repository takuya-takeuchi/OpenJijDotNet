using System;
using System.Collections.Generic;

using OpenJijDotNet.Graphs;
using OpenJijDotNet.Systems;
using UpdaterAttribute = System.Tuple<OpenJijDotNet.NativeMethods.GraphTypes, OpenJijDotNet.NativeMethods.FloatTypes>;


// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    internal static class IsingElementTypesRepository
    {

        #region Fields

        public static readonly Dictionary<Type, UpdaterAttribute> SupportTypes = new Dictionary<Type, UpdaterAttribute>();

        #endregion

        #region Constructors
        
        static IsingElementTypesRepository()
        {
            var types = new[]
            {
                new { Type = typeof(ClassicalIsing<Dense<double>>),        GraphType = NativeMethods.GraphTypes.Dense, FloatType = NativeMethods.FloatTypes.Double },
                new { Type = typeof(ContinuousTimeIsing<Sparse<double>>),  GraphType = NativeMethods.GraphTypes.Dense, FloatType = NativeMethods.FloatTypes.Double },
                new { Type = typeof(TransverseIsing<Dense<double>>),       GraphType = NativeMethods.GraphTypes.Dense, FloatType = NativeMethods.FloatTypes.Double }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, new UpdaterAttribute(type.GraphType, type.FloatType));
        }

        #endregion

    }

}
