﻿using System;

namespace OpenJijDotNet
{

    /// <summary>
    /// A class which has a pointer of native structure.
    /// </summary>
    public abstract class OpenJijObject : IDisposable
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenJijObject"/> class with the specified value indicating whether this instance is disposable.
        /// </summary>
        /// <param name="isEnabledDispose">true if this instance is disposable; otherwise, false.</param>
        protected OpenJijObject(bool isEnabledDispose = true)
        {
            this.IsEnableDispose = isEnabledDispose;
        }

        #endregion

        #region Finalizer

        // IMPORTANT
        //      OpenJijDotNet passes and get native pointer to unmanaged domain and from.
        //      Sometimes, OpenJijDotNet create OpenJijObject from native pointer.
        //      There may be some OpenJijObject has same native pointer .
        //      It means that developer may dispose objects has same one.
        //      To avoid this, OpenJijObject has IsEnableDispose property.
        //      OpenJijObject checks this property when Dispose method is called.
        //      However, if OpenJijObject implements finalizer and developer forgets to dispose, OpenJijObject may
        //      be disposed by GC and native pointer will be corrupted.
        //      
        //      If user add OpenJijObject to StdVector<T> and set null to passed OpenJijObject.
        //      Generally, OpenJijObject means pointer and it should not disposed automatically.
        //      If it's disposed automatically, element passed to StdVector<T> also be corrupt.
        //      This problem is only occured on C# rather than C++ because GC and finalizer.
        //
        //      In conclusion, OpenJijDotNet doesn't implement finalizer.
        //
        ///// <summary>
        ///// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        ///// </summary>
        //~OpenJijObject()
        //{
        //    this.Dispose(false);
        //}

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance has been disposed.
        /// </summary>
        /// <returns>true if this instance has been disposed; otherwise, false.</returns>
        public bool IsDisposed
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is disposable.
        /// </summary>
        /// <returns>true if this instance is disposable; otherwise, false.</returns>
        public bool IsEnableDispose
        {
            get;
        }

        /// <summary>
        /// Gets a pointer of native structure.
        /// </summary>>
        public IntPtr NativePtr
        {
            get;
            internal set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// If this object is disposed, then <see cref="System.ObjectDisposedException"/> is thrown.
        /// </summary>
        public void ThrowIfDisposed()
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);
        }

        internal void ThrowIfDisposed(string objectName)
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(objectName);
        }

        #region Overrides

        protected bool Equals(OpenJijObject other)
        {
            return this.NativePtr.Equals(other.NativePtr);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OpenJijObject) obj);
        }

        public override int GetHashCode()
        {
            return this.NativePtr.GetHashCode();
        }

        /// <summary>
        /// Releases all managed resources.
        /// </summary>
        protected virtual void DisposeManaged()
        {

        }

        protected virtual void DisposingManaged()
        {

        }

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected virtual void DisposeUnmanaged()
        {

        }

        protected virtual void DisposingUnmanaged()
        {

        }

        #endregion

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Releases all resources used by this <see cref="OpenJijObject"/>.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            //GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by this <see cref="OpenJijObject"/>.
        /// </summary>
        /// <param name="disposing">Indicate value whether <see cref="IDisposable.Dispose"/> method was called.</param>
        private void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            // pre-disposing
            {
                if (disposing)
                {
                    if (this.IsEnableDispose)
                        this.DisposingManaged();
                }

                if (this.IsEnableDispose)
                    this.DisposingUnmanaged();
            }

            this.IsDisposed = true;

            if (disposing)
            {
                if (this.IsEnableDispose)
                    this.DisposeManaged();
            }

            if (this.IsEnableDispose)
                this.DisposeUnmanaged();

            this.NativePtr = IntPtr.Zero;
        }

        #endregion

    }

}
