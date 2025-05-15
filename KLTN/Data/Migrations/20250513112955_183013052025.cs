using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KLTN.Data.Migrations
{
    /// <inheritdoc />
    public partial class _183013052025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoanhThus_TaiKhoans_TaiKhoanMaTK",
                table: "DoanhThus");

            migrationBuilder.DropColumn(
                name: "MatKhau",
                table: "TaiKhoans");

            migrationBuilder.RenameColumn(
                name: "TaiKhoanMaTK",
                table: "DoanhThus",
                newName: "MaThanhToan");

            migrationBuilder.RenameIndex(
                name: "IX_DoanhThus_TaiKhoanMaTK",
                table: "DoanhThus",
                newName: "IX_DoanhThus_MaThanhToan");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "DoanhThus",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiThu",
                table: "DoanhThus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaNguoiThu",
                table: "DoanhThus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "DoanhThus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThus_MaNguoiThu",
                table: "DoanhThus",
                column: "MaNguoiThu");

            migrationBuilder.AddForeignKey(
                name: "FK_DoanhThus_TaiKhoans_MaNguoiThu",
                table: "DoanhThus",
                column: "MaNguoiThu",
                principalTable: "TaiKhoans",
                principalColumn: "MaTK");

            migrationBuilder.AddForeignKey(
                name: "FK_DoanhThus_ThanhToans_MaThanhToan",
                table: "DoanhThus",
                column: "MaThanhToan",
                principalTable: "ThanhToans",
                principalColumn: "MaThanhToan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoanhThus_TaiKhoans_MaNguoiThu",
                table: "DoanhThus");

            migrationBuilder.DropForeignKey(
                name: "FK_DoanhThus_ThanhToans_MaThanhToan",
                table: "DoanhThus");

            migrationBuilder.DropIndex(
                name: "IX_DoanhThus_MaNguoiThu",
                table: "DoanhThus");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "DoanhThus");

            migrationBuilder.DropColumn(
                name: "LoaiThu",
                table: "DoanhThus");

            migrationBuilder.DropColumn(
                name: "MaNguoiThu",
                table: "DoanhThus");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "DoanhThus");

            migrationBuilder.RenameColumn(
                name: "MaThanhToan",
                table: "DoanhThus",
                newName: "TaiKhoanMaTK");

            migrationBuilder.RenameIndex(
                name: "IX_DoanhThus_MaThanhToan",
                table: "DoanhThus",
                newName: "IX_DoanhThus_TaiKhoanMaTK");

            migrationBuilder.AddColumn<string>(
                name: "MatKhau",
                table: "TaiKhoans",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DoanhThus_TaiKhoans_TaiKhoanMaTK",
                table: "DoanhThus",
                column: "TaiKhoanMaTK",
                principalTable: "TaiKhoans",
                principalColumn: "MaTK");
        }
    }
}
