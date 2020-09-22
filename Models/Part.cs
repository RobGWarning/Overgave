using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class Part
    {
        public long PartId { get; set; }
        public long ItemId { get; set; }
        public string Description { get; set; }
        public string RaPn { get; set; }
        public string SnVn { get; set; }
        public bool InOut { get; set; }
        public string Remark { get; set; }

        public virtual Item Item { get; set; }
    }
}
