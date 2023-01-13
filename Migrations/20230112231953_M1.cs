using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KbstAPI.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_AssetTypes_ParentId",
                table: "AssetTypes");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "AssetTypes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_AssetTypes_ParentId",
                table: "AssetTypes",
                column: "ParentId",
                principalTable: "AssetTypes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_AssetTypes_ParentId",
                table: "AssetTypes");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "AssetTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_AssetTypes_ParentId",
                table: "AssetTypes",
                column: "ParentId",
                principalTable: "AssetTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
