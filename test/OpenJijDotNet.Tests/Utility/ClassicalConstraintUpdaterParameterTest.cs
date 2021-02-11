using OpenJijDotNet.Utilities;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Utilities
{

    public class ClassicalConstraintUpdaterParameterTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var parameter = new ClassicalConstraintUpdaterParameter(10, 20);
            this.DisposeAndCheckDisposedState(parameter);
        }

        [Fact]
        public void GetTuple()
        {
            var parameter = new ClassicalConstraintUpdaterParameter(10, 20);
            var tuple = parameter.GetTuple();
            Assert.Equal(10, tuple.Item1);
            Assert.Equal(20,   tuple.Item2);
            this.DisposeAndCheckDisposedState(parameter);
        }

    }

}
