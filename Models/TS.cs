using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class TS
    {
        public TS()
        {
            DefaultUserTypes = new HashSet<DefaultUserType>();
            Items = new HashSet<Item>();
        }

        public string Klmid { get; set; }
        public string Name { get; set; }
        public string Initial { get; set; }
        public bool B1 { get; set; }
        public bool B2 { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsReadOnly { get; set; }

        public virtual ICollection<DefaultUserType> DefaultUserTypes { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
