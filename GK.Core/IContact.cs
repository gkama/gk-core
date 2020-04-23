using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Core
{
    /// <summary>
    /// Describes a type which has name and contact information.
    /// </summary>
    public interface IContact
    {
        /// <summary>
        /// The email address of this contact.
        /// </summary>
        string Email { get; set; }

        string CellPhone { get; set; }

        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }

        string Prefix { get; set; }
        string Suffix { get; set; }

        string FullName { get; }
        string DataName { get; set; }
    }
}
