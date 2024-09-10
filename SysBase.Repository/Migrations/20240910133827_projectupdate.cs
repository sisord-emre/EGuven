using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class projectupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateBirth",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Gsm",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IdentityCardSerialNumber",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PlaceBirth",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SafetyWord",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Tckn",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 235, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 235, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 16, 38, 27, 236, DateTimeKind.Local).AddTicks(1455));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateBirth",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gsm",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityCardSerialNumber",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceBirth",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SafetyWord",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tckn",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 787, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 787, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3618));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 14, 34, 20, 788, DateTimeKind.Local).AddTicks(3635));
        }
    }
}
