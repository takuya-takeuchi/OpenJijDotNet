using OpenJijDotNet.Graphs;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Graphs
{

    public class ChimeraTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var chimera = new Chimera<double>(10, 10);
            this.DisposeAndCheckDisposedState(chimera);
        }

        [Fact]
        public void Create2()
        {
            var chimera = new Chimera<double>(10, 10, 1.0);
            this.DisposeAndCheckDisposedState(chimera);
        }

        [Fact]
        public void Column()
        {
            const uint N = 11;
            var chimera = new Chimera<double>(10, 11, 0);
            Assert.Equal(chimera.Column, N);
            this.DisposeAndCheckDisposedState(chimera);
        }

        [Fact]
        public void Row()
        {
            const uint N = 10;
            var chimera = new Chimera<double>(10, 11, 0);
            Assert.Equal(chimera.Row, N);
            this.DisposeAndCheckDisposedState(chimera);
        }

        [Fact]
        public void InChimera()
        {
            const uint N = 8;
            var chimera = new Chimera<double>(10, 11, 0);
            Assert.Equal(chimera.InChimera, N);
            this.DisposeAndCheckDisposedState(chimera);
        }

        [Fact]
        public void Spins()
        {
            const uint N = 880;
            var chimera = new Chimera<double>(10, 11, 0);
            Assert.Equal(chimera.Spins, N);
            this.DisposeAndCheckDisposedState(chimera);
        }

    }

}
