using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class ATA
    {
        public ATA()
        {
            Items = new HashSet<Item>();
            SubAta = new HashSet<SubAta>();
        }

        public int Ata { get; set; }
        public string AtaText { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<SubAta> SubAta { get; set; }
    }
}
