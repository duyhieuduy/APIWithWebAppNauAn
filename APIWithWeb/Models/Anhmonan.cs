using System;
using System.Collections.Generic;

namespace APIWithWeb.Models
{
    public partial class Anhmonan
    {
        public string? Anhmon { get; set; }
        public string Mamon { get; set; } = null!;
        public int IdAma { get; set; }

        public virtual Mon MamonNavigation { get; set; } = null!;
    }
}
