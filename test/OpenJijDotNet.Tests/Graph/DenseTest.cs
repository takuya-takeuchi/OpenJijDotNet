using OpenJijDotNet.Graphs;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Graphs
{

    public class DenseTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var dense = new Dense<double>(500);
            this.DisposeAndCheckDisposedState(dense);
        }

        [Fact]
        public void Spins()
        {
            const uint N = 124;
            var dense = new Dense<double>(124);
            Assert.Equal(dense.Spins, N);
            this.DisposeAndCheckDisposedState(dense);
        }

        [Fact]
        public void J()
        {
            const uint N = 10;
            var dense = new Dense<double>(124);

            for (uint i = 0; i < N; i++)
                for (uint j = 0; j < N; j++)
                    dense.J[i, j] = (i == j) ? 0 : -1;
            for (uint i = 0; i < N; i++)
                for (uint j = 0; j < N; j++)
                    Assert.Equal(dense.J[i, j], (i == j) ? 0 : -1);
            
            this.DisposeAndCheckDisposedState(dense);
        }

        [Fact]
        public void H()
        {
            const uint N = 10;
            var dense = new Dense<double>(124);

            for (uint i = 0; i < N; i++)
                dense.H[i] = -1;
            for (uint i = 0; i < N; i++)
                Assert.Equal(dense.H[i], -1);
            
            this.DisposeAndCheckDisposedState(dense);
        }

    }

}
