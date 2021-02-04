using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet
{

    public sealed class StdUniformRealDistribution<TItem> : OpenJijObject
    {

        #region Fields

        private readonly StdUniformRealDistributionImp<TItem> _Imp;

        #endregion

        #region Constructors

        public StdUniformRealDistribution(TItem a, TItem b)
        {
            this._Imp = CreateImp();
            this.NativePtr = this._Imp.Create(a, b);
        }

        #endregion

        #region Methods

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            this._Imp?.Dispose(this.NativePtr);
        }

        #endregion

        #region Helpers

        private static StdUniformRealDistributionImp<TItem> CreateImp()
        {
            if (StdUniformRealDistributionElementTypesRepository.SupportTypes.TryGetValue(typeof(TItem), out var type))
            {
                switch (type)
                {
                    case StdUniformRealDistributionElementTypesRepository.ElementTypes.Double:
                        return new StdUniformRealDistributionDoubleImp() as StdUniformRealDistributionImp<TItem>;
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

            #endregion

        }

        #endregion

    }

}
