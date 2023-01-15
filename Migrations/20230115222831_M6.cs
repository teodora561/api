using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KbstAPI.Migrations
{
    /// <inheritdoc />
    public partial class M6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schemas_LayoutConfigs_LayoutConfigId",
                table: "Schemas");

            migrationBuilder.RenameColumn(
                name: "LayoutConfigId",
                table: "Schemas",
                newName: "TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_Schemas_LayoutConfigId",
                table: "Schemas",
                newName: "IX_Schemas_TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schemas_LayoutConfigs_TemplateId",
                table: "Schemas",
                column: "TemplateId",
                principalTable: "LayoutConfigs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schemas_LayoutConfigs_TemplateId",
                table: "Schemas");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "Schemas",
                newName: "LayoutConfigId");

            migrationBuilder.RenameIndex(
                name: "IX_Schemas_TemplateId",
                table: "Schemas",
                newName: "IX_Schemas_LayoutConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schemas_LayoutConfigs_LayoutConfigId",
                table: "Schemas",
                column: "LayoutConfigId",
                principalTable: "LayoutConfigs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
