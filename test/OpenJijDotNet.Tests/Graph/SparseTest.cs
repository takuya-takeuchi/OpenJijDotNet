using System.Linq;
using Xunit;

using OpenJijDotNet.Graphs;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Graphs
{

    public class SparseTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var dense = new Sparse<double>(500);
            this.DisposeAndCheckDisposedState(dense);
        }

    }

}
