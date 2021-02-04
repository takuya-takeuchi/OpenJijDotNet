using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace OpenJijDotNet.Tests
{

    public abstract class TestBase
    {

        #region Fields

        private readonly Random _Random;

        #endregion

        #region Constructors

        protected TestBase()
        {
            this._Random = new Random();
        }

        #endregion

        #region Methods

        public void DisposeAndCheckDisposedState(OpenJijObject obj)
        {
            obj.Dispose();
            Assert.True(obj.IsDisposed);
            Assert.True(obj.NativePtr == IntPtr.Zero);
        }

        public void DisposeAndCheckDisposedStates(IEnumerable<OpenJijObject> objs)
        {
            foreach (var obj in objs)
                this.DisposeAndCheckDisposedState(obj);
        }

        #endregion

    }

}
