using System;
using System.Collections.Generic;
using System.Linq;
using OpenJijDotNet.Graphs;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Systems
{

    public sealed class ContinuousTimeIsing<T> : Ising
        where T: Graph
    {

        #region Fields

        private Implement<T> _Implement;

        private static readonly Dictionary<Type, Func<Spins, T, ContinuousTimeIsing<T>>> SupportTypes = new Dictionary<Type, Func<Spins, T, ContinuousTimeIsing<T>>>();

        #endregion

        #region Constructors

        static ContinuousTimeIsing()
        {
            var types = new[]
            {
                new { Type = typeof(Dense<float>),   Generator = new Func<Spins, T, ContinuousTimeIsing<T>>((s, i) => { return new ContinuousTimeIsing<Dense<float>>(s, i as Dense<float>) as ContinuousTimeIsing<T>;   } ) },
                new { Type = typeof(Dense<double>),  Generator = new Func<Spins, T, ContinuousTimeIsing<T>>((s, i) => { return new ContinuousTimeIsing<Dense<double>>(s, i as Dense<double>) as ContinuousTimeIsing<T>; } ) },
                // new { Type = typeof(Sparse<float>),  Generator = new Func<Spins, T, ContinuousTimeIsing<T>>((s, i) => { return new ContinuousTimeIsing<Sparse<float>>(s, i);  } ) },
                // new { Type = typeof(Sparse<double>), Generator = new Func<Spins, T, ContinuousTimeIsing<T>>((s, i) => { return new ContinuousTimeIsing<Sparse<double>>(s, i); } ) }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.Generator);
        }

        private ContinuousTimeIsing(Spins initSpins, T initInteraction)
        {
            if (initSpins == null)
                throw new ArgumentNullException(nameof(initSpins));
            
            this.GraphType = initInteraction.GraphType;
            this.FloatType = initInteraction.FloatType;

            this._Implement = CreateImplement<T>();
            this.NativePtr = this._Implement.Create(initSpins, initInteraction);
        }

        #endregion

        #region Properties

        internal override NativeMethods.GraphTypes GraphType
        {
            get;
        }

        internal override NativeMethods.FloatTypes FloatType
        {
            get;
        }

        internal override NativeMethods.IsingTypes IsingType
        {
            get => NativeMethods.IsingTypes.Classical;
        }

        #endregion

        #region Methods

        internal static ContinuousTimeIsing<T> Create(Spins initSpins, T initInteraction)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var generator))
                throw new NotSupportedException($"{typeof(T).Name} does not support");
            
            return generator(initSpins, initInteraction);
        }

        #region Helpers

        private static Implement<T> CreateImplement<T>()
            where T: Graph
        {
            if (IsingElementTypesRepository.SupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case IsingElementTypesRepository.ElementTypes.DenseDouble:
                        return new DenseDoubleImplement() as Implement<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        #region Implement

        private sealed class DenseDoubleImplement : Implement<Dense<double>>
        {

            #region Methods

            public override IntPtr Create(Spins initSpins, Dense<double> initInteraction)
            {
                using (var vector = new StdVector<int>(initSpins.Select(s => s.Value)))
                    return NativeMethods.system_ContinuousTimeIsing_Dense_double_new(vector.NativePtr, initInteraction.NativePtr);
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.system_ContinuousTimeIsing_Dense_double_delete(ptr);
            }

            #endregion

        }

        #endregion

    }

}
