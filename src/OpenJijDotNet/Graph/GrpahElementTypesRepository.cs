using System;
using System.Collections.Generic;

using OpenJijDotNet;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    internal static class GrpahElementTypesRepository
    {

        #region Fields

        public static readonly Dictionary<Type, NativeMethods.FloatTypes> SupportTypes = new Dictionary<Type, NativeMethods.FloatTypes>();

        #endregion

        #region Constructors
        
        static GrpahElementTypesRepository()
        {
            var types = new[]
            {
                new { Type = typeof(double),   ElementType = NativeMethods.FloatTypes.Double }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        #endregion

    }

}
