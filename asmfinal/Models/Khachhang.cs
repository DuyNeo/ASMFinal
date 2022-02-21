using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace asmfinal.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Chitiethoadon = new HashSet<Chitiethoadon>();
            Giohang = new HashSet<Giohang>();
        }

        public int MaKhach { get; set; }
        public string TenKhach { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual ICollection<Giohang> Giohang { get; set; }
    }
}
