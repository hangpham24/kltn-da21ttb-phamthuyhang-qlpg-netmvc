using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KLTN.Data.Migrations
{
    /// <inheritdoc />
    public partial class capnhatkvl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "KhachVangLais");

            migrationBuilder.AddColumn<decimal>(
                name: "GiaTien",
                table: "KhachVangLais",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaTien",
                table: "KhachVangLais");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "KhachVangLais",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
