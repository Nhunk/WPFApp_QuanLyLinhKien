/* CREATE TABLE Account (
    AccountID INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Staff'))
);
GO


CREATE TABLE KhachHang (
    KhachHangID INT IDENTITY PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(20),
    DiaChi NVARCHAR(200)
);
GO


CREATE TABLE NhanVien (
    NhanVienID INT IDENTITY PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    SDT NVARCHAR(20),
    DiaChi NVARCHAR(200),
    AccountID INT,

    CONSTRAINT FK_NhanVien_Account 
        FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);
GO


CREATE TABLE NhaCungCap (
    NhaCungCapID INT IDENTITY PRIMARY KEY,
    TenNCC NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(20),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(200)
);
GO


CREATE TABLE LoaiSanPham (
    LoaiSanPhamID INT IDENTITY PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL
);
GO


CREATE TABLE SanPham (
    SanPhamID INT IDENTITY PRIMARY KEY,
    TenSP NVARCHAR(100) NOT NULL,
    LoaiSanPhamID INT,
    DonGia DECIMAL(18,2) NOT NULL,
    HinhAnh NVARCHAR(MAX),   
    MoTa NVARCHAR(MAX),

    CONSTRAINT FK_SanPham_LoaiSanPham
        FOREIGN KEY (LoaiSanPhamID) REFERENCES LoaiSanPham(LoaiSanPhamID)
);
GO


CREATE TABLE Kho (
    KhoID INT IDENTITY PRIMARY KEY,
    SanPhamID INT NOT NULL,
    SoLuongTon INT NOT NULL DEFAULT 0,
    SoLuongToiThieu INT,

    CONSTRAINT FK_Kho_SanPham
        FOREIGN KEY (SanPhamID) REFERENCES SanPham(SanPhamID)
);
GO


CREATE TABLE PhieuNhap (
    PhieuNhapID INT IDENTITY PRIMARY KEY,
    NgayNhap DATE NOT NULL,
    NhanVienID INT,
    NhaCungCapID INT,

    CONSTRAINT FK_PhieuNhap_NhanVien
        FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID),

    CONSTRAINT FK_PhieuNhap_NhaCungCap
        FOREIGN KEY (NhaCungCapID) REFERENCES NhaCungCap(NhaCungCapID)
);
GO


CREATE TABLE ChiTietPhieuNhap (
    ChiTietPhieuNhapID INT IDENTITY PRIMARY KEY,
    PhieuNhapID INT NOT NULL,
    SanPhamID INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_ChiTietPhieuNhap_PhieuNhap
        FOREIGN KEY (PhieuNhapID) REFERENCES PhieuNhap(PhieuNhapID),

    CONSTRAINT FK_ChiTietPhieuNhap_SanPham
        FOREIGN KEY (SanPhamID) REFERENCES SanPham(SanPhamID)
);
GO


CREATE TABLE DonHang (
    DonHangID INT IDENTITY PRIMARY KEY,
    NgayLap DATE NOT NULL,
    NhanVienID INT,
    KhachHangID INT,

    CONSTRAINT FK_DonHang_NhanVien
        FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID),

    CONSTRAINT FK_DonHang_KhachHang
        FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID)
);
GO


CREATE TABLE ChiTietDonHang (
    ChiTietDonHangID INT IDENTITY PRIMARY KEY,
    DonHangID INT NOT NULL,
    SanPhamID INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_ChiTietDonHang_DonHang
        FOREIGN KEY (DonHangID) REFERENCES DonHang(DonHangID),

    CONSTRAINT FK_ChiTietDonHang_SanPham
        FOREIGN KEY (SanPhamID) REFERENCES SanPham(SanPhamID)
);
GO

INSERT INTO LoaiSanPham (TenLoai) VALUES
('CPU'),          -- 1
('GPU'),          -- 2
('RAM'),          -- 3
('SSD'),          -- 4
('HDD'),          -- 5
('Mainboard');    -- 6

INSERT INTO SanPham (TenSP, LoaiSanPhamID, DonGia, MoTa, HinhAnh) VALUES
('Intel Core i5-12400F', 1, 180.00, '6-core 12-thread CPU', 'Data/Images/cpu1.jpg'),
('Intel Core i7-12700K', 1, 350.00, '12-core 20-thread CPU', 'Data/Images/cpu2.jpg'),
('AMD Ryzen 5 5600X', 1, 200.00, '6-core 12-thread CPU', 'Data/Images/cpu3.jpg'),
('AMD Ryzen 7 5800X', 1, 320.00, '8-core 16-thread CPU', 'Data/Images/cpu4.jpg'),
('Intel Core i9-13900K', 1, 550.00, '24-core 32-thread CPU', 'Data/Images/cpu5.jpg'),
('AMD Ryzen 9 7950X', 1, 600.00, '16-core 32-thread CPU', 'Data/Images/cpu6.jpg'),
('Intel Core i3-13100', 1, 120.00, '4-core 8-thread CPU', 'Data/Images/cpu7.jpg'),
('AMD Ryzen 3 4100', 1, 90.00, '4-core 8-thread CPU', 'Data/Images/cpu8.jpg');
GO
INSERT INTO SanPham (TenSP, LoaiSanPhamID, DonGia, MoTa, HinhAnh) VALUES
('NVIDIA RTX 3060', 2, 350.00, '12GB GDDR6 VRAM', 'Data/Images/gpu1.jpg'),
('NVIDIA RTX 3070', 2, 500.00, '8GB GDDR6 VRAM', 'Data/Images/gpu2.jpg'),
('NVIDIA RTX 3080', 2, 700.00, '10GB GDDR6X VRAM', 'Data/Images/gpu3.jpg'),
('AMD RX 6600 XT', 2, 300.00, '8GB GDDR6 VRAM', 'Data/Images/gpu4.jpg'),
('AMD RX 6700 XT', 2, 450.00, '12GB GDDR6 VRAM', 'Data/Images/gpu5.jpg'),
('NVIDIA RTX 4060', 2, 400.00, '8GB GDDR6 VRAM', 'Data/Images/gpu6.jpg'),
('AMD RX 7900 XTX', 2, 950.00, '24GB GDDR6 VRAM', 'Data/Images/gpu7.jpg'),
('NVIDIA RTX 4090', 2, 1800.00, '24GB GDDR6X VRAM', 'Data/Images/gpu8.jpg');
GO
INSERT INTO SanPham (TenSP, LoaiSanPhamID, DonGia, MoTa, HinhAnh) VALUES
('Corsair Vengeance 16GB DDR4', 3, 70.00, '3200MHz', 'Data/Images/ram1.jpg'),
('G.Skill Trident Z 32GB DDR4', 3, 140.00, '3600MHz', 'Data/Images/ram2.jpg'),
('Kingston Fury 8GB DDR4', 3, 35.00, '2666MHz', 'Data/Images/ram3.jpg'),
('Teamgroup T-Force 16GB DDR5', 3, 120.00, '6000MHz', 'Data/Images/ram4.jpg'),
('Corsair Dominator 32GB DDR5', 3, 220.00, '6400MHz', 'Data/Images/ram5.jpg'),
('ADATA XPG 8GB DDR4', 3, 30.00, '3000MHz', 'Data/Images/ram6.jpg'),
('Patriot Viper Steel 16GB DDR4', 3, 75.00, '3200MHz', 'Data/Images/ram7.jpg'),
('PNY XLR8 32GB DDR5', 3, 210.00, '6200MHz', 'Data/Images/ram8.jpg');
GO
INSERT INTO SanPham (TenSP, LoaiSanPhamID, DonGia, MoTa, HinhAnh) VALUES
('Samsung 970 Evo 1TB NVMe', 4, 120.00, '3500MB/s Read', 'Data/Images/ssd1.jpg'),
('WD Blue SN570 1TB NVMe', 4, 100.00, '3300MB/s Read', 'Data/Images/ssd2.jpg'),
('Kingston NV2 1TB NVMe', 4, 90.00, '3500MB/s Read', 'Data/Images/ssd3.jpg'),
('Crucial P3 500GB NVMe', 4, 45.00, '3500MB/s Read', 'Data/Images/ssd4.jpg'),
('ADATA XPG SX8200 1TB NVMe', 4, 110.00, '3500MB/s Read', 'Data/Images/ssd5.jpg'),
('Samsung 980 500GB NVMe', 4, 50.00, '3100MB/s Read', 'Data/Images/ssd6.jpg'),
('Lexar NM620 1TB NVMe', 4, 95.00, '3300MB/s Read', 'Data/Images/ssd7.jpg'),
('WD Black SN850X 2TB NVMe', 4, 250.00, '7300MB/s Read', 'Data/Images/ssd8.jpg');
GO
INSERT INTO SanPham (TenSP, LoaiSanPhamID, DonGia, MoTa, HinhAnh) VALUES
('Seagate Barracuda 2TB', 5, 50.00, '7200RPM', 'Data/Images/hdd1.jpg'),
('WD Blue 1TB', 5, 40.00, '7200RPM', 'Data/Images/hdd2.jpg'),
('Toshiba X300 4TB', 5, 90.00, '7200RPM', 'Data/Images/hdd3.jpg'),
('Seagate IronWolf 4TB', 5, 110.00, 'NAS HDD', 'Data/Images/hdd4.jpg'),
('WD Black 2TB', 5, 75.00, '7200RPM', 'Data/Images/hdd5.jpg'),
('Toshiba P300 2TB', 5, 55.00, '7200RPM', 'Data/Images/hdd6.jpg');
GO
INSERT INTO SanPham (TenSP, LoaiSanPhamID, DonGia, MoTa, HinhAnh) VALUES
('ASUS ROG Strix B550-F', 6, 180.00, 'AMD B550 Chipset', 'Data/Images/mb1.jpg'),
('MSI MPG Z490 Gaming Edge', 6, 200.00, 'Intel Z490 Chipset', 'Data/Images/mb2.jpg'),
('Gigabyte B660M DS3H', 6, 120.00, 'Intel B660 Chipset', 'Data/Images/mb3.jpg'),
('ASRock X570 Steel Legend', 6, 210.00, 'AMD X570 Chipset', 'Data/Images/mb4.jpg'),
('ASUS TUF Gaming B660M-PLUS', 6, 160.00, 'Intel B660 Chipset', 'Data/Images/mb5.jpg'),
('MSI B450 Tomahawk Max', 6, 110.00, 'AMD B450 Chipset', 'Data/Images/mb6.jpg');
GO
*/
INSERT INTO Account (Username, Password, Role) VALUES
('admin', '123', 'Admin'),
('staff1', '123', 'Staff'),
('staff2', '123', 'Staff'),
('staff3', '123', 'Staff'),
('staff4', '123', 'Staff');
GO


