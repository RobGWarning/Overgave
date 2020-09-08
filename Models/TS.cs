using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Overgave.Models
{
    [Table("TS")]
    public partial class TS
    {
        public TS()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [StringLength(10)]
        [Column("KLMId")]
        public string Klmid { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Initial { get; set; }
        public bool B1 { get; set; }
        public bool B2 { get; set; }
        public bool Def737 { get; set; }
        public bool Def747 { get; set; }
        public bool Def777 { get; set; }
        public bool Def787 { get; set; }
        public bool DefA330 { get; set; }
        public bool isAdmin { get; set; }
        public bool isReadOnly { get; set; }

        [InverseProperty(nameof(Item.InitiatorNavigation))]
        public virtual ICollection<Item> Items { get; set; }
    }
}
