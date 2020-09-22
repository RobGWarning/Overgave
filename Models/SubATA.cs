using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class SubAta
    {
        public SubAta()
        {
            Items = new HashSet<Item>();
        }

        public int Said { get; set; }
        public int Ata { get; set; }
        public string Actype { get; set; }
        public string Subject { get; set; }

        public virtual Actype ActypeNavigation { get; set; }
        public virtual ATA AtaNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
