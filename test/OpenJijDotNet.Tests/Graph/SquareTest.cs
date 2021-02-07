using OpenJijDotNet.Graphs;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Graphs
{

    public class SquareTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var square = new Square<double>(10, 10);
            this.DisposeAndCheckDisposedState(square);
        }

        [Fact]
        public void Create2()
        {
            var square = new Square<double>(10, 10, 1.0);
            this.DisposeAndCheckDisposedState(square);
        }

        [Fact]
        public void Column()
        {
            const uint N = 11;
            var square = new Square<double>(10, 11, 0);
            Assert.Equal(square.Column, N);
            this.DisposeAndCheckDisposedState(square);
        }

        [Fact]
        public void Row()
        {
            const uint N = 10;
            var square = new Square<double>(10, 11, 0);
            Assert.Equal(square.Row, N);
            this.DisposeAndCheckDisposedState(square);
        }

        [Fact]
        public void Spins()
        {
            const uint N = 110;
            var square = new Square<double>(10, 11, 0);
            Assert.Equal(square.Spins, N);
            this.DisposeAndCheckDisposedState(square);
        }

    }

}
