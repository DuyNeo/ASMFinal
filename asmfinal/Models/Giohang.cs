using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace asmfinal.Models
{
    public partial class Giohang
    {
        public int MaHang { get; set; }
        public int SoLuong { get; set; }
        public int MaKhach { get; set; }

        public virtual Sanpham MaHangNavigation { get; set; }
        public virtual Khachhang MaKhachNavigation { get; set; }
    }
}
