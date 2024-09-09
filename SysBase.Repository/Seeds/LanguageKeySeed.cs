using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Repository.Seeds
{
    internal class LanguageKeySeed : IEntityTypeConfiguration<LanguageKey>
    {
        public void Configure(EntityTypeBuilder<LanguageKey> builder)
        {
            builder.HasData(
                new LanguageKey
                {
                    Id = 17,
                    Code = "admin.Dark",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 18,
                    Code = "admin.Light",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 19,
                    Code = "admin.Default",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 20,
                    Code = "admin.Bildirimler",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 21,
                    Code = "admin.Tümü Okundu",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 22,
                    Code = "admin.Profil",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 23,
                    Code = "admin.Ayarlar",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 24,
                    Code = "admin.Profil Güncelle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 25,
                    Code = "admin.Şifre Değiştir",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 27,
                    Code = "admin.Çıkış",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 28,
                    Code = "admin.Copyright",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 29,
                    Code = "admin.Kayıt Başarılı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 30,
                    Code = "admin.Kayıt Hatası",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 31,
                    Code = "admin.Yeni Ekle Düzenle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 32,
                    Code = "admin.Site Url",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 33,
                    Code = "admin.Site Name",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 34,
                    Code = "admin.Title",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 35,
                    Code = "admin.Phone",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 36,
                    Code = "admin.Address",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 37,
                    Code = "admin.Mail",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 38,
                    Code = "admin.Mail Password",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 39,
                    Code = "admin.Mail Title",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 40,
                    Code = "admin.Mail Host",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 41,
                    Code = "admin.Mail Port",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 42,
                    Code = "admin.Mail Security",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 43,
                    Code = "admin.Log",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 44,
                    Code = "admin.Aktif",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 45,
                    Code = "admin.Ip Control",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 46,
                    Code = "admin.Allowed IP List",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 47,
                    Code = "admin.Recaptcha Type",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 48,
                    Code = "admin.Recaptcha Public Key",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 49,
                    Code = "admin.Recaptcha Private Key",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 50,
                    Code = "admin.License Company Name",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 51,
                    Code = "admin.License Url",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 52,
                    Code = "admin.Made Company Name",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 53,
                    Code = "admin.Default Language",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 54,
                    Code = "admin.Admin Language",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 55,
                    Code = "admin.Language Show",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 57,
                    Code = "admin.Admin Language Show",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 58,
                    Code = "admin.Language Version",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 59,
                    Code = "admin.Language Key Auto Register",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 60,
                    Code = "admin.Admin Language Key Auto Register",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 61,
                    Code = "admin.Assets Version",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 62,
                    Code = "admin.Image Base Url",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 63,
                    Code = "admin.Facebook",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 64,
                    Code = "admin.Twitter",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 65,
                    Code = "admin.Instagram",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 66,
                    Code = "admin.Linkedin",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 67,
                    Code = "admin.Youtube",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 68,
                    Code = "admin.Kayıt",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 69,
                    Code = "admin.Yeni Ekle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 70,
                    Code = "admin.Listele",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 71,
                    Code = "admin.Dil Adı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 73,
                    Code = "admin.Dil Görseli",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 74,
                    Code = "admin.Durum",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 75,
                    Code = "admin.Admin Durum",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 76,
                    Code = "admin.Dil Değerleri",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 77,
                    Code = "admin.Dil Kodu",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 78,
                    Code = "admin.Dil Değeri",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 79,
                    Code = "admin.Güncelle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 80,
                    Code = "admin.Dil Kodları",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 81,
                    Code = "admin.ID",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 82,
                    Code = "admin.İşlemler",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 83,
                    Code = "admin.Sil",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 84,
                    Code = "admin.Adı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 85,
                    Code = "admin.Kodu",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 86,
                    Code = "admin.Görsel",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 88,
                    Code = "admin.Kayit Tarihi",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 89,
                    Code = "admin.Düzenle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 90,
                    Code = "admin.Satır",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 91,
                    Code = "admin.Sayfada Gösterilecek Satir Sayısı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 92,
                    Code = "admin.Kopyala",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 93,
                    Code = "admin.Excel",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 94,
                    Code = "admin.Pdf",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 95,
                    Code = "admin.Yazdır",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 96,
                    Code = "admin.Gizle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 97,
                    Code = "admin.Kişi",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 98,
                    Code = "admin.Konu",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 99,
                    Code = "admin.Mesaj",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 100,
                    Code = "admin.Okunma Tarihi",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 101,
                    Code = "admin.Okundu",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 102,
                    Code = "admin.Okunmadı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 103,
                    Code = "admin.Sırası",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 104,
                    Code = "admin.Footer Görünürlük",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 105,
                    Code = "admin.Başlık",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 106,
                    Code = "admin.Slug",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 107,
                    Code = "admin.İçerik",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 108,
                    Code = "admin.Detay",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 109,
                    Code = "admin.Pasif",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 110,
                    Code = "admin.Kapat",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 111,
                    Code = "admin.Ad",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 112,
                    Code = "admin.Soyad",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 113,
                    Code = "admin.Email",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 114,
                    Code = "admin.Şifre",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 115,
                    Code = "admin.Bildirim Durum",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 116,
                    Code = "admin.Tümü",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 117,
                    Code = "admin.Listeleme",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 118,
                    Code = "admin.Ekleme",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 119,
                    Code = "admin.Düzenleme",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 120,
                    Code = "admin.Silme",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 121,
                    Code = "admin.Dışarı Aktar",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 122,
                    Code = "admin.Şifre Tekrar",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 123,
                    Code = "admin.Şifre Üret",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 124,
                    Code = "admin.Soyadı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 125,
                    Code = "admin.Ad Soyad",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 126,
                    Code = "admin.Kullanıcılar",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 127,
                    Code = "admin.Site Dilleri",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 128,
                    Code = "admin.Panel Dilleri",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 129,
                    Code = "admin.Sayfalar",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 130,
                    Code = "admin.Kullanıcı Ekle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 131,
                    Code = "admin.Kullanıcı Listele",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 132,
                    Code = "admin.Dil Ekle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 133,
                    Code = "admin.Dil Ve Değerler",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 134,
                    Code = "admin.Dil Keyler",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 135,
                    Code = "admin.Sayfa Ekle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 136,
                    Code = "admin.Sayfa Listele",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 137,
                    Code = "admin.Güncelleme Başarılı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 138,
                    Code = "admin.Kayıt Tarihi",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 139,
                    Code = "admin.Saatlik",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 140,
                    Code = "admin.Günlük",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 141,
                    Code = "admin.Haftalık",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 142,
                    Code = "admin.Aylık",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 143,
                    Code = "admin.Tek Seferlik",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 144,
                    Code = "admin.Bildirim Ekle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 145,
                    Code = "admin.Bildirim Listele",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 146,
                    Code = "admin.Tipi",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 147,
                    Code = "admin.Yayın Tarihi",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 148,
                    Code = "admin.Açıklama",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 149,
                    Code = "admin.Okunma Sayısı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 150,
                    Code = "admin.Kullanıcı",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 151,
                    Code = "admin.Görünür",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 152,
                    Code = "admin.Silindi",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 153,
                    Code = "admin.Type",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 154,
                    Code = "admin.Seçiniz",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 155,
                    Code = "admin.Yeni Ekle Düzenle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 156,
                    Code = "admin.ReleaseDate",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 157,
                    Code = "admin.Durumu",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 158,
                    Code = "admin.Roleler",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 159,
                    Code = "admin.Role Ekle",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 160,
                    Code = "admin.Role Listele",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 161,
                    Code = "admin.Yetki Şablonları",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 162,
                    Code = "admin.Ek Menu Yetkileri Manuel Verilidir",
                    Type = 2
                },
                new LanguageKey
                {
                    Id = 163,
                    Code = "admin.Menü Erişim Yetkiniz Bulunmamaktadır.",
                    Type = 2
                }
           );
        }
    }
}
