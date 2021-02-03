using System;
using System.Collections.Generic;
using System.Linq;

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

        internal abstract NativeMethods.GraphTypes GraphType
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
        
        public Spins GenSpin(StdMt19937 randomNumderEngine)
        {
            if (randomNumderEngine == null)
                throw new ArgumentNullException(nameof(randomNumderEngine));
            
            randomNumderEngine.ThrowIfDisposed();
            this.ThrowIfDisposed();

            var spins = NativeMethods.graph_Graph_gen_spin_mt19937(this.NativePtr, randomNumderEngine.NativePtr);
            using(var vector = new StdVector<int>(spins))
                return new Spins(vector.ToArray().Select(v => new Spin(v)));
        }

        internal static bool TryParse(Type type, out FloatTypes result)
        {
            return SupportTypes.TryGetValue(type, out result);
        }

        #endregion

    }

}
