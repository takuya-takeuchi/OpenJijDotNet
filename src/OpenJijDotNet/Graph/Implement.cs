using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{
    
    internal abstract class Implement<T>
    {

        #region Methods

        public abstract IntPtr Create(uint spins);

        public abstract void Dispose(IntPtr ptr);

        public abstract uint GetNumSpins(IntPtr ptr);

        public abstract T GetJ(IntPtr ptr, uint i, uint j);

        public abstract void SetJ(IntPtr ptr, uint i, uint j, T value);

        public abstract T GetH(IntPtr ptr, uint i);

        public abstract void SetH(IntPtr ptr, uint i, T value);

        #endregion

    }

}
