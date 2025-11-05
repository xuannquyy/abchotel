CREATE DATABASE QuanLyKhachSan;
GO
USE QuanLyKhachSan;

-- Bảng người dùng (dành cho formLogin)
CREATE TABLE NguoiDung (
    MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50),
    MatKhau NVARCHAR(100),
    HoTen NVARCHAR(100),
	Email NVARCHAR(100),
    VaiTro NVARCHAR(20)
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
    TrangThai NVARCHAR(20),      
    DonGia DECIMAL(18,2)
);

-- Bảng đặt phòng
CREATE TABLE DatPhong (
    MaDatPhong INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong INT FOREIGN KEY REFERENCES Phong(MaPhong),
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    NgayNhan DATE,
    NgayTra DATE,
	SoNguoiO INT DEFAULT 1,
    TongTien DECIMAL(18,2)
);
-- Bảng dịch vụ
CREATE TABLE DichVu (
    MaDichVu INT IDENTITY(1,1) PRIMARY KEY,
    TenDichVu NVARCHAR(100),
    DonGia DECIMAL(18,2)
);
-- Bảng hóa đơn
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaDatPhong INT FOREIGN KEY REFERENCES DatPhong(MaDatPhong),
	MaDichVu INT FOREIGN KEY REFERENCES DichVu(MaDichVu),
    NgayLap DATE,
    ThanhTien DECIMAL(18,2)
);

-- Thêm 1 tài khoản admin mặc định
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, VaiTro)
VALUES ('admin', 'admin', N'Quản trị hệ thống', 'vienxuanquy82024@gmail.com', 'Admin');

-- Thêm 1 tài khoản nhân viên ví dụ
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, VaiTro)
VALUES (N'Trương Thị Ánh', '123456', N'Nhân viên lễ tân', 'truongthianh23ct112@gmail.com', 'User');

INSERT INTO DichVu (TenDichVu, DonGia)
VALUES
(N'Ăn sáng buffet', 150000),
(N'Spa / Massage', 800000),
(N'Thuê xe', 1500000),
(N'Thuê phòng họp', 2000000),
(N'Minibar trong phòng', 100000),
(N'Karaoke / Bar Club', 800000),
(N'Giặt ủi', 50000),
(N'Dịch vụ tổ chức tiệc', 2000000);

INSERT INTO Phong (SoPhong, LoaiPhong, TrangThai, DonGia)
VALUES
-- VIP
(N'VIP301', N'VIP - Phòng Đôi', N'Trống', 3500000),
(N'VIP302', N'VIP - Phòng Đơn', N'Trống', 3000000),
(N'VIP303', N'VIP - Phòng Đôi', N'Trống', 3500000),
(N'VIP304', N'VIP - Phòng Đơn', N'Trống', 3000000),
-- Phòng Đôi (A2xx)
(N'A201', N'Phòng Đôi', N'Trống', 1800000),
(N'A202', N'Phòng Đôi', N'Trống', 1800000),
(N'A203', N'Phòng Đôi', N'Trống', 1800000),
(N'A204', N'Phòng Đôi', N'Trống', 1800000),
(N'A205', N'Phòng Đôi', N'Trống', 1800000),
(N'A206', N'Phòng Đôi', N'Trống', 1800000),
(N'A207', N'Phòng Đôi', N'Trống', 1800000),
(N'A208', N'Phòng Đôi', N'Trống', 1800000),
-- Phòng Đơn (A1xx)
(N'A101', N'Phòng Đơn', N'Trống', 1200000),
(N'A102', N'Phòng Đơn', N'Trống', 1200000),
(N'A103', N'Phòng Đơn', N'Trống', 1200000),
(N'A104', N'Phòng Đơn', N'Trống', 1200000),
(N'A105', N'Phòng Đơn', N'Trống', 1200000),
(N'A106', N'Phòng Đơn', N'Trống', 1200000),
(N'A107', N'Phòng Đơn', N'Trống', 1200000),
(N'A108', N'Phòng Đơn', N'Trống', 1200000);
GO

