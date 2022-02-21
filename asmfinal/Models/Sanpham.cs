using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace asmfinal.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitiethoadon = new HashSet<Chitiethoadon>();
            Giohang = new HashSet<Giohang>();
        }

        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }
        public double? DonGiaNhap { get; set; }
        public double? DonGiaBan { get; set; }
        public int? MaDm { get; set; }

        public virtual Danhmuc MaDmNavigation { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual ICollection<Giohang> Giohang { get; set; }
    }
}
