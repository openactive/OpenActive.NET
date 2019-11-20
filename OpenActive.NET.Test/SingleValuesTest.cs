using Newtonsoft.Json;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
namespace OpenActive.NET.Test
{
    public class SingleValuesTest
    {
        private readonly ITestOutputHelper output;

        public SingleValuesTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void SingleValues_Primative()
        {
            SingleValues<int, string> value = 1;
            Assert.Equal(1, value.GetPrimative<int>());
        }

        [Fact]
        public void SingleValues_Nullable_Primative()
        {
            SingleValues<int?, string> value = 1;
            Assert.Equal(1, value.GetPrimative<int>());
        }
    }
}
