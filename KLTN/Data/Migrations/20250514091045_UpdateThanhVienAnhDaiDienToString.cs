using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KLTN.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThanhVienAnhDaiDienToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaiKhoans_Email",
                table: "TaiKhoans");

            migrationBuilder.DropColumn(
                name: "NgayDangKy",
                table: "ThanhViens");

            migrationBuilder.DropColumn(
                name: "NgayDangKyTV",
                table: "ThanhViens");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ThanhViens");

            migrationBuilder.DropColumn(
                name: "TrangThaiTV",
                table: "ThanhViens");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TaiKhoans");

            migrationBuilder.DropColumn(
                name: "SoDienThoai",
                table: "TaiKhoans");

            migrationBuilder.DropColumn(
                name: "VaiTro",
                table: "TaiKhoans");

            migrationBuilder.AlterColumn<string>(
                name: "AnhDaiDien",
                table: "ThanhViens",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnhDaiDien",
                table: "HuanLuyenViens",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhDaiDien",
                table: "HuanLuyenViens");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AnhDaiDien",
                table: "ThanhViens",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDangKy",
                table: "ThanhViens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDangKyTV",
                table: "ThanhViens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ThanhViens",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThaiTV",
                table: "ThanhViens",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TaiKhoans",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoDienThoai",
                table: "TaiKhoans",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VaiTro",
                table: "TaiKhoans",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_Email",
                table: "TaiKhoans",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
