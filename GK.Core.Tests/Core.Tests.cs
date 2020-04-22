using System;

using Xunit;

using GK.Api.Core;

namespace GK.Core.Tests
{
    public class CoreTests
    {
        [Fact]
        public void Test1()
        {
            var str = "test";

            Assert.NotNull(str);
        }
    }
}
