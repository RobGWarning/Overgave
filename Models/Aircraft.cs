using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class Aircraft
    {
        public Aircraft()
        {
            Items = new HashSet<Item>();
        }

        public string Registration { get; set; }
        public string Actype { get; set; }
        public long? SubType { get; set; }
        public string Effectifity { get; set; }
        public string Etops { get; set; }
        public string Status { get; set; }

        public virtual Actype ActypeNavigation { get; set; }
        public virtual SubType SubTypeNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
