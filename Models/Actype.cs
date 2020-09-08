using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Overgave.Models
{
    [Table("ACTypes")]
    public partial class Actype
    {
        public Actype()
        {
            Aircraft = new HashSet<Aircraft>();
        }

        [Key]
        [Column("ACTypes")]
        public long Actypes { get; set; }
        [Required]
        [StringLength(10)]
        public string TypeName { get; set; }
        [StringLength(10)]
        public string SubType { get; set; }

        [InverseProperty("ActypeNavigation")]
        public virtual ICollection<Aircraft> Aircraft { get; set; }
    }
}
