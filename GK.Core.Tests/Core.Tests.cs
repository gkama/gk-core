using System;

using Xunit;

using GK.Api.Core;

namespace GK.Core.Tests
{
    public class CoreTests
    {
        [Fact]
        public void ContactWithAllNamePartsHasExpectedFullName()
        {
            var contact = Helper.GetTestContact();

            Assert.Equal("Mr. First M. Last III", contact.FullName);
        }

        [Fact]
        public void NullContactHasEmptyFullName()
        {
            IContact contact = null;

            Assert.Equal(string.Empty, contact.GetFullName());
        }
    }
}