INSERT INTO KhachHang (TenKH, SDT, DiaChi) VALUES
('Nguyễn Văn An', '0901111111', 'Hà Nội'),
('Trần Thị Bảo', '0902222222', 'Hồ Chí Minh'),
('Lê Văn Chung', '0903333333', 'Đà Nẵng'),
('Phạm Thị Dung', '0904444444', 'Huế'),
('Ngô Văn Nhiên', '0905555555', 'Cần Thơ'),
('Đặng Thị Thảo', '0906666666', 'Hải Phòng'),
('Võ Văn Giang', '0907777777', 'Quảng Nam'),
('Hồ Thị Hà', '0908888888', 'Vũng Tàu'),
('Mai Văn Linh', '0909999999', 'Thanh Hóa'),
('Chu Thị Khanh', '0901234567', 'Bắc Ninh');
GO

INSERT INTO NhanVien (TenNV, NgaySinh, GioiTinh, SDT, DiaChi, AccountID) VALUES
('Nguyễn Văn Admin', '1988-01-01', 'Nam', '0911000001', 'Hà Nội', 1),
('Trần Thị Staff 1', '1995-05-10', 'Nữ', '0911000002', 'Hồ Chí Minh', 2),
('Lê Minh Staff 2', '1992-03-15', 'Nam', '0911000003', 'Đà Nẵng', 3),
('Phạm Thảo Staff 3', '1998-07-20', 'Nữ', '0911000004', 'Huế', 4),
('Võ Tuấn Staff 4', '1990-08-22', 'Nam', '0911000005', 'Cần Thơ', 5);
GO

