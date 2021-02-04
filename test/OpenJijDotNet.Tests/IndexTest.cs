using System;
using System.Collections.Generic;
using Xunit;

namespace OpenJijDotNet.Tests
{

    public class IndexTest
    {

        [Fact]
        public void Equal()
        {
            var index1 = new Index(10);
            var index2 = new Index(10);
            Assert.Equal(index1, index2);
            Assert.True(index1 == index2);
            Assert.True(index1.Equals(index2));
            Assert.False(index1 != index2);
        }

        [Fact]
        public void NotEqual()
        {
            var index1 = new Index(10);
            var index2 = new Index(40);
            Assert.NotEqual(index1, index2);
            Assert.True(index1 != index2);
            Assert.True(!index1.Equals(index2));
            Assert.False(index1 == index2);
        }

        [Fact]
        public void Hash()
        {
            var index1 = new Index(10);
            var index2 = new Index(40);

            var dictionary = new Dictionary<Index, int>();
            dictionary.Add(index1, dictionary.Count);

            try
            {
                dictionary.Add(index2, dictionary.Count);
            }
            catch
            {
                Assert.True(false, $"{typeof(Index)} must not throw exception.");
            }

            try
            {
                dictionary.Add(index2, dictionary.Count);
                Assert.True(false, $"{typeof(Index)} must throw exception because key is duplicate.");
            }
            catch (ArgumentException)
            {
            }
        }

    }

}