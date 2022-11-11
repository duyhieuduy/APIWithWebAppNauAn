using System;
using System.Collections.Generic;

namespace APIWithWeb.Models
{
    public partial class Nguyenlieu
    {
        public Nguyenlieu()
        {
            Congthucnguyenlieus = new HashSet<Congthucnguyenlieu>();
        }

        public string Manguyenlieu { get; set; } = null!;
        public string? Tennguyenlieu { get; set; }
        public string? Anhnguyenlieu { get; set; }

        public virtual ICollection<Congthucnguyenlieu> Congthucnguyenlieus { get; set; }
    }
}
