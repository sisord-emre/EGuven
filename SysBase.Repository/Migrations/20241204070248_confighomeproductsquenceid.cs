using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class confighomeproductsquenceid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeProductSequenceId",
                table: "Configs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Configs",
                keyColumn: "Id",
                keyValue: 1,
                column: "HomeProductSequenceId",
                value: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeProductSequenceId",
                table: "Configs");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9691));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9694));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9696));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 14, 10, 58, 469, DateTimeKind.Local).AddTicks(9713));
        }
    }
}
