using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace asmfinal.Models
{
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        public int MaDm { get; set; }
        public string TenDm { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
