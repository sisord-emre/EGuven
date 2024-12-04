using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class hometabpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeTabPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTabPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeTabPostLanguageInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTabPostId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTabPostLanguageInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeTabPostLanguageInfos_HomeTabPosts_HomeTabPostId",
                        column: x => x.HomeTabPostId,
                        principalTable: "HomeTabPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeTabPostLanguageInfos_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeTabPostLanguageInfoContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTabPostLanguageInfoId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTabPostLanguageInfoContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeTabPostLanguageInfoContents_HomeTabPostLanguageInfos_HomeTabPostLanguageInfoId",
                        column: x => x.HomeTabPostLanguageInfoId,
                        principalTable: "HomeTabPostLanguageInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 338, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 17, 59, 53, 339, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.CreateIndex(
                name: "IX_HomeTabPostLanguageInfoContents_HomeTabPostLanguageInfoId",
                table: "HomeTabPostLanguageInfoContents",
                column: "HomeTabPostLanguageInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeTabPostLanguageInfos_HomeTabPostId",
                table: "HomeTabPostLanguageInfos",
                column: "HomeTabPostId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeTabPostLanguageInfos_LanguageId",
                table: "HomeTabPostLanguageInfos",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeTabPostLanguageInfoContents");

            migrationBuilder.DropTable(
                name: "HomeTabPostLanguageInfos");

            migrationBuilder.DropTable(
                name: "HomeTabPosts");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9919));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9925));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9951));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 4, 10, 2, 47, 519, DateTimeKind.Local).AddTicks(9988));
        }
    }
}