INSERT INTO KhachHang (HoTen, GioiTinh, NgaySinh, CCCD, SoDienThoai, DiaChi)
VALUES
(N'Nguyễn Văn An', N'Nam', '1990-05-15', '012345678901', '0905123456', N'123 Lê Lợi, Q1, TP. HCM'),
(N'Trần Thị Bảo', N'Nữ', '1995-11-20', '023456789012', '0913234567', N'456 Hai Bà Trưng, Hà Nội'),
(N'Lê Minh Cường', N'Nam', '1988-02-01', '034567890123', '0987654321', N'789 Nguyễn Văn Linh, Đà Nẵng'),
(N'Phạm Thùy Dung', N'Nữ', '2000-07-30', '045678901234', '0334455667', N'101 Võ Thị Sáu, Cần Thơ');
GO

-- Lưu ý: Các MaPhong và MaKhachHang dưới đây đang giả định IDENTITY bắt đầu từ 1.
-- Ví dụ: MaKhachHang 1 = Nguyễn Văn An, MaPhong 1 = VIP301, MaPhong 5 = A201, MaPhong 13 = A101

-- Khách 1 (Nguyễn Văn An) đặt phòng VIP301 (MaPhong 1) (2 đêm)
INSERT INTO DatPhong (MaPhong, MaKhachHang, NgayNhan, NgayTra, SoNguoiO, TongTien)
VALUES (1, 1, '2024-10-25', '2024-10-27', 2, 7000000); -- (3.5tr * 2 đêm)
GO
-- Khách 2 (Trần Thị Bảo) đặt phòng A201 (MaPhong 5) (3 đêm)
INSERT INTO DatPhong (MaPhong, MaKhachHang, NgayNhan, NgayTra, SoNguoiO, TongTien)
VALUES (5, 2, '2024-10-26', '2024-10-29', 2, 5400000); -- (1.8tr * 3 đêm)
GO
-- Khách 3 (Lê Minh Cường) đặt phòng A101 (MaPhong 13) (1 đêm)
INSERT INTO DatPhong (MaPhong, MaKhachHang, NgayNhan, NgayTra, SoNguoiO, TongTien)
VALUES (13, 3, '2024-10-26', '2024-10-27', 1, 1200000); -- (1.2tr * 1 đêm)
GO

-- Cập nhật trạng thái các phòng đã được đặt
UPDATE Phong SET TrangThai = N'Đang ở' WHERE SoPhong = N'VIP301';
UPDATE Phong SET TrangThai = N'Đang ở' WHERE SoPhong = N'A201';
UPDATE Phong SET TrangThai = N'Đang ở' WHERE SoPhong = N'A101';
GO


-- Lưu ý: MaDatPhong và MaDichVu cũng giả định IDENTITY bắt đầu từ 1.
-- MaDatPhong 1 = Đặt phòng của Nguyễn Văn An
-- MaDatPhong 2 = Đặt phòng của Trần Thị Bảo

-- Khách 1 (DatPhong 1) dùng Spa (MaDichVu 2, giá 800k)
INSERT INTO HoaDon (MaDatPhong, MaDichVu, NgayLap, ThanhTien)
VALUES (1, 2, '2024-10-26', 800000);
GO
-- Khách 1 (DatPhong 1) dùng Minibar (MaDichVu 5, giá 100k)
INSERT INTO HoaDon (MaDatPhong, MaDichVu, NgayLap, ThanhTien)
VALUES (1, 5, '2024-10-26', 100000);
GO
-- Khách 2 (DatPhong 2) dùng Ăn sáng buffet (MaDichVu 1, giá 150k)
INSERT INTO HoaDon (MaDatPhong, MaDichVu, NgayLap, ThanhTien)
VALUES (2, 1, '2024-10-27', 150000);
GO
-- Khách 2 (DatPhong 2) dùng Giặt ủi (MaDichVu 7, giá 50k)
INSERT INTO HoaDon (MaDatPhong, MaDichVu, NgayLap, ThanhTien)
VALUES (2, 7, '2024-10-28', 50000);
GO