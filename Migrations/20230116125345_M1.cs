using System;
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
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    ParentId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SubType = table.Column<string>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssetTypes_AssetTypes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AssetTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LabelOptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    Alignment = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelOptions", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumberOfColumns = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    LabelOptionsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Labels_LabelOptions_LabelOptionsId",
                        column: x => x.LabelOptionsId,
                        principalTable: "LabelOptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LayoutSections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ColumnRatio = table.Column<string>(type: "TEXT", nullable: false),
                    LayoutConfigId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutSections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LayoutSections_LayoutConfigs_LayoutConfigId",
                        column: x => x.LayoutConfigId,
                        principalTable: "LayoutConfigs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Schemas",
                columns: table => new
                {
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SubType = table.Column<string>(type: "TEXT", nullable: true),
                    TemplateId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersistencyState = table.Column<int>(type: "INTEGER", nullable: false),
                    Properties = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemas", x => x.Type);
                    table.ForeignKey(
                        name: "FK_Schemas_LayoutConfigs_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "LayoutConfigs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseContents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    LayoutSectionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Direction = table.Column<string>(type: "TEXT", nullable: true),
                    Gap = table.Column<int>(type: "INTEGER", nullable: true),
                    LabelId = table.Column<int>(type: "INTEGER", nullable: true),
                    Ref = table.Column<string>(type: "TEXT", nullable: true),
                    LabelOptionsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseContents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BaseContents_BaseContents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BaseContents",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BaseContents_LabelOptions_LabelOptionsId",
                        column: x => x.LabelOptionsId,
                        principalTable: "LabelOptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseContents_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseContents_LayoutSections_LayoutSectionId",
                        column: x => x.LayoutSectionId,
                        principalTable: "LayoutSections",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetTypes_ParentId",
                table: "AssetTypes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseContents_LabelId",
                table: "BaseContents",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseContents_LabelOptionsId",
                table: "BaseContents",
                column: "LabelOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseContents_LayoutSectionId",
                table: "BaseContents",
                column: "LayoutSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseContents_ParentId",
                table: "BaseContents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_LabelOptionsId",
                table: "Labels",
                column: "LabelOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutSections_LayoutConfigId",
                table: "LayoutSections",
                column: "LayoutConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemas_TemplateId",
                table: "Schemas",
                column: "TemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "BaseContents");

            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Schemas");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "LayoutSections");

            migrationBuilder.DropTable(
                name: "LabelOptions");

            migrationBuilder.DropTable(
                name: "LayoutConfigs");
        }
    }
}
