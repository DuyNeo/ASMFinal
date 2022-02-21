using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace asmfinal.Models
{
    public partial class ASMContext : DbContext
    {
        public ASMContext()
        {
        }

        public ASMContext(DbContextOptions<ASMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual DbSet<Danhmuc> Danhmuc { get; set; }
        public virtual DbSet<Giohang> Giohang { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-57JQHV8\\DNEO;Database=ASM;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.MaHang, e.MaKhach })
                    .HasName("PK__CHITIETH__BEA0798A8BFDD6ED");

                entity.ToTable("CHITIETHOADON");

                entity.Property(e => e.MaHang).HasColumnName("maHang");

                entity.Property(e => e.MaKhach).HasColumnName("maKhach");

                entity.Property(e => e.NgayBan)
                    .HasColumnName("ngayBan")
                    .HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnName("tongTien");

                entity.HasOne(d => d.MaHangNavigation)
                    .WithMany(p => p.Chitiethoadon)
                    .HasForeignKey(d => d.MaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETHO__maHan__5441852A");

                entity.HasOne(d => d.MaKhachNavigation)
                    .WithMany(p => p.Chitiethoadon)
                    .HasForeignKey(d => d.MaKhach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETHO__maKha__534D60F1");
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DANHMUC__7A3EF408A857341F");

                entity.ToTable("DANHMUC");

                entity.Property(e => e.MaDm).HasColumnName("maDM");

                entity.Property(e => e.TenDm)
                    .IsRequired()
                    .HasColumnName("tenDM")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Giohang>(entity =>
            {
                entity.HasKey(e => new { e.MaHang, e.MaKhach })
                    .HasName("PK__GIOHANG__BEA0798A911C3CA7");

                entity.ToTable("GIOHANG");

                entity.Property(e => e.MaHang).HasColumnName("maHang");

                entity.Property(e => e.MaKhach).HasColumnName("maKhach");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.HasOne(d => d.MaHangNavigation)
                    .WithMany(p => p.Giohang)
                    .HasForeignKey(d => d.MaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GIOHANG__maHang__4F7CD00D");

                entity.HasOne(d => d.MaKhachNavigation)
                    .WithMany(p => p.Giohang)
                    .HasForeignKey(d => d.MaKhach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GIOHANG__maKhach__5070F446");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKhach)
                    .HasName("PK__KHACHHAN__C2CDABB682C8D21A");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.MaKhach).HasColumnName("maKhach");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasColumnName("diaChi")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.GioiTinh).HasColumnName("gioiTinh");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasColumnName("matKhau")
                    .HasMaxLength(100);

                entity.Property(e => e.NgaySinh)
                    .HasColumnName("ngaySinh")
                    .HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .IsRequired()
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(30);

                entity.Property(e => e.TenKhach)
                    .IsRequired()
                    .HasColumnName("tenKhach")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__NHANVIEN__AB6E6165013F2AC2");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasColumnName("matKhau")
                    .HasMaxLength(30);

                entity.Property(e => e.SoDienThoai)
                    .IsRequired()
                    .HasColumnName("soDienThoai")
                    .HasMaxLength(30);

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasColumnName("tenNV")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.MaHang)
                    .HasName("PK__SANPHAM__C28CA3310BBD0B23");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.MaHang).HasColumnName("maHang");

                entity.Property(e => e.DonGiaBan).HasColumnName("donGiaBan");

                entity.Property(e => e.DonGiaNhap).HasColumnName("donGiaNhap");

                entity.Property(e => e.HinhAnh)
                    .HasColumnName("hinhAnh")
                    .HasMaxLength(200);

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.TenHang)
                    .IsRequired()
                    .HasColumnName("tenHang")
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.Sanpham)
                    .HasForeignKey(d => d.MaDm)
                    .HasConstraintName("FK__SANPHAM__MaDM__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
