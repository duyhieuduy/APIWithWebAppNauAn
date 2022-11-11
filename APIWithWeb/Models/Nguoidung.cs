using System;
using System.Collections.Generic;

namespace APIWithWeb.Models
{
    public partial class Nguoidung
    {
        public Nguoidung()
        {
            Binhluans = new HashSet<Binhluan>();
            Nguoidungsaves = new HashSet<Nguoidungsave>();
            Thongbaos = new HashSet<Thongbao>();
        }

        public string Tendangnhap { get; set; } = null!;
        public string? Matkhau { get; set; }

        public virtual ICollection<Binhluan> Binhluans { get; set; }
        public virtual ICollection<Nguoidungsave> Nguoidungsaves { get; set; }
        public virtual ICollection<Thongbao> Thongbaos { get; set; }
    }
}
