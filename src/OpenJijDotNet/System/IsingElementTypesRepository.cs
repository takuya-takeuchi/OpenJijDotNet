using System;
using System.Collections.Generic;

using OpenJijDotNet.Graphs;
using OpenJijDotNet.Systems;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    internal static class IsingElementTypesRepository
    {

        #region Fields

        public static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        #endregion

        #region Constructors
        
        static IsingElementTypesRepository()
        {
            var types = new[]
            {
                new { Type = typeof(ClassicalIsing<Dense<double>>),        ElementType = ElementTypes.DenseDouble },
                new { Type = typeof(ContinuousTimeIsing<Dense<double>>),   ElementType = ElementTypes.DenseDouble },
                new { Type = typeof(TransverseIsing<Dense<double>>),       ElementType = ElementTypes.DenseDouble }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        #endregion
        
        public enum ElementTypes
        {

            DenseDouble

        }

    }

}
