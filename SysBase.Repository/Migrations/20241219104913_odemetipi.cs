using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class odemetipi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OdemeTipi",
                table: "ApiBasvuruRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 13, 49, 13, 7, DateTimeKind.Local).AddTicks(6306));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdemeTipi",
                table: "ApiBasvuruRequests");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 19, 12, 39, 52, 606, DateTimeKind.Local).AddTicks(4055));
        }
    }
}
