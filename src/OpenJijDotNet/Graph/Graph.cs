using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public abstract class Graph : OpenJijObject
    {

        #region Constructors

        protected Graph(uint spins)
        {
            this.NativePtr = this.Create(spins);
        }

        #endregion

        #region Properties

        public abstract uint Spins
        {
            get;
        }

        #endregion

        #region Methods

        protected abstract IntPtr Create(uint spins);

        #endregion


    }

}
