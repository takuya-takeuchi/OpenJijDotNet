using System.Linq;
using Xunit;

using OpenJijDotNet.Graphs;

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

    }

}
