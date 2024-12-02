using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class yardımcıvideoanasayfa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HomeVisibility",
                table: "HelperVideos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MasterVideo",
                table: "HelperVideos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6942));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 10, 29, 30, 891, DateTimeKind.Local).AddTicks(6999));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeVisibility",
                table: "HelperVideos");

            migrationBuilder.DropColumn(
                name: "MasterVideo",
                table: "HelperVideos");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 9, 32, 30, 506, DateTimeKind.Local).AddTicks(5098));
        }
    }
}
