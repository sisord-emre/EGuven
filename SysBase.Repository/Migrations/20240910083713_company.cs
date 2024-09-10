using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateSalesRepresentative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationRepresentative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameHideShow = table.Column<bool>(type: "bit", nullable: false),
                    NameRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurnameHideShow = table.Column<bool>(type: "bit", nullable: false),
                    SurnameRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    DateBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirthHideShow = table.Column<bool>(type: "bit", nullable: false),
                    DateBirthRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityHideShow = table.Column<bool>(type: "bit", nullable: false),
                    NationalityRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Tckn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TcknHideShow = table.Column<bool>(type: "bit", nullable: false),
                    TcknRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailHideShow = table.Column<bool>(type: "bit", nullable: false),
                    EmailRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    PlaceBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceBirthHideShow = table.Column<bool>(type: "bit", nullable: false),
                    PlaceBirthRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    IdentityCardSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityCardSerialNumberHideShow = table.Column<bool>(type: "bit", nullable: false),
                    IdentityCardSerialNumberRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    SafetyWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafetyWordHideShow = table.Column<bool>(type: "bit", nullable: false),
                    SafetyWordRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityHideShow = table.Column<bool>(type: "bit", nullable: false),
                    CityRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountyHideShow = table.Column<bool>(type: "bit", nullable: false),
                    CountyRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostcodeHideShow = table.Column<bool>(type: "bit", nullable: false),
                    PostcodeRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressHideShow = table.Column<bool>(type: "bit", nullable: false),
                    AddressRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneHideShow = table.Column<bool>(type: "bit", nullable: false),
                    PhoneRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxHideShow = table.Column<bool>(type: "bit", nullable: false),
                    FaxRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Gsm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GsmHideShow = table.Column<bool>(type: "bit", nullable: false),
                    GsmRequiredField = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 228, DateTimeKind.Local).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 228, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(728));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(896));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 10, 11, 37, 13, 229, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 556, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 556, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3203));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3238));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3241));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 9, 16, 7, 31, 557, DateTimeKind.Local).AddTicks(3255));
        }
    }
}
