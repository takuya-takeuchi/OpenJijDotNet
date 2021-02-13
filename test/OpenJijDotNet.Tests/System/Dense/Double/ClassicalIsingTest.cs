using System.Linq;

using OpenJijDotNet.Graphs;
using OpenJijDotNet.Utilities;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Systems.Dense.Double
{

    public class ClassicalIsingTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var values = new int[] { 0, 1, 2 };
            var spins = new Spins(values.Select(v => new Spin(v)));
            var initInteraction = new Dense<double>(1);
            var ising = OpenJij.MakeClassicalIsing<Dense<double>>(spins, initInteraction);
            this.DisposeAndCheckDisposedState(initInteraction);
            this.DisposeAndCheckDisposedState(ising);
        }

    }

}
