using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class corporate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corporates",
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
                    table.PrimaryKey("PK_Corporates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateLanguageInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visionmission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateLanguageInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateLanguageInfos_Corporates_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "Corporates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateLanguageInfos_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 11, 8, 41, 713, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.CreateIndex(
                name: "IX_CorporateLanguageInfos_CorporateId",
                table: "CorporateLanguageInfos",
                column: "CorporateId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateLanguageInfos_LanguageId",
                table: "CorporateLanguageInfos",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateLanguageInfos");

            migrationBuilder.DropTable(
                name: "Corporates");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3451));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3454));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 15, 40, 17, 581, DateTimeKind.Local).AddTicks(3459));
        }
    }
}
