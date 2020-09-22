using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class SubType
    {
        public SubType()
        {
            Aircraft = new HashSet<Aircraft>();
        }

        public long SubTypeId { get; set; }
        public string Actype { get; set; }
        public string SubTypeName { get; set; }

        public virtual Actype ActypeNavigation { get; set; }
        public virtual ICollection<Aircraft> Aircraft { get; set; }
    }
}
