-- Tạo bảng quyền
CREATE TABLE Quyen (
    MaQuyen INT PRIMARY KEY IDENTITY,
    TenQuyen NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(255)
);

-- Thêm dữ liệu mẫu cho bảng quyền
INSERT INTO Quyen (TenQuyen, MoTa)
VALUES 
('Admin', 'Quyền quản trị hệ thống'),
('Huấn luyện viên', 'Quyền dành cho huấn luyện viên'),
('Thành viên', 'Quyền dành cho thành viên tập gym');

-- Tạo bảng tài khoản
CREATE TABLE TaiKhoan (
    MaTK INT PRIMARY KEY IDENTITY,
    TenDangNhap NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(50),
    TrangThai NVARCHAR(20),
    MaQuyen INT FOREIGN KEY REFERENCES Quyen(MaQuyen)
);

-- Tạo bảng thành viên
CREATE TABLE ThanhVien (
    MaTV INT PRIMARY KEY IDENTITY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(200),
    NgayDangKy DATE,
    AnhDaiDien VARBINARY(MAX),
    MaTK INT FOREIGN KEY REFERENCES TaiKhoan(MaTK),
    TrangThai NVARCHAR(20)
);

-- Tạo bảng khách vãng lai
CREATE TABLE KhachVangLai (
    MaKVL INT PRIMARY KEY IDENTITY,
    HoTen NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    NgayGhiNhan DATE DEFAULT GETDATE(),
    GhiChu NVARCHAR(500),
    TrangThai NVARCHAR(20) DEFAULT N'HoatDong'
);

-- Tạo bảng khuyến mãi
CREATE TABLE KhuyenMai (
    MaKM INT PRIMARY KEY IDENTITY,
    TenKM NVARCHAR(100),
    MoTa NVARCHAR(500),
    PhanTramGiam INT,
    NgayBatDau DATE,
    NgayKetThuc DATE,
    TrangThai NVARCHAR(20)
);

-- Tạo bảng gói tập
CREATE TABLE GoiTap (
    MaGoi INT PRIMARY KEY IDENTITY,
    TenGoi NVARCHAR(100),
    MoTa NVARCHAR(500),
    ThoiHanThang INT,
    GiaTien DECIMAL(18,2),
    SoLanTapToiDa INT,
    MaKM INT FOREIGN KEY REFERENCES KhuyenMai(MaKM)
);

-- Tạo bảng lớp học
CREATE TABLE LopHoc (
    MaLop INT PRIMARY KEY IDENTITY,
    TenLop NVARCHAR(100) NOT NULL,
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(MaPT),
    ThoiGianBatDau TIME NOT NULL,
    ThoiGianKetThuc TIME NOT NULL,
    NgayTrongTuan NVARCHAR(20) NOT NULL,
    SoLuongToiDa INT NOT NULL,
    SoLuongHienTai INT DEFAULT 0,
    TrangThai NVARCHAR(20) DEFAULT 'DangMo',
    GhiChu NVARCHAR(500)
);

-- Tạo bảng đăng ký thống nhất
CREATE TABLE DangKy (
    MaDangKy INT PRIMARY KEY IDENTITY(1,1),
    MaThanhVien INT NULL,
    MaKhachVangLai INT NULL,
    MaGoiTap INT NULL, -- Nullable: nếu là đăng ký lớp học thì không cần
    MaLopHoc INT NULL, -- Nullable: nếu là đăng ký gói tập thì không cần
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    LoaiDangKy NVARCHAR(20) NOT NULL CHECK (LoaiDangKy IN (N'GoiTap', N'LopHoc')),
    SoBuoi INT,
    TrangThai NVARCHAR(20) DEFAULT N'ConHieuLuc',
    GhiChu NVARCHAR(500),
    FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaTV),
    FOREIGN KEY (MaKhachVangLai) REFERENCES KhachVangLai(MaKVL),
    FOREIGN KEY (MaGoiTap) REFERENCES GoiTap(MaGoi),
    FOREIGN KEY (MaLopHoc) REFERENCES LopHoc(MaLop),
    -- Đảm bảo hoặc là thành viên hoặc là khách vãng lai
    CHECK ((MaThanhVien IS NULL AND MaKhachVangLai IS NOT NULL) OR (MaThanhVien IS NOT NULL AND MaKhachVangLai IS NULL))
);

