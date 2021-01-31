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

        #endregion

    }

}
