using System.Linq;

using OpenJijDotNet.Graphs;
using OpenJijDotNet.Utilities;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Systems.Sparse.Double
{

    public class ContinuousTimeIsingTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var values = new int[] { 0, 1, 2 };
            var spins = new Spins(values.Select(v => new Spin(v)));
            var initInteraction = new Sparse<double>(1);
            var ising = OpenJij.MakeContinuousTimeIsing<Sparse<double>>(spins, initInteraction);
            this.DisposeAndCheckDisposedState(initInteraction);
            this.DisposeAndCheckDisposedState(ising);
        }

    }

}
