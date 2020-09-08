using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Overgave.Models
{
    public partial class Part
    {
        [Key]
        public long PartId { get; set; }
        public long ItemId { get; set; }
        [Required]
        [StringLength(20)]
        public string Description { get; set; }
        [StringLength(20)]
        public string RaPn { get; set; }
        [StringLength(20)]
        public string SnVn { get; set; }
        public bool InOut { get; set; }
        public string Remark { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty("Parts")]
        public virtual Item Item { get; set; }
    }
}
