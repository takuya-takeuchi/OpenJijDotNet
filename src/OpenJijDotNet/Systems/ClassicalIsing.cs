﻿using System;
using System.Collections.Generic;

using OpenJijDotNet;
using OpenJijDotNet.Graphs;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Systems
{

    public sealed class ClassicalIsing<T> : OpenJijObject
        where T: Graph
    {

        #region Fields

        private static readonly Dictionary<Type, Func<Spins, T, ClassicalIsing<T>>> SupportTypes = new Dictionary<Type, Func<Spins, T, ClassicalIsing<T>>>();

        #endregion

        #region Constructors

        static ClassicalIsing()
        {
            var types = new[]
            {
                new { Type = typeof(Dense<float>),   Generator = new Func<Spins, T, ClassicalIsing<T>>((s, i) => { return new ClassicalIsing<Dense<float>>(s, i as Dense<float>) as ClassicalIsing<T>;   } ) },
                new { Type = typeof(Dense<double>),  Generator = new Func<Spins, T, ClassicalIsing<T>>((s, i) => { return new ClassicalIsing<Dense<double>>(s, i as Dense<double>) as ClassicalIsing<T>; } ) },
                // new { Type = typeof(Sparse<float>),  Generator = new Func<Spins, T, ClassicalIsing<T>>((s, i) => { return new ClassicalIsing<Sparse<float>>(s, i);  } ) },
                // new { Type = typeof(Sparse<double>), Generator = new Func<Spins, T, ClassicalIsing<T>>((s, i) => { return new ClassicalIsing<Sparse<double>>(s, i); } ) }
            };

            foreach (var type in types)
                SupportTypes.Add(type.Type, type.Generator);
        }

        public ClassicalIsing(Spins initSpins, T initInteraction)
        {
            if (initSpins == null)
                throw new ArgumentNullException(nameof(initSpins));
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        internal static ClassicalIsing<T> Create(Spins initSpins, T initInteraction)
        {
            if (!SupportTypes.TryGetValue(typeof(T), out var generator))
                throw new NotSupportedException($"{typeof(T).Name} does not support");
            
            return generator(initSpins, initInteraction);
        }

        #endregion


    }

}