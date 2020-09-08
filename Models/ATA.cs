using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Overgave.Models
{
    [Table("ATA")]
    public partial class ATA
    {
        public ATA()
        {
            Items = new HashSet<Item>();
            SubAta = new HashSet<SubATA>();
        }

        [Key]
        [Column("ATA")]
        public int Ata { get; set; }
        [StringLength(25)]
        public string AtaText { get; set; }

        [InverseProperty(nameof(Item.AtaNavigation))]
        public virtual ICollection<Item> Items { get; set; }
        [InverseProperty(nameof(SubATA.AtaNavigation))]
        public virtual ICollection<SubATA> SubAta { get; set; }
    }
}
