using OpenJijDotNet.Utilities;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Utilities
{

    public class XorshiftTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var xorshiftTest = new Xorshift(100);
            this.DisposeAndCheckDisposedState(xorshiftTest);
        }

        [Fact]
        public void Max()
        {
            Assert.Equal(uint.MaxValue, Xorshift.Max());
        }

        [Fact]
        public void Min()
        {
            Assert.Equal(uint.MinValue, Xorshift.Min());
        }

    }

}
