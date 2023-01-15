using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KbstAPI.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LayoutConfigs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutConfigs", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSections_LayoutConfigId",
                table: "LayoutSections",
                column: "LayoutConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_LayoutSections_LayoutConfigs_LayoutConfigId",
                table: "LayoutSections",
                column: "LayoutConfigId",
                principalTable: "LayoutConfigs",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LayoutSections_LayoutConfigs_LayoutConfigId",
                table: "LayoutSections");

            migrationBuilder.DropTable(
                name: "LayoutConfigs");

            migrationBuilder.DropIndex(
                name: "IX_LayoutSections_LayoutConfigId",
                table: "LayoutSections");
        }
    }
}
