using System;
using System.Collections.Generic;

using OpenJijDotNet.Graphs;
using OpenJijDotNet.Systems;
using Attribute = System.Tuple<OpenJijDotNet.NativeMethods.GraphTypes, OpenJijDotNet.NativeMethods.FloatTypes>;


// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    internal static class IsingElementTypesRepository
    {

        #region Fields

        public static readonly Dictionary<Type, Attribute> SupportTypes = new Dictionary<Type, Attribute>();

        #endregion

        #region Constructors
        
        static IsingElementTypesRepository()
        {
            var types = new[]
            {
                new { Type = typeof(ClassicalIsing<Dense<double>>),        GraphType = NativeMethods.GraphTypes.Dense,  FloatType = NativeMethods.FloatTypes.Double },
                new { Type = typeof(ContinuousTimeIsing<Sparse<double>>),  GraphType = NativeMethods.GraphTypes.Sparse, FloatType = NativeMethods.FloatTypes.Double },
                new { Type = typeof(TransverseIsing<Dense<double>>),       GraphType = NativeMethods.GraphTypes.Dense,  FloatType = NativeMethods.FloatTypes.Double }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, new Attribute(type.GraphType, type.FloatType));
        }

        #endregion

    }

}
