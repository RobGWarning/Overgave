using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Overgave.Models
{
    public partial class Item
    {
        public Item()
        {
            Parts = new HashSet<Part>();
            References = new HashSet<Reference>();
        }

        [Key]
        public long ItemId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(10)]
        [Column("ACReg")]
        public string Acreg { get; set; }
        [Column("ATA")]
        public int? Ata { get; set; }
        public string SubAta { get; set; }
        [Required]
        [StringLength(10)]
        public string Initiator { get; set; }
        [Required]
        [StringLength(10)]
        public string VakGroep { get; set; }
        [StringLength(10)]
        public string Catagorie { get; set; }
        [Required]
        public string Text { get; set; }
        public string Responce { get; set; }
        [Required]
        [StringLength(10)]
        public string ItemStatus { get; set; }
        public bool AddToPrint { get; set; }
        public bool ActionReq { get; set; }
        [Required]
        [Column("ETOPSAffected")]
        [StringLength(10)]
        public string Etopsaffected { get; set; }
        [Column("orgId")]
        public long? OrgId { get; set; }

        [ForeignKey(nameof(Acreg))]
        [InverseProperty(nameof(Aircraft.Items))]
        public virtual Aircraft AcregNavigation { get; set; }
        [ForeignKey(nameof(Ata))]
        [InverseProperty(nameof(ATA.Items))]
        public virtual ATA AtaNavigation { get; set; }
        [ForeignKey(nameof(Initiator))]
        [InverseProperty(nameof(TS.Items))]
        public virtual TS InitiatorNavigation { get; set; }
        [ForeignKey(nameof(SubAta))]
        [InverseProperty(nameof(SubATA.Items))]
        public virtual SubATA SubAtaNavigation { get; set; }
        [InverseProperty(nameof(Part.Item))]
        public virtual ICollection<Part> Parts { get; set; }
        [InverseProperty(nameof(Reference.Item))]
        public virtual ICollection<Reference> References { get; set; }
    }
}
