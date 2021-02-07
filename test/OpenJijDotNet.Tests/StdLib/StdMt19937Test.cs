using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.StdLib
{

    public class StdMt19937Test : TestBase
    {

        [Fact]
        public void Create()
        {
            var mt = new StdMt19937(100);
            this.DisposeAndCheckDisposedState(mt);
        }

        [Fact]
        public void Create2()
        {
            var randomDevice = new StdRandomDevice();
            var mt = new StdMt19937(randomDevice);
            this.DisposeAndCheckDisposedState(randomDevice);
            this.DisposeAndCheckDisposedState(mt);
        }

    }

}
