using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Overgave.Models
{
    public partial class SubATA
    {
        public SubATA()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [StringLength(25)]
        public string SubAta { get; set; }
        [Column("ATA")]
        public int Ata { get; set; }
        [StringLength(10)]
        public string B737 { get; set; }
        [StringLength(10)]
        public string B747 { get; set; }
        [StringLength(10)]
        public string B777 { get; set; }
        [StringLength(10)]
        public string B787 { get; set; }
        [StringLength(10)]
        public string A330 { get; set; }

        [ForeignKey(nameof(Ata))]
        [InverseProperty(nameof(ATA.SubAta))]
        public virtual ATA AtaNavigation { get; set; }
        [InverseProperty(nameof(Item.SubAtaNavigation))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
