create database ASM;
go;
use ASM;
go
--drop database ASM;
create table DANHMUC(
	maDM int identity primary key,
	tenDM nvarchar(100) not null	
);
go
create table NHANVIEN(
	tenNV nvarchar(30) not null,
	email nvarchar(30) primary key not null,
	matKhau nvarchar(30) not null,
	soDienThoai nvarchar(30) not null,
);

go
create table KHACHHANG(
	maKhach int identity primary key,
	tenKhach nvarchar(100) not null,
	gioiTinh bit not null,
	diaChi nvarchar(100) not null,
	soDienThoai nvarchar(30) not null,
	ngaySinh date not null,
	matKhau nvarchar(100) not null
);
Alter table KHACHHANG
ADD email nvarchar(30) not null
;
go
create table SANPHAM(
	maHang int identity primary key,
	tenHang nvarchar(100) not null,
	soLuong int not null,
	hinhAnh nvarchar(200),
	donGiaNhap float,
	donGiaBan float,
	MaDM int references DANHMUC(maDM)
);
select * from SANPHAM
select * from KHACHHANG
select * from DANHMUC
select * from NHANVIEN

select count(*) from SANPHAM
go
create table GIOHANG(
	maHang int references SANPHAM(maHang) ,
	soLuong int not null,
	maKhach int references KHACHHANG(maKhach) ,
	Primary key(maHang,maKhach)
);
go
create table CHITIETHOADON (
	maKhach int references KHACHHANG(maKhach) ,
	maHang int  references SANPHAM(maHang),
	ngayBan datetime,
	tongTien float not null,
	Primary key(maHang,maKhach)
);

