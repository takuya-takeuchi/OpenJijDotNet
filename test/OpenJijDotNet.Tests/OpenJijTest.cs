using OpenJijDotNet.Graphs;
using OpenJijDotNet.Systems;
using OpenJijDotNet.Utilities;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests
{

    public class OpenJijTest : TestBase
    {

        #region Graph

        [Fact]
        public void DenseGraphCheck()
        {
            const uint N = 500;
            using var a = new Dense<double>(N);
            using var r = new Xorshift(1234);
            using var urd = new StdUniformRealDistribution<double>(-10, 10);
            for (uint i = 0; i < N; i++)
                for (uint j = i; j < N; j++)
                    a.J[i, j] = urd.Operator(r);

            using var r2 = new Xorshift(1234);

            // check if graph holds correct variables
            for (uint i = 0; i < N; i++)
                for (uint j = i; j < N; j++)
                    Assert.Equal(a.J[i, j] , urd.Operator(r2));

            using var r3 = new Xorshift(1234);

            // check if graph index is reversible (Jij = Jji)
            for (uint i = 0; i < N; i++)
                for (uint j = i; j < N; j++)
                    Assert.Equal(a.J[j, i] , urd.Operator(r3));
        }

        #endregion

    }

}
