using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KbstAPI.Migrations
{
    /// <inheritdoc />
    public partial class M10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "BaseContents",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Spacer",
                table: "BaseContents",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SplitRatio",
                table: "BaseContents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "BaseContents");

            migrationBuilder.DropColumn(
                name: "Spacer",
                table: "BaseContents");

            migrationBuilder.DropColumn(
                name: "SplitRatio",
                table: "BaseContents");
        }
    }
}