-- Tạo bảng lịch sử đăng ký
CREATE TABLE LichSuDangKy (
    MaLichSu INT PRIMARY KEY IDENTITY,
    MaTV INT FOREIGN KEY REFERENCES ThanhVien(MaTV),
    MaGoi INT FOREIGN KEY REFERENCES GoiTap(MaGoi),
    NgayDangKy DATE,
    TrangThai NVARCHAR(50)
);

-- Tạo bảng huấn luyện viên
CREATE TABLE HuanLuyenVien (
    MaPT INT PRIMARY KEY IDENTITY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    SDT NVARCHAR(15),
    Email NVARCHAR(100),
    ChuyenMon NVARCHAR(200),
    TrangThai NVARCHAR(20)
);

-- Tạo bảng lịch sử check-in
CREATE TABLE LichSuCheckIn (
    MaCheckIn INT PRIMARY KEY IDENTITY,
    MaTV INT NULL,
    MaKVL INT NULL,
    ThoiGian DATETIME,
    KetQuaNhanDien BIT,
    AnhNhanDien VARBINARY(MAX),
    FOREIGN KEY (MaTV) REFERENCES ThanhVien(MaTV),
    FOREIGN KEY (MaKVL) REFERENCES KhachVangLai(MaKVL),
    -- Đảm bảo hoặc là thành viên hoặc là khách vãng lai
    CHECK ((MaTV IS NULL AND MaKVL IS NOT NULL) OR (MaTV IS NOT NULL AND MaKVL IS NULL))
);

-- Tạo bảng thông báo
CREATE TABLE ThongBao (
    MaThongBao INT PRIMARY KEY IDENTITY,
    TieuDe NVARCHAR(100),
    NoiDung NVARCHAR(MAX),
    NgayGui DATETIME,
    MaTV INT FOREIGN KEY REFERENCES ThanhVien(MaTV),
    DaDoc BIT DEFAULT 0
);

-- Tạo bảng doanh thu
CREATE TABLE DoanhThu (
    MaThu INT PRIMARY KEY IDENTITY,
    MaTV INT NULL,
    MaKVL INT NULL,
    SoTien DECIMAL(18,2),
    NoiDung NVARCHAR(200),
    NgayThu DATETIME,
    FOREIGN KEY (MaTV) REFERENCES ThanhVien(MaTV),
    FOREIGN KEY (MaKVL) REFERENCES KhachVangLai(MaKVL)
);

-- Tạo bảng báo cáo tài chính
CREATE TABLE BaoCaoTaiChinh (
    MaBaoCao INT PRIMARY KEY IDENTITY,
    Thang INT NOT NULL,
    Nam INT NOT NULL,
    TongDoanhThu DECIMAL(18,2) DEFAULT 0,
    NgayLapBaoCao DATETIME DEFAULT GETDATE(),
    NguoiLap INT FOREIGN KEY REFERENCES TaiKhoan(MaTK),
    TrangThai NVARCHAR(20) DEFAULT 'ChuaDuyet',
    GhiChu NVARCHAR(500)
);

-- Tạo bảng gia hạn đăng ký
CREATE TABLE GiaHanDangKy (
    MaGiaHan INT PRIMARY KEY IDENTITY,
    MaDangKy INT NOT NULL,
    NgayKetThucMoi DATE NOT NULL,
    SoBuoiThem INT NULL,
    SoTien DECIMAL(18,2) NOT NULL,
    NgayGiaHan DATETIME NOT NULL DEFAULT GETDATE(),
    MaTKNguoiThu INT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'DaDong',
    GhiChu NVARCHAR(500),
    FOREIGN KEY (MaDangKy) REFERENCES DangKy(MaDangKy),
    FOREIGN KEY (MaTKNguoiThu) REFERENCES TaiKhoan(MaTK)
);

-- Tạo bảng thanh toán
CREATE TABLE ThanhToan (
    MaThanhToan INT PRIMARY KEY IDENTITY,
    LoaiThanhToan NVARCHAR(50) NOT NULL, -- DangKy, GiaHan, DichVu, KhachVangLai
    MaDangKy INT NULL,
    MaGiaHan INT NULL,
    SoTien DECIMAL(18,2) NOT NULL,
    PhuongThucThanhToan NVARCHAR(50) NOT NULL DEFAULT N'TienMat', -- TienMat, ChuyenKhoan, TheNganHang, ViDienTu, QRCode
    NgayThanhToan DATETIME DEFAULT GETDATE(),
    MaTKNguoiThu INT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'ThanhCong', -- ThanhCong, ThatBai, ChoPheChuan, DaHuy
    GhiChu NVARCHAR(500),
    MaGiaoDich NVARCHAR(100),
    DonViThanhToan NVARCHAR(100),
    TaiKhoanThanhToan NVARCHAR(100),
    HoaDonDienTuUrl NVARCHAR(255),
    DaXuatHoaDon BIT DEFAULT 0,
    FOREIGN KEY (MaDangKy) REFERENCES DangKy(MaDangKy),
    FOREIGN KEY (MaGiaHan) REFERENCES GiaHanDangKy(MaGiaHan),
    FOREIGN KEY (MaTKNguoiThu) REFERENCES TaiKhoan(MaTK)
);

