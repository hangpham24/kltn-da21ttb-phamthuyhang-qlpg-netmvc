using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KLTN.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTenLopHocColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenLopHoc",
                table: "LopHoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenLopHoc",
                table: "LopHoc",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
