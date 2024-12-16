using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class projeapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dosya",
                table: "ApiBasvuruRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectProductId",
                table: "ApiBasvuruRequests",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiBasvuruRequests_ProjectProduct_ProjectProductId1",
                table: "ApiBasvuruRequests");

            migrationBuilder.DropIndex(
                name: "IX_ApiBasvuruRequests_ProjectProductId1",
                table: "ApiBasvuruRequests");

            migrationBuilder.DropColumn(
                name: "Dosya",
                table: "ApiBasvuruRequests");

            migrationBuilder.DropColumn(
                name: "ProjectProductId",
                table: "ApiBasvuruRequests");

            migrationBuilder.DropColumn(
                name: "ProjectProductId1",
                table: "ApiBasvuruRequests");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 12, 16, 22, 1, 593, DateTimeKind.Local).AddTicks(9101));
        }
    }
}
