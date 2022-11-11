using System;
using System.Collections.Generic;

namespace APIWithWeb.Models
{
    public partial class Thongbao
    {
        public string Tendangnhap { get; set; } = null!;
        public string? Noidungtb { get; set; }
        public int IdTb { get; set; }

        public virtual Nguoidung TendangnhapNavigation { get; set; } = null!;
    }
}
