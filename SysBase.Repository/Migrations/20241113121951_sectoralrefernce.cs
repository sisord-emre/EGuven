using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class sectoralrefernce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SectoralReferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectoralReferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectoralReferenceSectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectoralReferenceId = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectoralReferenceSectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectoralReferenceSectors_SectoralReferences_SectoralReferenceId",
                        column: x => x.SectoralReferenceId,
                        principalTable: "SectoralReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectoralReferenceSectors_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectorLanguageInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorLanguageInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorLanguageInfos_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectorLanguageInfos_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4135));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 15, 19, 50, 409, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.CreateIndex(
                name: "IX_SectoralReferenceSectors_SectoralReferenceId",
                table: "SectoralReferenceSectors",
                column: "SectoralReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SectoralReferenceSectors_SectorId",
                table: "SectoralReferenceSectors",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorLanguageInfos_LanguageId",
                table: "SectorLanguageInfos",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorLanguageInfos_SectorId",
                table: "SectorLanguageInfos",
                column: "SectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectoralReferenceSectors");

            migrationBuilder.DropTable(
                name: "SectorLanguageInfos");

            migrationBuilder.DropTable(
                name: "SectoralReferences");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8225));
        }
    }
}
