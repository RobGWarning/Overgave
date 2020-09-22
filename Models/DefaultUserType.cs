using System;
using System.Collections.Generic;

#nullable disable

namespace Overgave.Models
{
    public partial class DefaultUserType
    {
        public string Klmid { get; set; }
        public string Actype { get; set; }

        public virtual Actype ActypeNavigation { get; set; }
        public virtual TS Klm { get; set; }
    }
}
