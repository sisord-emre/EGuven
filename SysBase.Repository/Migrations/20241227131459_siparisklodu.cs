using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class siparisklodu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiparisKodu",
                table: "Configs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SiparisKodu",
                table: "ApiBasvuruRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Configs",
                keyColumn: "Id",
                keyValue: 1,
                column: "SiparisKodu",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 223, DateTimeKind.Local).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 223, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 16, 14, 59, 224, DateTimeKind.Local).AddTicks(3811));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiparisKodu",
                table: "Configs");

            migrationBuilder.DropColumn(
                name: "SiparisKodu",
                table: "ApiBasvuruRequests");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 167, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 167, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 14, 19, 35, 168, DateTimeKind.Local).AddTicks(3163));
        }
    }
}
