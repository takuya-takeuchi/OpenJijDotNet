using OpenJijDotNet.Graphs;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Graphs
{

    public class SparseTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var sparse = new Sparse<double>(500);
            this.DisposeAndCheckDisposedState(sparse);
        }

        [Fact]
        public void Spins()
        {
            const uint N = 124;
            var sparse = new Sparse<double>(124);
            Assert.Equal(sparse.Spins, N);
            this.DisposeAndCheckDisposedState(sparse);
        }

        [Fact]
        public void J()
        {
            const uint N = 10;
            var sparse = new Sparse<double>(124);

            for (uint i = 0; i < N; i++)
                for (uint j = 0; j < N; j++)
                    sparse.J[i, j] = (i == j) ? 0 : -1;
            for (uint i = 0; i < N; i++)
                for (uint j = 0; j < N; j++)
                    Assert.Equal(sparse.J[i, j], (i == j) ? 0 : -1);
            
            this.DisposeAndCheckDisposedState(sparse);
        }

        [Fact]
        public void H()
        {
            const uint N = 10;
            var sparse = new Sparse<double>(124);

            for (uint i = 0; i < N; i++)
                sparse.H[i] = -1;
            for (uint i = 0; i < N; i++)
                Assert.Equal(sparse.H[i], -1);
            
            this.DisposeAndCheckDisposedState(sparse);
        }

    }

}
