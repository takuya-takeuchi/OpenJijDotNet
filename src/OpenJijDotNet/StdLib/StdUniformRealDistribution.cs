using System;

using OpenJijDotNet.Utilities;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    public sealed class StdUniformRealDistribution<T> : OpenJijObject
    {

        #region Fields

        private readonly StdUniformRealDistributionImp<T> _Implement;

        #endregion

        #region Constructors

        public StdUniformRealDistribution(T a, T b)
        {
            this._Implement = CreateImp();
            this.NativePtr = this._Implement.Create(a, b);
        }

        #endregion

        #region Methods

        public T Operator(Xorshift xorshift)
        {
            if (xorshift == null)
                throw new ArgumentNullException(nameof(xorshift));
            
            xorshift.ThrowIfDisposed();
            this.ThrowIfDisposed();

            return this._Implement.Operator(this.NativePtr, xorshift.NativePtr);
        }

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            this._Implement?.Dispose(this.NativePtr);
        }

        #endregion

        #region Helpers

        private static StdUniformRealDistributionImp<T> CreateImp()
        {
            if (StdUniformRealDistributionElementTypesRepository.SupportTypes.TryGetValue(typeof(T), out var type))
            {
                switch (type)
                {
                    case StdUniformRealDistributionElementTypesRepository.ElementTypes.Double:
                        return new StdUniformRealDistributionDoubleImp() as StdUniformRealDistributionImp<T>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        #region StdUniformRealDistributionImp

        private abstract class StdUniformRealDistributionImp<T>
        {

            #region Methods

            public abstract IntPtr Create(T a, T b);

            public abstract void Dispose(IntPtr ptr);

            public abstract T Operator(IntPtr ptr, IntPtr rng);

            #endregion

        }

        private sealed class StdUniformRealDistributionDoubleImp : StdUniformRealDistributionImp<double>
        {

            #region Methods

            public override IntPtr Create(double a, double b)
            {
                return NativeMethods.std_uniform_real_distribution_double_new(a, b);
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_uniform_real_distribution_double_delete(ptr);
            }

            public override double Operator(IntPtr ptr, IntPtr rng)
            {
                return NativeMethods.std_uniform_real_distribution_double_xorshift_operator(ptr, rng);
            }

            #endregion

        }

        #endregion

    }

}
