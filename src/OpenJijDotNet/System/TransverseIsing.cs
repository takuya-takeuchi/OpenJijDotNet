using System;
using System.Collections.Generic;
using System.Linq;
using OpenJijDotNet.Graphs;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Systems
{

    public sealed class TransverseIsing<T> : Ising
        where T: Graph
    {

        #region Fields

        private Implement<T> _Implement;

        private static readonly Dictionary<Type, Func<Spins, T, TransverseIsing<T>, double, ulong>> SupportTypes = new Dictionary<Type, Func<Spins, T, TransverseIsing<T>, double, ulong>>();

        #endregion

        #region Constructors

        static TransverseIsing()
        {
            var types = new[]
            {
                new { Type = typeof(Dense<float>),   Generator = new Func<Spins, T, TransverseIsing<T>, double, ulong>((s, i, g, t) => { return new TransverseIsing<Dense<float>>(s, i as Dense<float>, g, t) as TransverseIsing<T>;   } ) },
                new { Type = typeof(Dense<double>),  Generator = new Func<Spins, T, TransverseIsing<T>, double, ulong>((s, i, g, t) => { return new TransverseIsing<Dense<double>>(s, i as Dense<double>, g, t) as TransverseIsing<T>; } ) },
                // new { Type = typeof(Sparse<float>),  Generator = new Func<Spins, T, TransverseIsing<T>>((s, i) => { return new TransverseIsing<Sparse<float>>(s, i);  } ) },
                // new { Type = typeof(Sparse<double>), Generator = new Func<Spins, T, TransverseIsing<T>>((s, i) => { return new TransverseIsing<Sparse<double>>(s, i); } ) }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.Generator);
        }

        private TransverseIsing(Spins initSpins, T initInteraction, double gamma, ulong numTrotterSlices)
        {
            if (initSpins == null)
                throw new ArgumentNullException(nameof(initSpins));
            
            this.GraphType = initInteraction.GraphType;
            this.FloatType = initInteraction.FloatType;

            this._Implement = CreateImplement<T>(this.GetType());
            this.NativePtr = this._Implement.Create(initSpins, initInteraction, gamma, numTrotterSlices);
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

        internal static TransverseIsing<T> Create(Spins initSpins, T initInteraction, double gamma, ulong numTrotterSlices)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var generator))
                throw new NotSupportedException($"{typeof(T).Name} does not support");
            
            return generator(initSpins, initInteraction, gamma, numTrotterSlices);
        }

        public void ResetDE()
        {
            this.ThrowIfDisposed();

            NativeMethods.system_TransverseIsing_Dense_double_reset_dE(this.NativePtr);
        }

        public void ResetSpins(Spins spins)
        {
            if (spins == null)
                throw new ArgumentNullException(nameof(spins));

            this.ThrowIfDisposed();

            using (var vector = new StdVector<int>(spins.Select(s => s.Value)))
                NativeMethods.system_TransverseIsing_Dense_double_reset_spins(this.NativePtr, vector.NativePtr);
        }

        #region Helpers

        private static Implement<T> CreateImplement<T>(Type type)
            where T: Graph
        {
            if (IsingElementTypesRepository.SupportTypes.TryGetValue(type, out var ret))
            {
                switch (ret.Item1)
                {
                    case OpenJijDotNet.NativeMethods.GraphTypes.Dense:
                        switch (ret.Item2)
                        {
                            case OpenJijDotNet.NativeMethods.FloatTypes.Double:
                                return new DenseDoubleImplement() as Implement<T>;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(type), type, $"'{ret.Item2}' does not support for {ret.Item1}");
                        }
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        #region Implement

        internal abstract class Implement<T>
            where T: Graph
        {

            #region Methods

            public abstract IntPtr Create(Spins initSpins, T initInteraction, double gamma, ulong numTrotterSlices);

            public abstract void Dispose(IntPtr ptr);

            #endregion

        }

        private sealed class DenseDoubleImplement : Implement<Dense<double>>
        {

            #region Methods

            public override IntPtr Create(Spins initSpins, Dense<double> initInteraction, double gamma, ulong numTrotterSlices)
            {
                using (var vector = new StdVector<int>(initSpins.Select(s => s.Value)))
                    return NativeMethods.system_TransverseIsing_Dense_double_new(vector.NativePtr,
                                                                                 initInteraction.NativePtr,
                                                                                 gamma,
                                                                                 numTrotterSlices);
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.system_TransverseIsing_Dense_double_delete(ptr);
            }

            #endregion

        }

        #endregion

    }

}
