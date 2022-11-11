using System;
using System.Collections.Generic;

namespace APIWithWeb.Models
{
    public partial class Loaimon
    {
        public Loaimon()
        {
            Mons = new HashSet<Mon>();
        }

        public string Maloai { get; set; } = null!;
        public string? Tenloai { get; set; }

        public virtual ICollection<Mon> Mons { get; set; }
    }
}
