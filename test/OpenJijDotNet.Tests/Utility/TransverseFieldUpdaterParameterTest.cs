using OpenJijDotNet.Utilities;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Utilities
{

    public class TransverseFieldUpdaterParameterTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var parameter = new TransverseFieldUpdaterParameter(0.1, 2);
            this.DisposeAndCheckDisposedState(parameter);
        }

        [Fact]
        public void GetTuple()
        {
            var parameter = new TransverseFieldUpdaterParameter(0.1, 2);
            var tuple = parameter.GetTuple();
            Assert.Equal(0.1, tuple.Item1);
            Assert.Equal(2,   tuple.Item2);
            this.DisposeAndCheckDisposedState(parameter);
        }

    }

}
