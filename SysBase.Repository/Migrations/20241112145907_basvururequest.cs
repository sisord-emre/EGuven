using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysBase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class basvururequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiBasvuruRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kanal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: true),
                    KayitID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiparisAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sirket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VergiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCKimlikNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DogumYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uyruk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlkKullanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SonKullanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeslimatAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Il = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulumAdresiDetay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulumAdresiIl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulumAdresiIlce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulumAdresiPostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulumAdresiTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulumAdresiCepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulumAdresiFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaAdresiDetay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaAdresiIl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaAdresiIlce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaAdresiPostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaAdresiTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaAdresiCepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaAdresiFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAdresiSertifikadaGorulsun = table.Column<bool>(type: "bit", nullable: false),
                    ProjeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeSekli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeMiktari = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KurulumVarMi = table.Column<bool>(type: "bit", nullable: false),
                    FirmaUnvani = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yil = table.Column<int>(type: "int", nullable: true),
                    Avukat = table.Column<bool>(type: "bit", nullable: false),
                    Izin = table.Column<bool>(type: "bit", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KimlikDogrulandi = table.Column<bool>(type: "bit", nullable: false),
                    PasaportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Istest = table.Column<bool>(type: "bit", nullable: false),
                    GuvenlikSozcugu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnayTik = table.Column<bool>(type: "bit", nullable: false),
                    KVKonayTik = table.Column<bool>(type: "bit", nullable: false),
                    TCSeriNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GizliSoru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NVIDogrulama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PdfErisimToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEdevlet = table.Column<bool>(type: "bit", nullable: false),
                    EmuhurKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmuhurTC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmuhurVergiIl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmuhurVergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmuhurVergiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IkinciKisiTC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KepAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IkinciKisiAdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiBasvuruRequests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8173));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 17, 59, 6, 998, DateTimeKind.Local).AddTicks(8225));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiBasvuruRequests");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 14, 49, 24, 588, DateTimeKind.Local).AddTicks(5176));
        }
    }
}
