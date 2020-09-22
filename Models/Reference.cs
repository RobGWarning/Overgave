using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class Reference
    {
        public long RefId { get; set; }
        public long ItemId { get; set; }
        public string RefType { get; set; }
        public string Reference1 { get; set; }
        public string Status { get; set; }

        public virtual Item Item { get; set; }
    }
}
