using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class projeapi1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiBasvuruRequests_ProjectProduct_ProjectProductId1",
                table: "ApiBasvuruRequests");

            migrationBuilder.DropIndex(
                name: "IX_ApiBasvuruRequests_ProjectProductId1",
                table: "ApiBasvuruRequests");

            migrationBuilder.DropColumn(
                name: "ProjectProductId1",
                table: "ApiBasvuruRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectProductId",
                table: "ApiBasvuruRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "ApiBasvuruRequests",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ApiBasvuruRequests_ProjectProductId",
                table: "ApiBasvuruRequests",
                column: "ProjectProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiBasvuruRequests_ProjectProduct_ProjectProductId",
                table: "ApiBasvuruRequests",
                column: "ProjectProductId",
                principalTable: "ProjectProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiBasvuruRequests_ProjectProduct_ProjectProductId",
                table: "ApiBasvuruRequests");

            migrationBuilder.DropIndex(
                name: "IX_ApiBasvuruRequests_ProjectProductId",
                table: "ApiBasvuruRequests");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "ApiBasvuruRequests");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectProductId",
                table: "ApiBasvuruRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProjectProductId1",
                table: "ApiBasvuruRequests",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5134));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 16, 12, 13, 58, 730, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.CreateIndex(
                name: "IX_ApiBasvuruRequests_ProjectProductId1",
                table: "ApiBasvuruRequests",
                column: "ProjectProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiBasvuruRequests_ProjectProduct_ProjectProductId1",
                table: "ApiBasvuruRequests",
                column: "ProjectProductId1",
                principalTable: "ProjectProduct",
                principalColumn: "Id");
        }
    }
}
