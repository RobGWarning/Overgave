using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class Actype
    {
        public Actype()
        {
            Aircraft = new HashSet<Aircraft>();
            DefaultUserTypes = new HashSet<DefaultUserType>();
            SubAta = new HashSet<SubAta>();
            SubTypes = new HashSet<SubType>();
        }

        public string Actypes { get; set; }

        public virtual ICollection<Aircraft> Aircraft { get; set; }
        public virtual ICollection<DefaultUserType> DefaultUserTypes { get; set; }
        public virtual ICollection<SubAta> SubAta { get; set; }
        public virtual ICollection<SubType> SubTypes { get; set; }
    }
}
