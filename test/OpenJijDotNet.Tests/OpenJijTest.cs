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

        [Fact]
        public void SparseGraphCheck()
        {
            const uint N = 500;
            using var b = new Sparse<double>(N, N - 1);
            using var r = new Xorshift(1234);
            using var urd = new StdUniformRealDistribution<double>(-10, 10);
            for (uint i = 0; i < N; i++)
                for (uint j = i + 1; j < N; j++)
                    b.J[i, j] = urd.Operator(r);

            using var r2 = new Xorshift(1234);

            // check if graph holds correct variables
            for (uint i = 0; i < N; i++)
                for (uint j = i + 1; j < N; j++)
                    Assert.Equal(b.J[i, j] , urd.Operator(r2));

            using var r3 = new Xorshift(1234);

            // check if graph index is reversible (Jij = Jji)
            for (uint i = 0; i < N; i++)
                for (uint j = i + 1; j < N; j++)
                    Assert.Equal(b.J[j, i] , urd.Operator(r3));

            //check adj_nodes
            for (uint i = 0; i < N; i++)
            {
                ulong tot = 0;
                foreach (var elem in b.GetAdjacentNodes(i))
                    tot += elem.Value;
                Assert.Equal(tot, N * (N - 1) / 2 - i);
            }
            Assert.Equal(b.Edges , N - 1);

            using var c = new Sparse<double>(N, N);
            using var r4 = new Xorshift(1234);
            for (uint i = 0; i < N; i++)
                for (uint j = i; j < N; j++)
                    c.J[j, i] = urd.Operator(r4);

            using var r5 = new Xorshift(1234);

            for (uint i = 0; i < N; i++)
                for (uint j = i; j < N; j++)
                    Assert.Equal(c.J[i, j] , urd.Operator(r5));

            using var r6 = new Xorshift(1234);

            for (uint i = 0; i < N; i++)
                for (uint j = i; j < N; j++)
                    Assert.Equal(c.J[j, i] , urd.Operator(r6));
            
            for (uint i = 0; i < N; i++)
            {
                ulong tot = 0;
                foreach (var elem in c.GetAdjacentNodes(i))
                    tot += elem.Value;
                Assert.Equal(tot, N * (N - 1) / 2);
            }
            Assert.Equal(c.Edges , N);
        }

        #endregion

    }

}
