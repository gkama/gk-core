using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using JetBrains.Annotations;

namespace GK.Core
{
    public static class BackendExtensions
    {
        /// <summary>
        /// Returns a full name composed of the contact's individual name components, suitable for display or correspondence.
        /// </summary>
        [NotNull]
        public static string GetFullName(this IContact contact)
        {
            if (contact == null)
                return string.Empty;

            IEnumerable<string> GetNonEmptyItems(params string[] items)
            {
                return items.Where(x => !string.IsNullOrWhiteSpace(x));
            }

            return string.Join(" ", GetNonEmptyItems(contact.Prefix, contact.FirstName, contact.MiddleName,
                contact.LastName, contact.Suffix));
        }
    }
}
