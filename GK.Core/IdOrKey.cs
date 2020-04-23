using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Core
{
    /// <summary>
    /// Used to look up an entry by either its ID or Public Key.
    /// </summary>
    public struct IdOrKey
    {
        public int Id { get; set; }
        public Guid Key { get; set; }

        public bool HasId => Key == Guid.Empty;
        public bool HasKey => Key != Guid.Empty;

        public static implicit operator IdOrKey(int id) => new IdOrKey { Id = id, };
        public static implicit operator IdOrKey(Guid key) => new IdOrKey { Key = key, };
        public static implicit operator int(IdOrKey idOrKey) => idOrKey.Id;
        public static implicit operator Guid(IdOrKey idOrKey) => idOrKey.Key;

        public override string ToString()
        {
            return HasKey ? Key.ToString() : Id.ToString();
        }
    }
}
