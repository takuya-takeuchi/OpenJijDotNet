using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.StdLib
{

    public class StdRandomDeviceTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var randomDevice = new StdRandomDevice();
            this.DisposeAndCheckDisposedState(randomDevice);
        }

    }

}
