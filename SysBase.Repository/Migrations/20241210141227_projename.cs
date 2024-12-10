using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class projename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AddressRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CityHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CityRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CountyHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CountyRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateBirthHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateBirthRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmailHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmailRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FaxHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FaxRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GsmHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GsmRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IdentityCardSerialNumberHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IdentityCardSerialNumberRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NameHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NameRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NationalityHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NationalityRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PhoneHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PhoneRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PlaceBirthHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PlaceBirthRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PostcodeHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PostcodeRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SafetyWordHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SafetyWordRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SurnameHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SurnameRequiredField",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TcknHideShow",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TcknRequiredField",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 244, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 244, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 17, 12, 27, 245, DateTimeKind.Local).AddTicks(2022));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddressHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddressRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CityHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CityRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CountyHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CountyRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DateBirthHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DateBirthRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmailHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmailRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FaxHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FaxRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GsmHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GsmRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IdentityCardSerialNumberHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IdentityCardSerialNumberRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NameHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NameRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NationalityHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NationalityRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PlaceBirthHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PlaceBirthRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PostcodeHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PostcodeRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SafetyWordHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SafetyWordRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SurnameHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SurnameRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TcknHideShow",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TcknRequiredField",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 10, 13, 38, 25, 228, DateTimeKind.Local).AddTicks(9182));
        }
    }
}
