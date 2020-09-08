using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Overgave.Models
{
    public partial class Reference
    {
        [Key]
        public long RefId { get; set; }
        public long ItemId { get; set; }
        [Required]
        [StringLength(10)]
        public string RefType { get; set; }
        [Required]
        [Column("Reference")]
        [StringLength(10)]
        public string Reference1 { get; set; }
        [StringLength(10)]
        public string Status { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("References")]
        public virtual Item Item { get; set; }
    }
}
