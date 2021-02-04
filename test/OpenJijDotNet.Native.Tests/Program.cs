using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenJijDotNet.Native.Tests
{

    [TestClass]
    public class OpenJijTest
    {

        private const string VersionKey = "OPENJIJDOTNET_VERSION";

        [TestMethod]
        public void CheckOpenJijDotNetNativeVersion()
        {
            var values = Environment.GetEnvironmentVariables();
            if (!values.Contains(VersionKey))
                Assert.Fail($"{VersionKey} is not found.");

            Console.WriteLine($"{VersionKey}: {values[VersionKey]}");
            Assert.AreEqual(values[VersionKey], OpenJijDotNet.OpenJij.GetNativeVersion());
        }

    }

}
