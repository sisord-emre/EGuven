using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class softwarecategoeylanguageinfocontent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentImage",
                table: "SoftwareCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ScreenShow",
                table: "SoftwareCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SoftwareCategoryLanguageInfoContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareCategoryLanguageInfoId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareCategoryLanguageInfoContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareCategoryLanguageInfoContents_SoftwareCategoryLanguageInfos_SoftwareCategoryLanguageInfoId",
                        column: x => x.SoftwareCategoryLanguageInfoId,
                        principalTable: "SoftwareCategoryLanguageInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9872));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 12, 4, 10, 959, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareCategoryLanguageInfoContents_SoftwareCategoryLanguageInfoId",
                table: "SoftwareCategoryLanguageInfoContents",
                column: "SoftwareCategoryLanguageInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoftwareCategoryLanguageInfoContents");

            migrationBuilder.DropColumn(
                name: "ContentImage",
                table: "SoftwareCategories");

            migrationBuilder.DropColumn(
                name: "ScreenShow",
                table: "SoftwareCategories");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 15, 59, 41, 535, DateTimeKind.Local).AddTicks(5692));
        }
    }
}
