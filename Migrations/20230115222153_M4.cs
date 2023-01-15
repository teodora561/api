using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KbstAPI.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LayoutConfigId",
                table: "Schemas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schemas_LayoutConfigId",
                table: "Schemas",
                column: "LayoutConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schemas_LayoutConfigs_LayoutConfigId",
                table: "Schemas",
                column: "LayoutConfigId",
                principalTable: "LayoutConfigs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schemas_LayoutConfigs_LayoutConfigId",
                table: "Schemas");

            migrationBuilder.DropIndex(
                name: "IX_Schemas_LayoutConfigId",
                table: "Schemas");

            migrationBuilder.DropColumn(
                name: "LayoutConfigId",
                table: "Schemas");
        }
    }
}
