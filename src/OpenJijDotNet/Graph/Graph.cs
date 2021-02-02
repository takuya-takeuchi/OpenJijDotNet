using System;
using System.Collections.Generic;

using OpenJijDotNet;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public abstract class Graph : OpenJijObject
    {

        #region Fields

        private static readonly Dictionary<Type, FloatTypes> SupportTypes = new Dictionary<Type, FloatTypes>();

        #endregion

        #region Constructors

        static Graph()
        {
            var types = new[]
            {
                new { Type = typeof(float),   ElementType = FloatTypes.Float },
                new { Type = typeof(double),  ElementType = FloatTypes.Double }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.ElementType);
        }

        protected Graph(uint spins)
        {
            this.NativePtr = this.Create(spins);
        }

        #endregion

        #region Properties

        protected FloatTypes FloatType
        {
            get;
            set;
        }

        internal abstract GraphTypes GraphType
        {
            get;
        }

        public abstract uint Spins
        {
            get;
        }

        #endregion

        #region Methods

        protected abstract IntPtr Create(uint spins);

        internal static bool TryParse(Type type, out FloatTypes result)
        {
            return SupportTypes.TryGetValue(type, out result);
        }

        #endregion

    }

}
