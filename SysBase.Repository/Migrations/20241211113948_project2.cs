using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class project2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CompanyInvoices_CompanyInvoiceId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyInvoiceId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8475));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 14, 39, 47, 501, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_CompanyInvoices_CompanyInvoiceId",
                table: "Projects",
                column: "CompanyInvoiceId",
                principalTable: "CompanyInvoices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CompanyInvoices_CompanyInvoiceId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyInvoiceId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(949));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(951));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3618));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3643));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 11, 11, 16, 36, 437, DateTimeKind.Local).AddTicks(3663));

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_CompanyInvoices_CompanyInvoiceId",
                table: "Projects",
                column: "CompanyInvoiceId",
                principalTable: "CompanyInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
