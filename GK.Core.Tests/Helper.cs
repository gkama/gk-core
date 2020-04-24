using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GK.Core.Tests
{
    public class Helper
    {
        public static IContact GetTestContact() => GetTestContacts().First();
        public static IEnumerable<IContact> GetTestContacts()
        {
            return new List<TestContact>()
            {
                new TestContact
                {
                    Prefix = "Mr.",
                    FirstName = "First",
                    MiddleName = "M.",
                    LastName = "Last",
                    Suffix = "III",
                    DataName = "First Last - 1992",
                }
            };
        }

        public class TestContact : IContact
        {
            public string Email { get; set; }
            public string CellPhone { get; set; }

            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }

            public string Prefix { get; set; }
            public string Suffix { get; set; }

            public string FullName => this.GetFullName();
            public string DataName { get; set; }
        }
    }
}
