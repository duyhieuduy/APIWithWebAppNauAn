using System;
using System.Collections.Generic;

namespace APIWithWeb.Models
{
    public partial class Nguoidungsave
    {
        public string Tendangnhap { get; set; } = null!;
        public string Mamon { get; set; } = null!;
        public int IdNds { get; set; }

        public virtual Mon MamonNavigation { get; set; } = null!;
        public virtual Nguoidung TendangnhapNavigation { get; set; } = null!;
    }
}
