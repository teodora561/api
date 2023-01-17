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
            migrationBuilder.DropPrimaryKey(
                name: "PK_Schemas",
                table: "Schemas");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Schemas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schemas",
                table: "Schemas",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Schemas",
                table: "Schemas");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Schemas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schemas",
                table: "Schemas",
                column: "Type");
        }
    }
}
