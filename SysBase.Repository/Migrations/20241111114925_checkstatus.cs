using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class checkstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DocumentStatus",
                table: "CorporateLanguageInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KssStatus",
                table: "CorporateLanguageInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ValuesStatus",
                table: "CorporateLanguageInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VisionmissionStatus",
                table: "CorporateLanguageInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5176));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "CorporateLanguageInfos");

            migrationBuilder.DropColumn(
                name: "KssStatus",
                table: "CorporateLanguageInfos");

            migrationBuilder.DropColumn(
                name: "ValuesStatus",
                table: "CorporateLanguageInfos");

            migrationBuilder.DropColumn(
                name: "VisionmissionStatus",
                table: "CorporateLanguageInfos");

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
        }
    }
}
