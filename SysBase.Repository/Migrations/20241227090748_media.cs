using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class media : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 12, 7, 47, 753, DateTimeKind.Local).AddTicks(6286));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 27, 10, 15, 27, 277, DateTimeKind.Local).AddTicks(4228));
        }
    }
}
