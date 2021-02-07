using System;
using System.Collections.Generic;
using OpenJijDotNet.Graphs;
using Xunit;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Tests.Graphs
{

    public class RowColumnTest : TestBase
    {

        [Fact]
        public void Equal()
        {
            var rowColumn1 = new RowColumn(10, 20);
            var rowColumn2 = new RowColumn(10, 20);
            Assert.Equal(rowColumn1, rowColumn2);
            Assert.True(rowColumn1 == rowColumn2);
            Assert.True(rowColumn1.Equals(rowColumn2));
            Assert.False(rowColumn1 != rowColumn2);
        }

        [Fact]
        public void NotEqual()
        {
            var rowColumn1 = new RowColumn(10, 20);
            var rowColumn2 = new RowColumn(40, 10);
            Assert.NotEqual(rowColumn1, rowColumn2);
            Assert.True(rowColumn1 != rowColumn2);
            Assert.True(!rowColumn1.Equals(rowColumn2));
            Assert.False(rowColumn1 == rowColumn2);
        }

        [Fact]
        public void Hash()
        {
            var rowColumn1 = new RowColumn(10, 20);
            var rowColumn2 = new RowColumn(40, 10);

            var dictionary = new Dictionary<RowColumn, int>();
            dictionary.Add(rowColumn1, dictionary.Count);

            try
            {
                dictionary.Add(rowColumn2, dictionary.Count);
            }
            catch
            {
                Assert.True(false, $"{typeof(RowColumn)} must not throw exception.");
            }

            try
            {
                dictionary.Add(rowColumn2, dictionary.Count);
                Assert.True(false, $"{typeof(RowColumn)} must throw exception because key is duplicate.");
            }
            catch (ArgumentException)
            {
            }
        }

    }

}
