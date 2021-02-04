using System;
using System.IO;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Utilities
{

    public class OpenJijTest : TestBase
    {

        [Fact]
        public void MakeClassicalScheduleList()
        {
            var scheduleList = OpenJij.MakeClassicalScheduleList(0.1, 100, 10, 200);
            this.DisposeAndCheckDisposedState(scheduleList);
        }

    }

}
