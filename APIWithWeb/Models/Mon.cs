using System;
using System.Collections.Generic;

namespace APIWithWeb.Models
{
    public partial class Mon
    {
        public Mon()
        {
            Anhmonans = new HashSet<Anhmonan>();
            Binhluans = new HashSet<Binhluan>();
            Congthucnguyenlieus = new HashSet<Congthucnguyenlieu>();
            Nguoidungsaves = new HashSet<Nguoidungsave>();
        }

        public string Mamon { get; set; } = null!;
        public string? Tenmon { get; set; }
        public string? Maloai { get; set; }
        public string? Congthuclam { get; set; }

        public virtual Loaimon? MaloaiNavigation { get; set; }
        public virtual ICollection<Anhmonan> Anhmonans { get; set; }
        public virtual ICollection<Binhluan> Binhluans { get; set; }
        public virtual ICollection<Congthucnguyenlieu> Congthucnguyenlieus { get; set; }
        public virtual ICollection<Nguoidungsave> Nguoidungsaves { get; set; }
    }
}
