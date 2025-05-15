using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KLTN.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "KhachVangLais",
                columns: table => new
                {
                    MaKVL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayGhiNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachVangLais", x => x.MaKVL);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    MaKM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhanTramGiam = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GiaTriToiThieu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GiamToiDa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLuongMaToiDa = table.Column<int>(type: "int", nullable: true),
                    SoLuongDaSuDung = table.Column<int>(type: "int", nullable: true),
                    DoiTuongApDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.MaKM);
                });

            migrationBuilder.CreateTable(
                name: "Quyens",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyens", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "GoiTap",
                columns: table => new
                {
                    MaGoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGoi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenGoiTap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ThoiHanThang = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLanTapToiDa = table.Column<int>(type: "int", nullable: true),
                    MaKM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoiTap", x => x.MaGoi);
                    table.ForeignKey(
                        name: "FK_GoiTap_KhuyenMais_MaKM",
                        column: x => x.MaKM,
                        principalTable: "KhuyenMais",
                        principalColumn: "MaKM");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    MaTK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MatKhauHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MaQuyen = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LanDangNhapCuoi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.MaTK);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_Quyens_MaQuyen",
                        column: x => x.MaQuyen,
                        principalTable: "Quyens",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaoCaoTaiChinhs",
                columns: table => new
                {
                    MaBaoCao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    TongDoanhThu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayLapBaoCao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiLap = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoTaiChinhs", x => x.MaBaoCao);
                    table.ForeignKey(
                        name: "FK_BaoCaoTaiChinhs_TaiKhoans_NguoiLap",
                        column: x => x.NguoiLap,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK");
                });

            migrationBuilder.CreateTable(
                name: "HuanLuyenViens",
                columns: table => new
                {
                    MaPT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTK = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChuyenMon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KinhNghiem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TrangThaiHLV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuanLuyenViens", x => x.MaPT);
                    table.ForeignKey(
                        name: "FK_HuanLuyenViens_TaiKhoans_MaTK",
                        column: x => x.MaTK,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhViens",
                columns: table => new
                {
                    MaTV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayDangKyTV = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnhDaiDien = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MaTK = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TrangThaiTV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhViens", x => x.MaTV);
                    table.ForeignKey(
                        name: "FK_ThanhViens_TaiKhoans_MaTK",
                        column: x => x.MaTK,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK");
                });

            migrationBuilder.CreateTable(
                name: "TinTucs",
                columns: table => new
                {
                    MaTinTuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoTaNgan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnhURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DanhMuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TacGiaDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NguoiDang = table.Column<int>(type: "int", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianDoc = table.Column<int>(type: "int", nullable: true),
                    LuotXem = table.Column<int>(type: "int", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: false),
                    NoiBat = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTucs", x => x.MaTinTuc);
                    table.ForeignKey(
                        name: "FK_TinTucs_TaiKhoans_NguoiDang",
                        column: x => x.NguoiDang,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK");
                });

            migrationBuilder.CreateTable(
                name: "BangLuongPTs",
                columns: table => new
                {
                    MaLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPT = table.Column<int>(type: "int", nullable: false),
                    ThangNam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongDoanhThu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongHoaHong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongThanhToan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangLuongPTs", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK_BangLuongPTs_HuanLuyenViens_MaPT",
                        column: x => x.MaPT,
                        principalTable: "HuanLuyenViens",
                        principalColumn: "MaPT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenLopHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaPT = table.Column<int>(type: "int", nullable: true),
                    ThoiGianBatDau = table.Column<TimeSpan>(type: "time", nullable: false),
                    ThoiGianKetThuc = table.Column<TimeSpan>(type: "time", nullable: false),
                    NgayTrongTuan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoLuongToiDa = table.Column<int>(type: "int", nullable: false),
                    SoLuongHienTai = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                    table.ForeignKey(
                        name: "FK_LopHoc_HuanLuyenViens_MaPT",
                        column: x => x.MaPT,
                        principalTable: "HuanLuyenViens",
                        principalColumn: "MaPT");
                });

            migrationBuilder.CreateTable(
                name: "PT_GoiTap",
                columns: table => new
                {
                    MaPT_GoiTap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPT = table.Column<int>(type: "int", nullable: false),
                    MaGoiTap = table.Column<int>(type: "int", nullable: false),
                    PhanTramHoaHong = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_GoiTap", x => x.MaPT_GoiTap);
                    table.ForeignKey(
                        name: "FK_PT_GoiTap_GoiTap_MaGoiTap",
                        column: x => x.MaGoiTap,
                        principalTable: "GoiTap",
                        principalColumn: "MaGoi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PT_GoiTap_HuanLuyenViens_MaPT",
                        column: x => x.MaPT,
                        principalTable: "HuanLuyenViens",
                        principalColumn: "MaPT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoanhThus",
                columns: table => new
                {
                    MaThu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTV = table.Column<int>(type: "int", nullable: true),
                    MaKVL = table.Column<int>(type: "int", nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgayThu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaiKhoanMaTK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhThus", x => x.MaThu);
                    table.ForeignKey(
                        name: "FK_DoanhThus_KhachVangLais_MaKVL",
                        column: x => x.MaKVL,
                        principalTable: "KhachVangLais",
                        principalColumn: "MaKVL");
                    table.ForeignKey(
                        name: "FK_DoanhThus_TaiKhoans_TaiKhoanMaTK",
                        column: x => x.TaiKhoanMaTK,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK");
                    table.ForeignKey(
                        name: "FK_DoanhThus_ThanhViens_MaTV",
                        column: x => x.MaTV,
                        principalTable: "ThanhViens",
                        principalColumn: "MaTV");
                });

            migrationBuilder.CreateTable(
                name: "LichSuCheckIns",
                columns: table => new
                {
                    MaCheckIn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTV = table.Column<int>(type: "int", nullable: true),
                    MaKVL = table.Column<int>(type: "int", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KetQuaNhanDien = table.Column<bool>(type: "bit", nullable: false),
                    AnhNhanDien = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuCheckIns", x => x.MaCheckIn);
                    table.ForeignKey(
                        name: "FK_LichSuCheckIns_KhachVangLais_MaKVL",
                        column: x => x.MaKVL,
                        principalTable: "KhachVangLais",
                        principalColumn: "MaKVL");
                    table.ForeignKey(
                        name: "FK_LichSuCheckIns_ThanhViens_MaTV",
                        column: x => x.MaTV,
                        principalTable: "ThanhViens",
                        principalColumn: "MaTV");
                });

            migrationBuilder.CreateTable(
                name: "LichSuDangKy",
                columns: table => new
                {
                    MaLichSu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTV = table.Column<int>(type: "int", nullable: false),
                    MaGoi = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuDangKy", x => x.MaLichSu);
                    table.ForeignKey(
                        name: "FK_LichSuDangKy_GoiTap_MaGoi",
                        column: x => x.MaGoi,
                        principalTable: "GoiTap",
                        principalColumn: "MaGoi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSuDangKy_ThanhViens_MaTV",
                        column: x => x.MaTV,
                        principalTable: "ThanhViens",
                        principalColumn: "MaTV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhienTap",
                columns: table => new
                {
                    MaPhien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaThanhVien = table.Column<int>(type: "int", nullable: true),
                    MaKhachVangLai = table.Column<int>(type: "int", nullable: true),
                    MaPT = table.Column<int>(type: "int", nullable: true),
                    NgayTap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhienTap", x => x.MaPhien);
                    table.ForeignKey(
                        name: "FK_PhienTap_HuanLuyenViens_MaPT",
                        column: x => x.MaPT,
                        principalTable: "HuanLuyenViens",
                        principalColumn: "MaPT");
                    table.ForeignKey(
                        name: "FK_PhienTap_KhachVangLais_MaKhachVangLai",
                        column: x => x.MaKhachVangLai,
                        principalTable: "KhachVangLais",
                        principalColumn: "MaKVL");
                    table.ForeignKey(
                        name: "FK_PhienTap_ThanhViens_MaThanhVien",
                        column: x => x.MaThanhVien,
                        principalTable: "ThanhViens",
                        principalColumn: "MaTV");
                });

            migrationBuilder.CreateTable(
                name: "ThongBaos",
                columns: table => new
                {
                    MaThongBao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaTV = table.Column<int>(type: "int", nullable: false),
                    DaDoc = table.Column<bool>(type: "bit", nullable: false),
                    TaiKhoanMaTK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBaos", x => x.MaThongBao);
                    table.ForeignKey(
                        name: "FK_ThongBaos_TaiKhoans_TaiKhoanMaTK",
                        column: x => x.TaiKhoanMaTK,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK");
                    table.ForeignKey(
                        name: "FK_ThongBaos_ThanhViens_MaTV",
                        column: x => x.MaTV,
                        principalTable: "ThanhViens",
                        principalColumn: "MaTV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKys",
                columns: table => new
                {
                    MaDangKy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTV = table.Column<int>(type: "int", nullable: false),
                    MaKhachVangLai = table.Column<int>(type: "int", nullable: true),
                    MaGoiTap = table.Column<int>(type: "int", nullable: true),
                    MaLopHoc = table.Column<int>(type: "int", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiDangKy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoBuoi = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKys", x => x.MaDangKy);
                    table.ForeignKey(
                        name: "FK_DangKys_GoiTap_MaGoiTap",
                        column: x => x.MaGoiTap,
                        principalTable: "GoiTap",
                        principalColumn: "MaGoi");
                    table.ForeignKey(
                        name: "FK_DangKys_KhachVangLais_MaKhachVangLai",
                        column: x => x.MaKhachVangLai,
                        principalTable: "KhachVangLais",
                        principalColumn: "MaKVL");
                    table.ForeignKey(
                        name: "FK_DangKys_LopHoc_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop");
                    table.ForeignKey(
                        name: "FK_DangKys_ThanhViens_MaTV",
                        column: x => x.MaTV,
                        principalTable: "ThanhViens",
                        principalColumn: "MaTV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DichVus",
                columns: table => new
                {
                    MaDichVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LoaiDichVu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GiaBatDau = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HinhAnhURL = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaGoiTap = table.Column<int>(type: "int", nullable: true),
                    MaLopHoc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVus", x => x.MaDichVu);
                    table.ForeignKey(
                        name: "FK_DichVus_GoiTap_MaGoiTap",
                        column: x => x.MaGoiTap,
                        principalTable: "GoiTap",
                        principalColumn: "MaGoi");
                    table.ForeignKey(
                        name: "FK_DichVus_LopHoc_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop");
                });

            migrationBuilder.CreateTable(
                name: "PhienDays",
                columns: table => new
                {
                    MaPhienDay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPT = table.Column<int>(type: "int", nullable: false),
                    MaLopHoc = table.Column<int>(type: "int", nullable: true),
                    MaGoiTap = table.Column<int>(type: "int", nullable: true),
                    NgayDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiaTriBuoiDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoaiPhienDay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoaiDichVu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaBangLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhienDays", x => x.MaPhienDay);
                    table.ForeignKey(
                        name: "FK_PhienDays_BangLuongPTs_MaBangLuong",
                        column: x => x.MaBangLuong,
                        principalTable: "BangLuongPTs",
                        principalColumn: "MaLuong");
                    table.ForeignKey(
                        name: "FK_PhienDays_GoiTap_MaGoiTap",
                        column: x => x.MaGoiTap,
                        principalTable: "GoiTap",
                        principalColumn: "MaGoi");
                    table.ForeignKey(
                        name: "FK_PhienDays_HuanLuyenViens_MaPT",
                        column: x => x.MaPT,
                        principalTable: "HuanLuyenViens",
                        principalColumn: "MaPT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhienDays_LopHoc_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop");
                });

            migrationBuilder.CreateTable(
                name: "PT_LopHoc",
                columns: table => new
                {
                    MaPT_LopHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPT = table.Column<int>(type: "int", nullable: false),
                    MaLopHoc = table.Column<int>(type: "int", nullable: false),
                    PhanTramHoaHong = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_LopHoc", x => x.MaPT_LopHoc);
                    table.ForeignKey(
                        name: "FK_PT_LopHoc_HuanLuyenViens_MaPT",
                        column: x => x.MaPT,
                        principalTable: "HuanLuyenViens",
                        principalColumn: "MaPT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PT_LopHoc_LopHoc_MaLopHoc",
                        column: x => x.MaLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaHanDangKys",
                columns: table => new
                {
                    MaGiaHan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDangKy = table.Column<int>(type: "int", nullable: false),
                    NgayKetThucMoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoBuoiThem = table.Column<int>(type: "int", nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayGiaHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaTKNguoiThu = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaiKhoanMaTK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaHanDangKys", x => x.MaGiaHan);
                    table.ForeignKey(
                        name: "FK_GiaHanDangKys_DangKys_MaDangKy",
                        column: x => x.MaDangKy,
                        principalTable: "DangKys",
                        principalColumn: "MaDangKy",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiaHanDangKys_TaiKhoans_MaTKNguoiThu",
                        column: x => x.MaTKNguoiThu,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK");
                    table.ForeignKey(
                        name: "FK_GiaHanDangKys_TaiKhoans_TaiKhoanMaTK",
                        column: x => x.TaiKhoanMaTK,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK");
                });

            migrationBuilder.CreateTable(
                name: "ThanhToans",
                columns: table => new
                {
                    MaThanhToan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaDangKy = table.Column<int>(type: "int", nullable: true),
                    MaGiaHan = table.Column<int>(type: "int", nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaTKNguoiThu = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaGiaoDich = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DonViThanhToan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaiKhoanThanhToan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HoaDonDienTuUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DaXuatHoaDon = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToans", x => x.MaThanhToan);
                    table.ForeignKey(
                        name: "FK_ThanhToans_DangKys_MaDangKy",
                        column: x => x.MaDangKy,
                        principalTable: "DangKys",
                        principalColumn: "MaDangKy");
                    table.ForeignKey(
                        name: "FK_ThanhToans_GiaHanDangKys_MaGiaHan",
                        column: x => x.MaGiaHan,
                        principalTable: "GiaHanDangKys",
                        principalColumn: "MaGiaHan");
                    table.ForeignKey(
                        name: "FK_ThanhToans_TaiKhoans_MaTKNguoiThu",
                        column: x => x.MaTKNguoiThu,
                        principalTable: "TaiKhoans",
                        principalColumn: "MaTK");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BangLuongPTs_MaPT",
                table: "BangLuongPTs",
                column: "MaPT");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTaiChinhs_NguoiLap",
                table: "BaoCaoTaiChinhs",
                column: "NguoiLap");

            migrationBuilder.CreateIndex(
                name: "IX_DangKys_MaGoiTap",
                table: "DangKys",
                column: "MaGoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_DangKys_MaKhachVangLai",
                table: "DangKys",
                column: "MaKhachVangLai");

            migrationBuilder.CreateIndex(
                name: "IX_DangKys_MaLopHoc",
                table: "DangKys",
                column: "MaLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_DangKys_MaTV",
                table: "DangKys",
                column: "MaTV");

            migrationBuilder.CreateIndex(
                name: "IX_DichVus_MaGoiTap",
                table: "DichVus",
                column: "MaGoiTap",
                unique: true,
                filter: "[MaGoiTap] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DichVus_MaLopHoc",
                table: "DichVus",
                column: "MaLopHoc",
                unique: true,
                filter: "[MaLopHoc] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThus_MaKVL",
                table: "DoanhThus",
                column: "MaKVL");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThus_MaTV",
                table: "DoanhThus",
                column: "MaTV");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThus_TaiKhoanMaTK",
                table: "DoanhThus",
                column: "TaiKhoanMaTK");

            migrationBuilder.CreateIndex(
                name: "IX_GiaHanDangKys_MaDangKy",
                table: "GiaHanDangKys",
                column: "MaDangKy");

            migrationBuilder.CreateIndex(
                name: "IX_GiaHanDangKys_MaTKNguoiThu",
                table: "GiaHanDangKys",
                column: "MaTKNguoiThu");

            migrationBuilder.CreateIndex(
                name: "IX_GiaHanDangKys_TaiKhoanMaTK",
                table: "GiaHanDangKys",
                column: "TaiKhoanMaTK");

            migrationBuilder.CreateIndex(
                name: "IX_GoiTap_MaKM",
                table: "GoiTap",
                column: "MaKM");

            migrationBuilder.CreateIndex(
                name: "IX_HuanLuyenViens_MaTK",
                table: "HuanLuyenViens",
                column: "MaTK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichSuCheckIns_MaKVL",
                table: "LichSuCheckIns",
                column: "MaKVL");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuCheckIns_MaTV",
                table: "LichSuCheckIns",
                column: "MaTV");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDangKy_MaGoi",
                table: "LichSuDangKy",
                column: "MaGoi");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDangKy_MaTV",
                table: "LichSuDangKy",
                column: "MaTV");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaPT",
                table: "LopHoc",
                column: "MaPT");

            migrationBuilder.CreateIndex(
                name: "IX_PhienDays_MaBangLuong",
                table: "PhienDays",
                column: "MaBangLuong");

            migrationBuilder.CreateIndex(
                name: "IX_PhienDays_MaGoiTap",
                table: "PhienDays",
                column: "MaGoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_PhienDays_MaLopHoc",
                table: "PhienDays",
                column: "MaLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_PhienDays_MaPT",
                table: "PhienDays",
                column: "MaPT");

            migrationBuilder.CreateIndex(
                name: "IX_PhienTap_MaKhachVangLai",
                table: "PhienTap",
                column: "MaKhachVangLai");

            migrationBuilder.CreateIndex(
                name: "IX_PhienTap_MaPT",
                table: "PhienTap",
                column: "MaPT");

            migrationBuilder.CreateIndex(
                name: "IX_PhienTap_MaThanhVien",
                table: "PhienTap",
                column: "MaThanhVien");

            migrationBuilder.CreateIndex(
                name: "IX_PT_GoiTap_MaGoiTap",
                table: "PT_GoiTap",
                column: "MaGoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_PT_GoiTap_MaPT",
                table: "PT_GoiTap",
                column: "MaPT");

            migrationBuilder.CreateIndex(
                name: "IX_PT_LopHoc_MaLopHoc",
                table: "PT_LopHoc",
                column: "MaLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_PT_LopHoc_MaPT",
                table: "PT_LopHoc",
                column: "MaPT");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_Email",
                table: "TaiKhoans",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_MaQuyen",
                table: "TaiKhoans",
                column: "MaQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_TenDangNhap",
                table: "TaiKhoans",
                column: "TenDangNhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaDangKy",
                table: "ThanhToans",
                column: "MaDangKy");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaGiaHan",
                table: "ThanhToans",
                column: "MaGiaHan");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaTKNguoiThu",
                table: "ThanhToans",
                column: "MaTKNguoiThu");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhViens_MaTK",
                table: "ThanhViens",
                column: "MaTK",
                unique: true,
                filter: "[MaTK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_MaTV",
                table: "ThongBaos",
                column: "MaTV");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBaos_TaiKhoanMaTK",
                table: "ThongBaos",
                column: "TaiKhoanMaTK");

            migrationBuilder.CreateIndex(
                name: "IX_TinTucs_NguoiDang",
                table: "TinTucs",
                column: "NguoiDang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCaoTaiChinhs");

            migrationBuilder.DropTable(
                name: "DichVus");

            migrationBuilder.DropTable(
                name: "DoanhThus");

            migrationBuilder.DropTable(
                name: "LichSuCheckIns");

            migrationBuilder.DropTable(
                name: "LichSuDangKy");

            migrationBuilder.DropTable(
                name: "PhienDays");

            migrationBuilder.DropTable(
                name: "PhienTap");

            migrationBuilder.DropTable(
                name: "PT_GoiTap");

            migrationBuilder.DropTable(
                name: "PT_LopHoc");

            migrationBuilder.DropTable(
                name: "ThanhToans");

            migrationBuilder.DropTable(
                name: "ThongBaos");

            migrationBuilder.DropTable(
                name: "TinTucs");

            migrationBuilder.DropTable(
                name: "BangLuongPTs");

            migrationBuilder.DropTable(
                name: "GiaHanDangKys");

            migrationBuilder.DropTable(
                name: "DangKys");

            migrationBuilder.DropTable(
                name: "GoiTap");

            migrationBuilder.DropTable(
                name: "KhachVangLais");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "ThanhViens");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "HuanLuyenViens");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "Quyens");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
