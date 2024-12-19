using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class odemebilgi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OdemeCevap",
                table: "ApiBasvuruRequests",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdemeCevap",
                table: "ApiBasvuruRequests");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8027));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 15, 59, 6, 753, DateTimeKind.Local).AddTicks(8066));
        }
    }
}
