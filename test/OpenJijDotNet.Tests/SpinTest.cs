using System;
using System.Collections.Generic;
using Xunit;

namespace OpenJijDotNet.Tests
{

    public class SpinTest
    {

        [Fact]
        public void Equal()
        {
            var spin1 = new Spin(10);
            var spin2 = new Spin(10);
            Assert.Equal(spin1, spin2);
            Assert.True(spin1 == spin2);
            Assert.True(spin1.Equals(spin2));
            Assert.False(spin1 != spin2);
        }

        [Fact]
        public void NotEqual()
        {
            var spin1 = new Spin(10);
            var spin2 = new Spin(40);
            Assert.NotEqual(spin1, spin2);
            Assert.True(spin1 != spin2);
            Assert.True(!spin1.Equals(spin2));
            Assert.False(spin1 == spin2);
        }

        [Fact]
        public void Hash()
        {
            var spin1 = new Spin(10);
            var spin2 = new Spin(40);

            var dictionary = new Dictionary<Spin, int>();
            dictionary.Add(spin1, dictionary.Count);

            try
            {
                dictionary.Add(spin2, dictionary.Count);
            }
            catch
            {
                Assert.True(false, $"{typeof(Spin)} must not throw exception.");
            }

            try
            {
                dictionary.Add(spin2, dictionary.Count);
                Assert.True(false, $"{typeof(Spin)} must throw exception because key is duplicate.");
            }
            catch (ArgumentException)
            {
            }
        }

    }

}