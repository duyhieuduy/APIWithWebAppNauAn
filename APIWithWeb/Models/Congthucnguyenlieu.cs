using System;
using System.Collections.Generic;

namespace APIWithWeb.Models
{
    public partial class Congthucnguyenlieu
    {
        public int Ctnlid { get; set; }
        public string Mamon { get; set; } = null!;
        public string? Manguyenlieu { get; set; }
        public string? Khoiluong { get; set; }

        public virtual Mon MamonNavigation { get; set; } = null!;
        public virtual Nguyenlieu? ManguyenlieuNavigation { get; set; }
    }
}
