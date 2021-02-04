﻿using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    internal static class StdVectorElementTypesRepository
    {

        #region Fields

        public static readonly Dictionary<Type, ElementTypes> SupportTypes = new Dictionary<Type, ElementTypes>();

        #endregion

        #region Constructors
        
        static StdVectorElementTypesRepository()
        {
            var types = new[]
            {
                new { Type = typeof(int),  ElementType = ElementTypes.Int32 },
                new { Type = typeof(uint), ElementType = ElementTypes.UInt32  }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        #endregion
        
        public enum ElementTypes
        {

            Int32,

            UInt32

        }

    }

}
