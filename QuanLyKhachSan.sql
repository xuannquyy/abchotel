CREATE DATABASE QuanLyKhachSan;
GO
USE QuanLyKhachSan;

-- Bảng người dùng (dành cho formLogin)
CREATE TABLE NguoiDung (
    MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50),
    MatKhau NVARCHAR(100),
    HoTen NVARCHAR(100)
);

-- Bảng khách hàng
CREATE TABLE KhachHang (
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100),
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    CCCD NVARCHAR(20),
    SoDienThoai NVARCHAR(15),
    DiaChi NVARCHAR(200)
);

-- Bảng phòng
CREATE TABLE Phong (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong NVARCHAR(20),
    LoaiPhong NVARCHAR(50),
    TrangThai NVARCHAR(20),      -- "Trong" hoặc "Dang o"
    DonGia DECIMAL(18,2)
);

-- Bảng đặt phòng
CREATE TABLE DatPhong (
    MaDatPhong INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong INT FOREIGN KEY REFERENCES Phong(MaPhong),
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    NgayNhan DATE,
    NgayTra DATE,
    TongTien DECIMAL(18,2)
);

-- Bảng hóa đơn
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaDatPhong INT FOREIGN KEY REFERENCES DatPhong(MaDatPhong),
    NgayLap DATE,
    ThanhTien DECIMAL(18,2)
);

-- Bảng dịch vụ
CREATE TABLE DichVu (
    MaDichVu INT IDENTITY(1,1) PRIMARY KEY,
    TenDichVu NVARCHAR(100),
    DonGia DECIMAL(18,2)
);
