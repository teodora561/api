using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KbstAPI.Migrations
{
    /// <inheritdoc />
    public partial class M11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Alignment",
                table: "BaseContents",
                newName: "LabelAlignment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LabelAlignment",
                table: "BaseContents",
                newName: "Alignment");
        }
    }
}
