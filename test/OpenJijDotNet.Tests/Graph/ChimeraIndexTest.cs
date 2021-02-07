using System;
using System.Collections.Generic;
using OpenJijDotNet.Graphs;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Graphs
{

    public class ChimeraIndexTest : TestBase
    {

        [Fact]
        public void Equal()
        {
            var chimeraIndex1 = new ChimeraIndex(10, 20, 15);
            var chimeraIndex2 = new ChimeraIndex(10, 20, 15);
            Assert.Equal(chimeraIndex1, chimeraIndex2);
            Assert.True(chimeraIndex1 == chimeraIndex2);
            Assert.True(chimeraIndex1.Equals(chimeraIndex2));
            Assert.False(chimeraIndex1 != chimeraIndex2);
        }

        [Fact]
        public void NotEqual()
        {
            var chimeraIndex1 = new ChimeraIndex(10, 20, 30);
            var chimeraIndex2 = new ChimeraIndex(40, 10, 15);
            Assert.NotEqual(chimeraIndex1, chimeraIndex2);
            Assert.True(chimeraIndex1 != chimeraIndex2);
            Assert.True(!chimeraIndex1.Equals(chimeraIndex2));
            Assert.False(chimeraIndex1 == chimeraIndex2);
        }

        [Fact]
        public void Hash()
        {
            var chimeraIndex1 = new ChimeraIndex(10, 20, 30);
            var chimeraIndex2 = new ChimeraIndex(40, 10, 15);

            var dictionary = new Dictionary<ChimeraIndex, int>();
            dictionary.Add(chimeraIndex1, dictionary.Count);

            try
            {
                dictionary.Add(chimeraIndex2, dictionary.Count);
            }
            catch
            {
                Assert.True(false, $"{typeof(ChimeraIndex)} must not throw exception.");
            }

            try
            {
                dictionary.Add(chimeraIndex2, dictionary.Count);
                Assert.True(false, $"{typeof(ChimeraIndex)} must throw exception because key is duplicate.");
            }
            catch (ArgumentException)
            {
            }
        }

    }

}
