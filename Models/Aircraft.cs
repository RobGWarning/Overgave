using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Overgave.Models
{
    public partial class Aircraft
    {
        public Aircraft()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [StringLength(10)]
        public string Registration { get; set; }
        [Column("ACType")]
        public long Actype { get; set; }
        [StringLength(10)]
        public string Effectifity { get; set; }
        [StringLength(10)]
        public string Etops { get; set; }
        [StringLength(10)]
        public string Status { get; set; }

        [ForeignKey(nameof(Actype))]
        [InverseProperty("Aircraft")]
        public virtual Actype ActypeNavigation { get; set; }
        [InverseProperty(nameof(Item.AcregNavigation))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
