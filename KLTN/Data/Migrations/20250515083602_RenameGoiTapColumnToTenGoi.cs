using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KLTN.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameGoiTapColumnToTenGoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenGoiTap",
                table: "GoiTap");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenGoiTap",
                table: "GoiTap",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