-- Tạo bảng dịch vụ
CREATE TABLE DichVu (
    MaDichVu INT PRIMARY KEY IDENTITY,
    TenDichVu NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(500),
    LoaiDichVu NVARCHAR(20) NOT NULL, -- 'GoiTap' hoặc 'LopHoc'
    GiaBatDau DECIMAL(18,2) NOT NULL,
    HinhAnhURL NVARCHAR(255),
    MaGoiTap INT FOREIGN KEY REFERENCES GoiTap(MaGoi),
    MaLopHoc INT FOREIGN KEY REFERENCES LopHoc(MaLop)
);

-- Tạo bảng PT_GoiTap
CREATE TABLE PT_GoiTap (
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(MaPT),
    MaGoiTap INT FOREIGN KEY REFERENCES GoiTap(MaGoi),
    PhanTramHoaHong DECIMAL(5,2) NOT NULL,
    PRIMARY KEY (MaPT, MaGoiTap)
);

-- Tạo bảng PT_LopHoc
CREATE TABLE PT_LopHoc (
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(MaPT),
    MaLopHoc INT FOREIGN KEY REFERENCES LopHoc(MaLop),
    PhanTramHoaHong DECIMAL(5,2) NOT NULL,
    PRIMARY KEY (MaPT, MaLopHoc)
);

-- Tạo bảng phiên dạy
CREATE TABLE PhienDay (
    MaPhien INT PRIMARY KEY IDENTITY,
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(MaPT),
    MaLopHoc INT FOREIGN KEY REFERENCES LopHoc(MaLop),
    MaGoiTap INT FOREIGN KEY REFERENCES GoiTap(MaGoi),
    NgayDay DATETIME NOT NULL,
    SoTienPhatSinh DECIMAL(18,2) NOT NULL,
    TrangThai NVARCHAR(20)
);

-- Tạo bảng bảng lương PT
CREATE TABLE BangLuongPT (
    MaLuong INT PRIMARY KEY IDENTITY,
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(MaPT),
    ThangNam DATE NOT NULL,
    TongDoanhThu DECIMAL(18,2) DEFAULT 0,
    TongHoaHong DECIMAL(18,2) DEFAULT 0,
    LuongCoBan DECIMAL(18,2) NOT NULL,
    TongThanhToan DECIMAL(18,2) DEFAULT 0,
    TrangThai NVARCHAR(20) DEFAULT 'ChuaThanhToan'
);

-- Tạo bảng tin tức
CREATE TABLE TinTuc (
    MaTinTuc INT PRIMARY KEY IDENTITY,
    TieuDe NVARCHAR(200) NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    HinhAnhURL NVARCHAR(255),
    NgayDang DATETIME DEFAULT GETDATE(),
    NguoiDang INT FOREIGN KEY REFERENCES TaiKhoan(MaTK),
    TrangThai NVARCHAR(20) DEFAULT 'HoatDong' -- HoatDong, KhongHoatDong
);

-- Tạo bảng phiên tập
CREATE TABLE PhienTap (
    MaPhien INT PRIMARY KEY IDENTITY,
    MaThanhVien INT NULL,
    MaKhachVangLai INT NULL,
    MaPT INT FOREIGN KEY REFERENCES HuanLuyenVien(MaPT),
    NgayTap DATETIME NOT NULL,
    GhiChu NVARCHAR(500),
    TinhTrang NVARCHAR(50),
    FOREIGN KEY (MaThanhVien) REFERENCES ThanhVien(MaTV),
    FOREIGN KEY (MaKhachVangLai) REFERENCES KhachVangLai(MaKVL),
    -- Đảm bảo hoặc là thành viên hoặc là khách vãng lai
    CHECK ((MaThanhVien IS NULL AND MaKhachVangLai IS NOT NULL) OR (MaThanhVien IS NOT NULL AND MaKhachVangLai IS NULL))
);