INSERT INTO NhaCungCap (TenNCC, SDT, Email, DiaChi) VALUES
('FPT Distribution', '0908001122', 'contact@fpt.com', 'Hà Nội'),
('Phong Vũ', '0909002211', 'info@phongvu.vn', 'Hồ Chí Minh'),
('GearVN', '0911223344', 'support@gearvn.vn', 'Hồ Chí Minh'),
('Hoàng Hà PC', '0912334455', 'sales@hoanghapc.vn', 'Hà Nội'),
('MemoryZone', '0913445566', 'contact@memoryzone.vn', 'Đà Nẵng'),
('An Khang', '0914556677', 'support@ankhang.vn', 'Hà Nội'),
('Hanoicomputer', '0915667788', 'info@hanoicomputer.vn', 'Hà Nội'),
('Nguyễn Công PC', '0916778899', 'info@nguyencong.vn', 'Hải Phòng'),
('Văn Phong PC', '0916889900', 'vp@vanphongpc.vn', 'Huế'),
('G-Tek', '0917990011', 'contact@gtek.vn', 'Cần Thơ');
GO


INSERT INTO Kho (SanPhamID, SoLuongTon, SoLuongToiThieu) VALUES
(1, 50, 5),
(2, 40, 5),
(3, 60, 10),
(4, 30, 5),
(5, 25, 5),
(6, 20, 5),
(7, 70, 10),
(8, 80, 5),
(9, 90, 10),
(10, 100, 5);
GO

