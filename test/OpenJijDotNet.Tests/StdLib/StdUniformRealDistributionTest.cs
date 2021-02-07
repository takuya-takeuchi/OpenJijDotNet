using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.StdLib
{

    public class StdUniformRealDistributionTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var urd = new StdUniformRealDistribution<double>(0.0, 1.0);
            this.DisposeAndCheckDisposedState(urd);
        }

    }

}
