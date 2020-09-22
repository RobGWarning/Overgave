using System;
using System.Collections.Generic;

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

        public long ItemId { get; set; }
        public DateTime DateTime { get; set; }
        public string Acreg { get; set; }
        public int? Ata { get; set; }
        public int? Said { get; set; }
        public string Initiator { get; set; }
        public string VakGroep { get; set; }
        public string Catagorie { get; set; }
        public string Text { get; set; }
        public string Responce { get; set; }
        public string ItemStatus { get; set; }
        public bool AddToPrint { get; set; }
        public bool ActionReq { get; set; }
        public string Etopsaffected { get; set; }
        public long? OrgId { get; set; }

        public virtual Aircraft AcregNavigation { get; set; }
        public virtual ATA AtaNavigation { get; set; }
        public virtual TS InitiatorNavigation { get; set; }
        public virtual SubAta Sa { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<Reference> References { get; set; }
    }
}
