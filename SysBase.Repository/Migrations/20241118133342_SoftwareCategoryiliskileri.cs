using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SoftwareCategoryiliskileri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoftwareCategoryId",
                table: "Softwares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3256));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 33, 42, 316, DateTimeKind.Local).AddTicks(3266));

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_SoftwareCategoryId",
                table: "Softwares",
                column: "SoftwareCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Softwares_SoftwareCategories_SoftwareCategoryId",
                table: "Softwares",
                column: "SoftwareCategoryId",
                principalTable: "SoftwareCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Softwares_SoftwareCategories_SoftwareCategoryId",
                table: "Softwares");

            migrationBuilder.DropIndex(
                name: "IX_Softwares_SoftwareCategoryId",
                table: "Softwares");

            migrationBuilder.DropColumn(
                name: "SoftwareCategoryId",
                table: "Softwares");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 128, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 128, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 16, 25, 8, 129, DateTimeKind.Local).AddTicks(1935));
        }
    }
}
