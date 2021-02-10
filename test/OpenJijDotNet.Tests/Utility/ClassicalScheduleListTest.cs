using OpenJijDotNet.Utilities;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Utilities
{

    public class ClassicalScheduleListTest : TestBase
    {

        [Fact]
        public void Create()
        {
            var parameter = new ClassicalScheduleList(11);
            this.DisposeAndCheckDisposedState(parameter);
        }

        [Fact]
        public void GetTuple()
        {
            var parameter = new ClassicalScheduleList(13);
            var tuple = parameter.GetTuple();
            Assert.Equal(13, tuple);
            this.DisposeAndCheckDisposedState(parameter);
        }

    }

}