INSERT INTO PhieuNhap (NgayNhap, NhanVienID, NhaCungCapID) VALUES
('2024-01-01', 1, 1),
('2024-01-05', 2, 2),
('2024-01-10', 3, 3),
('2024-01-12', 4, 4),
('2024-01-15', 5, 5),
('2024-01-18', 1, 6),
('2024-01-20', 2, 7),
('2024-01-22', 3, 8),
('2024-01-25', 4, 9),
('2024-01-28', 5, 10);
GO

INSERT INTO ChiTietPhieuNhap (PhieuNhapID, SanPhamID, SoLuong, DonGia) VALUES
(1, 1, 20, 150.00),
(2, 2, 10, 350.00),
(3, 3, 15, 200.00),
(4, 4, 12, 320.00),
(5, 5, 10, 550.00),
(6, 6, 8, 600.00),
(7, 7, 25, 120.00),
(8, 8, 20, 90.00),
(9, 9, 15, 300.00),
(10, 10, 22, 400.00);
GO

INSERT INTO DonHang (NgayLap, NhanVienID, KhachHangID) VALUES
('2024-02-01', 1, 1),
('2024-02-03', 2, 2),
('2024-02-05', 3, 3),
('2024-02-07', 4, 4),
('2024-02-09', 5, 5),
('2024-02-11', 1, 6),
('2024-02-13', 2, 7),
('2024-02-15', 3, 8),
('2024-02-17', 4, 9),
('2024-02-19', 5, 10);
GO 

INSERT INTO ChiTietDonHang (DonHangID, SanPhamID, SoLuong, DonGia) VALUES
(1, 1, 1, 180.00),
(2, 2, 2, 350.00),
(3, 3, 1, 200.00),
(4, 4, 1, 320.00),
(5, 5, 1, 550.00),
(6, 6, 1, 600.00),
(7, 7, 2, 120.00),
(8, 8, 1, 90.00),
(9, 9, 1, 300.00),
(10, 10, 3, 400.00);
GO


INSERT INTO DonHang (NgayLap, NhanVienID, KhachHangID) VALUES
('2024-02-01', 1, 1),
('2024-02-03', 2, 2),
('2024-02-05', 3, 3),
('2024-02-07', 4, 4),
('2024-02-09', 5, 5),
('2024-02-11', 6, 6),
('2024-02-13', 7, 7),
('2024-02-15', 8, 8),
('2024-02-17', 9, 9),
('2024-02-19', 10, 10);
GO

INSERT INTO ChiTietDonHang (DonHangID, SanPhamID, SoLuong, DonGia) VALUES
(1, 1, 1, 180.00),
(2, 2, 2, 350.00),
(3, 3, 1, 200.00),
(4, 4, 1, 320.00),
(5, 5, 1, 550.00),
(6, 6, 1, 600.00),
(7, 7, 2, 120.00),
(8, 8, 1, 90.00),
(9, 9, 1, 300.00),
(10, 10, 3, 400.00);
GO
