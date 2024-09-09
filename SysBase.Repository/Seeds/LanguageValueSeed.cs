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
    internal class LanguageValueSeed : IEntityTypeConfiguration<LanguageValue>
    {
        public void Configure(EntityTypeBuilder<LanguageValue> builder)
        {
            builder.HasData(
                new LanguageValue
                {
                    Id = 1049,
                    LanguageId = 1,
                    Text = "Koyu",
                    LanguageKeyId = 17
                },
                new LanguageValue
                {
                    Id = 1050,
                    LanguageId = 2,
                    Text = "Dark",
                    LanguageKeyId = 17
                },
                new LanguageValue
                {
                    Id = 1051,
                    LanguageId = 1,
                    Text = "Açık",
                    LanguageKeyId = 18
                },
                new LanguageValue
                {
                    Id = 1052,
                    LanguageId = 1,
                    Text = "Varsayılan",
                    LanguageKeyId = 19
                },
                new LanguageValue
                {
                    Id = 1053,
                    LanguageId = 1,
                    Text = "Bildirimler",
                    LanguageKeyId = 20
                },
                new LanguageValue
                {
                    Id = 1054,
                    LanguageId = 1,
                    Text = "Tümü Okundu",
                    LanguageKeyId = 21
                },
                new LanguageValue
                {
                    Id = 1055,
                    LanguageId = 1,
                    Text = "Profil",
                    LanguageKeyId = 22
                },
                new LanguageValue
                {
                    Id = 1056,
                    LanguageId = 1,
                    Text = "Ayarlar",
                    LanguageKeyId = 23
                },
                new LanguageValue
                {
                    Id = 1057,
                    LanguageId = 1,
                    Text = "Profil Güncelle",
                    LanguageKeyId = 24
                },
                new LanguageValue
                {
                    Id = 1058,
                    LanguageId = 1,
                    Text = "Şifre Değiştir",
                    LanguageKeyId = 25
                },
                new LanguageValue
                {
                    Id = 1059,
                    LanguageId = 1,
                    Text = "Çıkış",
                    LanguageKeyId = 27
                },
                new LanguageValue
                {
                    Id = 1060,
                    LanguageId = 1,
                    Text = "Telif Hakkı",
                    LanguageKeyId = 28
                },
                new LanguageValue
                {
                    Id = 1061,
                    LanguageId = 1,
                    Text = "Kayıt Başarılı",
                    LanguageKeyId = 29
                },
                new LanguageValue
                {
                    Id = 1062,
                    LanguageId = 1,
                    Text = "Kayıt Hatası",
                    LanguageKeyId = 30
                },
                new LanguageValue
                {
                    Id = 1063,
                    LanguageId = 1,
                    Text = "Yeni Ekle Düzenle",
                    LanguageKeyId = 31
                },
                new LanguageValue
                {
                    Id = 1064,
                    LanguageId = 1,
                    Text = "Site Url",
                    LanguageKeyId = 32
                },
                new LanguageValue
                {
                    Id = 1065,
                    LanguageId = 1,
                    Text = "Site Adı",
                    LanguageKeyId = 33
                },
                new LanguageValue
                {
                    Id = 1066,
                    LanguageId = 1,
                    Text = "Başlık",
                    LanguageKeyId = 34
                },
                new LanguageValue
                {
                    Id = 1067,
                    LanguageId = 1,
                    Text = "Telefon",
                    LanguageKeyId = 35
                },
                new LanguageValue
                {
                    Id = 1068,
                    LanguageId = 1,
                    Text = "Adres",
                    LanguageKeyId = 36
                },
                new LanguageValue
                {
                    Id = 1069,
                    LanguageId = 1,
                    Text = "Mail",
                    LanguageKeyId = 37
                },
                new LanguageValue
                {
                    Id = 1070,
                    LanguageId = 1,
                    Text = "Mail Şifre",
                    LanguageKeyId = 38
                },
                new LanguageValue
                {
                    Id = 1071,
                    LanguageId = 1,
                    Text = "Mail Başlık",
                    LanguageKeyId = 39
                },
                new LanguageValue
                {
                    Id = 1072,
                    LanguageId = 1,
                    Text = "Mail Host",
                    LanguageKeyId = 40
                },
                new LanguageValue
                {
                    Id = 1073,
                    LanguageId = 1,
                    Text = "Mail Port",
                    LanguageKeyId = 41
                },
                new LanguageValue
                {
                    Id = 1074,
                    LanguageId = 1,
                    Text = "Mail Güvenlik",
                    LanguageKeyId = 42
                },
                new LanguageValue
                {
                    Id = 1075,
                    LanguageId = 1,
                    Text = "Log",
                    LanguageKeyId = 43
                },
                new LanguageValue
                {
                    Id = 1076,
                    LanguageId = 1,
                    Text = "Aktif",
                    LanguageKeyId = 44
                },
                new LanguageValue
                {
                    Id = 1077,
                    LanguageId = 1,
                    Text = "Ip Kontrol",
                    LanguageKeyId = 45
                },
                new LanguageValue
                {
                    Id = 1078,
                    LanguageId = 1,
                    Text = "İzin Verilen IP Listesi",
                    LanguageKeyId = 46
                },
                new LanguageValue
                {
                    Id = 1079,
                    LanguageId = 1,
                    Text = "Recaptcha Türü",
                    LanguageKeyId = 47
                },
                new LanguageValue
                {
                    Id = 1080,
                    LanguageId = 1,
                    Text = "Recaptcha Açık Anahtarı",
                    LanguageKeyId = 48
                },
                new LanguageValue
                {
                    Id = 1081,
                    LanguageId = 1,
                    Text = "Recaptcha Private Key",
                    LanguageKeyId = 49
                },
                new LanguageValue
                {
                    Id = 1082,
                    LanguageId = 1,
                    Text = "Lisans Şirket Adı",
                    LanguageKeyId = 50
                },
                new LanguageValue
                {
                    Id = 1083,
                    LanguageId = 1,
                    Text = "License Url",
                    LanguageKeyId = 51
                },
                new LanguageValue
                {
                    Id = 1084,
                    LanguageId = 1,
                    Text = "Yapılan Şirket Adı",
                    LanguageKeyId = 52
                },
                new LanguageValue
                {
                    Id = 1085,
                    LanguageId = 1,
                    Text = "Varsayılan Dil",
                    LanguageKeyId = 53
                },
                new LanguageValue
                {
                    Id = 1086,
                    LanguageId = 1,
                    Text = "Yönetici Dili",
                    LanguageKeyId = 54
                },
                new LanguageValue
                {
                    Id = 1087,
                    LanguageId = 1,
                    Text = "Dil Gösterisi",
                    LanguageKeyId = 55
                },
                new LanguageValue
                {
                    Id = 1089,
                    LanguageId = 1,
                    Text = "Yönetici Dil Gösterisi",
                    LanguageKeyId = 57
                },
                new LanguageValue
                {
                    Id = 1090,
                    LanguageId = 1,
                    Text = "Dil Sürümü",
                    LanguageKeyId = 58
                },
                new LanguageValue
                {
                    Id = 1091,
                    LanguageId = 1,
                    Text = "Dil Tuşu Otomatik Kayıt",
                    LanguageKeyId = 59
                },
                new LanguageValue
                {
                    Id = 1092,
                    LanguageId = 1,
                    Text = "Yönetici Dil Anahtarı Otomatik Kayıt",
                    LanguageKeyId = 60
                },
                new LanguageValue
                {
                    Id = 1093,
                    LanguageId = 1,
                    Text = "Assets Versiyonu",
                    LanguageKeyId = 61
                },
                new LanguageValue
                {
                    Id = 1094,
                    LanguageId = 1,
                    Text = "Resim Base Url",
                    LanguageKeyId = 62
                },
                new LanguageValue
                {
                    Id = 1095,
                    LanguageId = 1,
                    Text = "Facebook",
                    LanguageKeyId = 63
                },
                new LanguageValue
                {
                    Id = 1096,
                    LanguageId = 1,
                    Text = "Twitter",
                    LanguageKeyId = 64
                },
                new LanguageValue
                {
                    Id = 1097,
                    LanguageId = 1,
                    Text = "Instagram",
                    LanguageKeyId = 65
                },
                new LanguageValue
                {
                    Id = 1098,
                    LanguageId = 1,
                    Text = "Linkedin",
                    LanguageKeyId = 66
                },
                new LanguageValue
                {
                    Id = 1099,
                    LanguageId = 1,
                    Text = "Youtube",
                    LanguageKeyId = 67
                },
                new LanguageValue
                {
                    Id = 1100,
                    LanguageId = 1,
                    Text = "Kayıt",
                    LanguageKeyId = 68
                },
                new LanguageValue
                {
                    Id = 1101,
                    LanguageId = 1,
                    Text = "Yeni Ekle",
                    LanguageKeyId = 69
                },
                new LanguageValue
                {
                    Id = 1102,
                    LanguageId = 1,
                    Text = "Listele",
                    LanguageKeyId = 70
                },
                new LanguageValue
                {
                    Id = 1103,
                    LanguageId = 1,
                    Text = "Dil Adı",
                    LanguageKeyId = 71
                },
                new LanguageValue
                {
                    Id = 1104,
                    LanguageId = 1,
                    Text = "Dil Görseli",
                    LanguageKeyId = 73
                },
                new LanguageValue
                {
                    Id = 1105,
                    LanguageId = 1,
                    Text = "Durum",
                    LanguageKeyId = 74
                },
                new LanguageValue
                {
                    Id = 1106,
                    LanguageId = 1,
                    Text = "Admin Durum",
                    LanguageKeyId = 75
                },
                new LanguageValue
                {
                    Id = 1107,
                    LanguageId = 1,
                    Text = "Dil Değerleri",
                    LanguageKeyId = 76
                },
                new LanguageValue
                {
                    Id = 1108,
                    LanguageId = 1,
                    Text = "Dil Kodu",
                    LanguageKeyId = 77
                },
                new LanguageValue
                {
                    Id = 1109,
                    LanguageId = 1,
                    Text = "Dil Değeri",
                    LanguageKeyId = 78
                },
                new LanguageValue
                {
                    Id = 1110,
                    LanguageId = 1,
                    Text = "Güncelle",
                    LanguageKeyId = 79
                },
                new LanguageValue
                {
                    Id = 1111,
                    LanguageId = 1,
                    Text = "Dil Kodları",
                    LanguageKeyId = 80
                },
                new LanguageValue
                {
                    Id = 1112,
                    LanguageId = 1,
                    Text = "ID",
                    LanguageKeyId = 81
                },
                new LanguageValue
                {
                    Id = 1113,
                    LanguageId = 1,
                    Text = "İşlemler",
                    LanguageKeyId = 82
                },
                new LanguageValue
                {
                    Id = 1114,
                    LanguageId = 1,
                    Text = "Sil",
                    LanguageKeyId = 83
                },
                new LanguageValue
                {
                    Id = 1115,
                    LanguageId = 1,
                    Text = "Adı",
                    LanguageKeyId = 84
                },
                new LanguageValue
                {
                    Id = 1116,
                    LanguageId = 1,
                    Text = "Kodu",
                    LanguageKeyId = 85
                },
                new LanguageValue
                {
                    Id = 1117,
                    LanguageId = 1,
                    Text = "Görsel",
                    LanguageKeyId = 86
                },
                new LanguageValue
                {
                    Id = 1118,
                    LanguageId = 1,
                    Text = "Kayit Tarihi",
                    LanguageKeyId = 88
                },
                new LanguageValue
                {
                    Id = 1119,
                    LanguageId = 1,
                    Text = "Düzenle",
                    LanguageKeyId = 89
                },
                new LanguageValue
                {
                    Id = 1120,
                    LanguageId = 1,
                    Text = "Satır",
                    LanguageKeyId = 90
                },
                new LanguageValue
                {
                    Id = 1121,
                    LanguageId = 1,
                    Text = "Sayfada Gösterilecek Satir Sayısı",
                    LanguageKeyId = 91
                },
                new LanguageValue
                {
                    Id = 1122,
                    LanguageId = 1,
                    Text = "Kopyala",
                    LanguageKeyId = 92
                },
                new LanguageValue
                {
                    Id = 1123,
                    LanguageId = 1,
                    Text = "Excel",
                    LanguageKeyId = 93
                },
                new LanguageValue
                {
                    Id = 1124,
                    LanguageId = 1,
                    Text = "Pdf",
                    LanguageKeyId = 94
                },
                new LanguageValue
                {
                    Id = 1125,
                    LanguageId = 1,
                    Text = "Yazdır",
                    LanguageKeyId = 95
                },
                new LanguageValue
                {
                    Id = 1126,
                    LanguageId = 1,
                    Text = "Gizle",
                    LanguageKeyId = 96
                },
                new LanguageValue
                {
                    Id = 1127,
                    LanguageId = 1,
                    Text = "Kişi",
                    LanguageKeyId = 97
                },
                new LanguageValue
                {
                    Id = 1128,
                    LanguageId = 1,
                    Text = "Konu",
                    LanguageKeyId = 98
                },
                new LanguageValue
                {
                    Id = 1129,
                    LanguageId = 1,
                    Text = "Mesaj",
                    LanguageKeyId = 99
                },
                new LanguageValue
                {
                    Id = 1130,
                    LanguageId = 1,
                    Text = "Okunma Tarihi",
                    LanguageKeyId = 100
                },
                new LanguageValue
                {
                    Id = 1131,
                    LanguageId = 1,
                    Text = "Okundu",
                    LanguageKeyId = 101
                },
                new LanguageValue
                {
                    Id = 1132,
                    LanguageId = 1,
                    Text = "Okunmadı",
                    LanguageKeyId = 102
                },
                new LanguageValue
                {
                    Id = 1133,
                    LanguageId = 1,
                    Text = "Sırası",
                    LanguageKeyId = 103
                },
                new LanguageValue
                {
                    Id = 1134,
                    LanguageId = 1,
                    Text = "Footer Görünürlük",
                    LanguageKeyId = 104
                },
                new LanguageValue
                {
                    Id = 1135,
                    LanguageId = 1,
                    Text = "Başlık",
                    LanguageKeyId = 105
                },
                new LanguageValue
                {
                    Id = 1136,
                    LanguageId = 1,
                    Text = "Slug",
                    LanguageKeyId = 106
                },
                new LanguageValue
                {
                    Id = 1137,
                    LanguageId = 1,
                    Text = "İçerik",
                    LanguageKeyId = 107
                },
                new LanguageValue
                {
                    Id = 1138,
                    LanguageId = 1,
                    Text = "Detay",
                    LanguageKeyId = 108
                },
                new LanguageValue
                {
                    Id = 1139,
                    LanguageId = 1,
                    Text = "Pasif",
                    LanguageKeyId = 109
                },
                new LanguageValue
                {
                    Id = 1140,
                    LanguageId = 1,
                    Text = "Kapat",
                    LanguageKeyId = 110
                },
                new LanguageValue
                {
                    Id = 1141,
                    LanguageId = 1,
                    Text = "Ad",
                    LanguageKeyId = 111
                },
                new LanguageValue
                {
                    Id = 1142,
                    LanguageId = 1,
                    Text = "Soyad",
                    LanguageKeyId = 112
                },
                new LanguageValue
                {
                    Id = 1143,
                    LanguageId = 1,
                    Text = "Email",
                    LanguageKeyId = 113
                },
                new LanguageValue
                {
                    Id = 1144,
                    LanguageId = 1,
                    Text = "Şifre",
                    LanguageKeyId = 114
                },
                new LanguageValue
                {
                    Id = 1145,
                    LanguageId = 1,
                    Text = "Bildirim Durum",
                    LanguageKeyId = 115
                },
                new LanguageValue
                {
                    Id = 1146,
                    LanguageId = 1,
                    Text = "Tümü",
                    LanguageKeyId = 116
                },
                new LanguageValue
                {
                    Id = 1147,
                    LanguageId = 1,
                    Text = "Listeleme",
                    LanguageKeyId = 117
                },
                new LanguageValue
                {
                    Id = 1148,
                    LanguageId = 1,
                    Text = "Ekleme",
                    LanguageKeyId = 118
                },
                new LanguageValue
                {
                    Id = 1149,
                    LanguageId = 1,
                    Text = "Düzenleme",
                    LanguageKeyId = 119
                },
                new LanguageValue
                {
                    Id = 1150,
                    LanguageId = 1,
                    Text = "Silme",
                    LanguageKeyId = 120
                },
                new LanguageValue
                {
                    Id = 1151,
                    LanguageId = 1,
                    Text = "Dışarı Aktar",
                    LanguageKeyId = 121
                },
                new LanguageValue
                {
                    Id = 1152,
                    LanguageId = 1,
                    Text = "Şifre Tekrar",
                    LanguageKeyId = 122
                },
                new LanguageValue
                {
                    Id = 1153,
                    LanguageId = 1,
                    Text = "Şifre Üret",
                    LanguageKeyId = 123
                },
                new LanguageValue
                {
                    Id = 1154,
                    LanguageId = 1,
                    Text = "Soyadı",
                    LanguageKeyId = 124
                },
                new LanguageValue
                {
                    Id = 1155,
                    LanguageId = 1,
                    Text = "Ad Soyad",
                    LanguageKeyId = 125
                },
                new LanguageValue
                {
                    Id = 1156,
                    LanguageId = 1,
                    Text = "Kullanıcılar",
                    LanguageKeyId = 126
                },
                new LanguageValue
                {
                    Id = 1157,
                    LanguageId = 1,
                    Text = "Site Dilleri",
                    LanguageKeyId = 127
                },
                new LanguageValue
                {
                    Id = 1158,
                    LanguageId = 1,
                    Text = "Panel Dilleri",
                    LanguageKeyId = 128
                },
                new LanguageValue
                {
                    Id = 1159,
                    LanguageId = 1,
                    Text = "Sayfalar",
                    LanguageKeyId = 129
                },
                new LanguageValue
                {
                    Id = 1160,
                    LanguageId = 1,
                    Text = "Kullanıcı Ekle",
                    LanguageKeyId = 130
                },
                new LanguageValue
                {
                    Id = 1161,
                    LanguageId = 1,
                    Text = "Kullanıcı Listele",
                    LanguageKeyId = 131
                },
                new LanguageValue
                {
                    Id = 1162,
                    LanguageId = 1,
                    Text = "Dil Ekle",
                    LanguageKeyId = 132
                },
                new LanguageValue
                {
                    Id = 1163,
                    LanguageId = 1,
                    Text = "Dil Ve Değerler",
                    LanguageKeyId = 133
                },
                new LanguageValue
                {
                    Id = 1164,
                    LanguageId = 1,
                    Text = "Dil Keyler",
                    LanguageKeyId = 134
                },
                new LanguageValue
                {
                    Id = 1165,
                    LanguageId = 1,
                    Text = "Sayfa Ekle",
                    LanguageKeyId = 135
                },
                new LanguageValue
                {
                    Id = 1166,
                    LanguageId = 1,
                    Text = "Sayfa Listele",
                    LanguageKeyId = 136
                },
                new LanguageValue
                {
                    Id = 1167,
                    LanguageId = 1,
                    Text = "Güncelleme Başarılı",
                    LanguageKeyId = 137
                },
                new LanguageValue
                {
                    Id = 1168,
                    LanguageId = 1,
                    Text = "Kayıt Tarihi",
                    LanguageKeyId = 138
                },
                new LanguageValue
                {
                    Id = 1169,
                    LanguageId = 2,
                    Text = "Light",
                    LanguageKeyId = 18
                },
                new LanguageValue
                {
                    Id = 1170,
                    LanguageId = 2,
                    Text = "Default",
                    LanguageKeyId = 19
                },
                new LanguageValue
                {
                    Id = 1171,
                    LanguageId = 2,
                    Text = "Notifications",
                    LanguageKeyId = 20
                },
                new LanguageValue
                {
                    Id = 1172,
                    LanguageId = 2,
                    Text = "All Read",
                    LanguageKeyId = 21
                },
                new LanguageValue
                {
                    Id = 1173,
                    LanguageId = 2,
                    Text = "Profile",
                    LanguageKeyId = 22
                },
                new LanguageValue
                {
                    Id = 1174,
                    LanguageId = 2,
                    Text = "Settings",
                    LanguageKeyId = 23
                },
                new LanguageValue
                {
                    Id = 1175,
                    LanguageId = 2,
                    Text = "Update Profile",
                    LanguageKeyId = 24
                },
                new LanguageValue
                {
                    Id = 1176,
                    LanguageId = 2,
                    Text = "Change Password",
                    LanguageKeyId = 25
                },
                new LanguageValue
                {
                    Id = 1177,
                    LanguageId = 2,
                    Text = "Exit",
                    LanguageKeyId = 27
                },
                new LanguageValue
                {
                    Id = 1178,
                    LanguageId = 2,
                    Text = "Copyright",
                    LanguageKeyId = 28
                },
                new LanguageValue
                {
                    Id = 1179,
                    LanguageId = 2,
                    Text = "Registration Successful",
                    LanguageKeyId = 29
                },
                new LanguageValue
                {
                    Id = 1180,
                    LanguageId = 2,
                    Text = "Registration Error",
                    LanguageKeyId = 30
                },
                new LanguageValue
                {
                    Id = 1181,
                    LanguageId = 2,
                    Text = "Add Edit New",
                    LanguageKeyId = 31
                },
                new LanguageValue
                {
                    Id = 1182,
                    LanguageId = 2,
                    Text = "Site Url",
                    LanguageKeyId = 32
                },
                new LanguageValue
                {
                    Id = 1183,
                    LanguageId = 2,
                    Text = "Site Name",
                    LanguageKeyId = 33
                },
                new LanguageValue
                {
                    Id = 1184,
                    LanguageId = 2,
                    Text = "Title",
                    LanguageKeyId = 34
                },
                new LanguageValue
                {
                    Id = 1185,
                    LanguageId = 2,
                    Text = "Phone",
                    LanguageKeyId = 35
                },
                new LanguageValue
                {
                    Id = 1186,
                    LanguageId = 2,
                    Text = "Address",
                    LanguageKeyId = 36
                },
                new LanguageValue
                {
                    Id = 1187,
                    LanguageId = 2,
                    Text = "Mail",
                    LanguageKeyId = 37
                },
                new LanguageValue
                {
                    Id = 1188,
                    LanguageId = 2,
                    Text = "Mail Password",
                    LanguageKeyId = 38
                },
                new LanguageValue
                {
                    Id = 1189,
                    LanguageId = 2,
                    Text = "Mail Title",
                    LanguageKeyId = 39
                },
                new LanguageValue
                {
                    Id = 1190,
                    LanguageId = 2,
                    Text = "Mail Host",
                    LanguageKeyId = 40
                },
                new LanguageValue
                {
                    Id = 1191,
                    LanguageId = 2,
                    Text = "Mail Port",
                    LanguageKeyId = 41
                },
                new LanguageValue
                {
                    Id = 1192,
                    LanguageId = 2,
                    Text = "Mail Security",
                    LanguageKeyId = 42
                },
                new LanguageValue
                {
                    Id = 1193,
                    LanguageId = 2,
                    Text = "Log",
                    LanguageKeyId = 43
                },
                new LanguageValue
                {
                    Id = 1194,
                    LanguageId = 2,
                    Text = "Active",
                    LanguageKeyId = 44
                },
                new LanguageValue
                {
                    Id = 1195,
                    LanguageId = 2,
                    Text = "Ip Control",
                    LanguageKeyId = 45
                },
                new LanguageValue
                {
                    Id = 1196,
                    LanguageId = 2,
                    Text = "Allowed IP List",
                    LanguageKeyId = 46
                },
                new LanguageValue
                {
                    Id = 1197,
                    LanguageId = 2,
                    Text = "Recaptcha Type",
                    LanguageKeyId = 47
                },
                new LanguageValue
                {
                    Id = 1198,
                    LanguageId = 2,
                    Text = "Recaptcha Public Key",
                    LanguageKeyId = 48
                },
                new LanguageValue
                {
                    Id = 1199,
                    LanguageId = 2,
                    Text = "Recaptcha Private Key",
                    LanguageKeyId = 49
                },
                new LanguageValue
                {
                    Id = 1200,
                    LanguageId = 2,
                    Text = "License Company Name",
                    LanguageKeyId = 50
                },
                new LanguageValue
                {
                    Id = 1201,
                    LanguageId = 2,
                    Text = "License Url",
                    LanguageKeyId = 51
                },
                new LanguageValue
                {
                    Id = 1202,
                    LanguageId = 2,
                    Text = "Made Company Name",
                    LanguageKeyId = 52
                },
                new LanguageValue
                {
                    Id = 1203,
                    LanguageId = 2,
                    Text = "Default Language",
                    LanguageKeyId = 53
                },
                new LanguageValue
                {
                    Id = 1204,
                    LanguageId = 2,
                    Text = "Admin Language",
                    LanguageKeyId = 54
                },
                new LanguageValue
                {
                    Id = 1205,
                    LanguageId = 2,
                    Text = "Language Show",
                    LanguageKeyId = 55
                },
                new LanguageValue
                {
                    Id = 1207,
                    LanguageId = 2,
                    Text = "Admin Language Show",
                    LanguageKeyId = 57
                },
                new LanguageValue
                {
                    Id = 1208,
                    LanguageId = 2,
                    Text = "Language Version",
                    LanguageKeyId = 58
                },
                new LanguageValue
                {
                    Id = 1209,
                    LanguageId = 2,
                    Text = "Language Key Auto Register",
                    LanguageKeyId = 59
                },
                new LanguageValue
                {
                    Id = 1210,
                    LanguageId = 2,
                    Text = "Admin Language Key Auto Register",
                    LanguageKeyId = 60
                },
                new LanguageValue
                {
                    Id = 1211,
                    LanguageId = 2,
                    Text = "Assets Version",
                    LanguageKeyId = 61
                },
                new LanguageValue
                {
                    Id = 1212,
                    LanguageId = 2,
                    Text = "Image Base Url",
                    LanguageKeyId = 62
                },
                new LanguageValue
                {
                    Id = 1213,
                    LanguageId = 2,
                    Text = "Facebook",
                    LanguageKeyId = 63
                },
                new LanguageValue
                {
                    Id = 1214,
                    LanguageId = 2,
                    Text = "Twitter",
                    LanguageKeyId = 64
                },
                new LanguageValue
                {
                    Id = 1215,
                    LanguageId = 2,
                    Text = "Instagram",
                    LanguageKeyId = 65
                },
                new LanguageValue
                {
                    Id = 1216,
                    LanguageId = 2,
                    Text = "Linkedin",
                    LanguageKeyId = 66
                },
                new LanguageValue
                {
                    Id = 1217,
                    LanguageId = 2,
                    Text = "Youtube",
                    LanguageKeyId = 67
                },
                new LanguageValue
                {
                    Id = 1218,
                    LanguageId = 2,
                    Text = "Registration",
                    LanguageKeyId = 68
                },
                new LanguageValue
                {
                    Id = 1219,
                    LanguageId = 2,
                    Text = "Add New",
                    LanguageKeyId = 69
                },
                new LanguageValue
                {
                    Id = 1220,
                    LanguageId = 2,
                    Text = "List",
                    LanguageKeyId = 70
                },
                new LanguageValue
                {
                    Id = 1221,
                    LanguageId = 2,
                    Text = "Language Name",
                    LanguageKeyId = 71
                },
                new LanguageValue
                {
                    Id = 1222,
                    LanguageId = 2,
                    Text = "Language Visualisation",
                    LanguageKeyId = 73
                },
                new LanguageValue
                {
                    Id = 1223,
                    LanguageId = 2,
                    Text = "Status",
                    LanguageKeyId = 74
                },
                new LanguageValue
                {
                    Id = 1224,
                    LanguageId = 2,
                    Text = "Admin Status",
                    LanguageKeyId = 75
                },
                new LanguageValue
                {
                    Id = 1225,
                    LanguageId = 2,
                    Text = "Language Values",
                    LanguageKeyId = 76
                },
                new LanguageValue
                {
                    Id = 1226,
                    LanguageId = 2,
                    Text = "Language Code",
                    LanguageKeyId = 77
                },
                new LanguageValue
                {
                    Id = 1227,
                    LanguageId = 2,
                    Text = "Language Value",
                    LanguageKeyId = 78
                },
                new LanguageValue
                {
                    Id = 1228,
                    LanguageId = 2,
                    Text = "Update",
                    LanguageKeyId = 79
                },
                new LanguageValue
                {
                    Id = 1229,
                    LanguageId = 2,
                    Text = "Language Codes",
                    LanguageKeyId = 80
                },
                new LanguageValue
                {
                    Id = 1230,
                    LanguageId = 2,
                    Text = "ID",
                    LanguageKeyId = 81
                },
                new LanguageValue
                {
                    Id = 1231,
                    LanguageId = 2,
                    Text = "Transactions",
                    LanguageKeyId = 82
                },
                new LanguageValue
                {
                    Id = 1232,
                    LanguageId = 2,
                    Text = "Delete",
                    LanguageKeyId = 83
                },
                new LanguageValue
                {
                    Id = 1233,
                    LanguageId = 2,
                    Text = "Name",
                    LanguageKeyId = 84
                },
                new LanguageValue
                {
                    Id = 1234,
                    LanguageId = 2,
                    Text = "Code",
                    LanguageKeyId = 85
                },
                new LanguageValue
                {
                    Id = 1235,
                    LanguageId = 2,
                    Text = "Image",
                    LanguageKeyId = 86
                },
                new LanguageValue
                {
                    Id = 1236,
                    LanguageId = 2,
                    Text = "Registration Date",
                    LanguageKeyId = 88
                },
                new LanguageValue
                {
                    Id = 1237,
                    LanguageId = 2,
                    Text = "Edit",
                    LanguageKeyId = 89
                },
                new LanguageValue
                {
                    Id = 1238,
                    LanguageId = 2,
                    Text = "Line",
                    LanguageKeyId = 90
                },
                new LanguageValue
                {
                    Id = 1239,
                    LanguageId = 2,
                    Text = "Number of lines to be displayed on the page",
                    LanguageKeyId = 91
                },
                new LanguageValue
                {
                    Id = 1240,
                    LanguageId = 2,
                    Text = "Copy",
                    LanguageKeyId = 92
                },
                new LanguageValue
                {
                    Id = 1241,
                    LanguageId = 2,
                    Text = "Excel",
                    LanguageKeyId = 93
                },
                new LanguageValue
                {
                    Id = 1242,
                    LanguageId = 2,
                    Text = "Pdf",
                    LanguageKeyId = 94
                },
                new LanguageValue
                {
                    Id = 1243,
                    LanguageId = 2,
                    Text = "Print",
                    LanguageKeyId = 95
                },
                new LanguageValue
                {
                    Id = 1244,
                    LanguageId = 2,
                    Text = "Hide",
                    LanguageKeyId = 96
                },
                new LanguageValue
                {
                    Id = 1245,
                    LanguageId = 2,
                    Text = "Person",
                    LanguageKeyId = 97
                },
                new LanguageValue
                {
                    Id = 1246,
                    LanguageId = 2,
                    Text = "Subject",
                    LanguageKeyId = 98
                },
                new LanguageValue
                {
                    Id = 1247,
                    LanguageId = 2,
                    Text = "Message",
                    LanguageKeyId = 99
                },
                new LanguageValue
                {
                    Id = 1248,
                    LanguageId = 2,
                    Text = "Read Date",
                    LanguageKeyId = 100
                },
                new LanguageValue
                {
                    Id = 1249,
                    LanguageId = 1,
                    Text = "Seçiniz",
                    LanguageKeyId = 154
                },
                new LanguageValue
                {
                    Id = 1250,
                    LanguageId = 1,
                    Text = "Tip",
                    LanguageKeyId = 153
                },
                new LanguageValue
                {
                    Id = 1251,
                    LanguageId = 1,
                    Text = "Silindi",
                    LanguageKeyId = 152
                },
                new LanguageValue
                {
                    Id = 1252,
                    LanguageId = 1,
                    Text = "Görünür",
                    LanguageKeyId = 151
                },
                new LanguageValue
                {
                    Id = 1253,
                    LanguageId = 1,
                    Text = "Kullanıcı",
                    LanguageKeyId = 150
                },
                new LanguageValue
                {
                    Id = 1254,
                    LanguageId = 1,
                    Text = "Okunma Sayısı",
                    LanguageKeyId = 149
                },
                new LanguageValue
                {
                    Id = 1255,
                    LanguageId = 1,
                    Text = "Açıklama",
                    LanguageKeyId = 148
                },
                new LanguageValue
                {
                    Id = 1256,
                    LanguageId = 1,
                    Text = "Yayın Tarihi",
                    LanguageKeyId = 147
                },
                new LanguageValue
                {
                    Id = 1257,
                    LanguageId = 1,
                    Text = "Tipi",
                    LanguageKeyId = 146
                },
                new LanguageValue
                {
                    Id = 1258,
                    LanguageId = 1,
                    Text = "Bildirim Listele",
                    LanguageKeyId = 145
                },
                new LanguageValue
                {
                    Id = 1259,
                    LanguageId = 1,
                    Text = "Bildirim Ekle",
                    LanguageKeyId = 144
                },
                new LanguageValue
                {
                    Id = 1260,
                    LanguageId = 1,
                    Text = "Tek Seferlik",
                    LanguageKeyId = 143
                },
                new LanguageValue
                {
                    Id = 1261,
                    LanguageId = 1,
                    Text = "Aylık",
                    LanguageKeyId = 142
                },
                new LanguageValue
                {
                    Id = 1262,
                    LanguageId = 1,
                    Text = "Haftalık",
                    LanguageKeyId = 141
                },
                new LanguageValue
                {
                    Id = 1263,
                    LanguageId = 1,
                    Text = "Günlük",
                    LanguageKeyId = 140
                },
                new LanguageValue
                {
                    Id = 1264,
                    LanguageId = 1,
                    Text = "Saatlik",
                    LanguageKeyId = 139
                },
                new LanguageValue
                {
                    Id = 1265,
                    LanguageId = 2,
                    Text = "Select",
                    LanguageKeyId = 154
                },
                new LanguageValue
                {
                    Id = 1266,
                    LanguageId = 2,
                    Text = "Type",
                    LanguageKeyId = 153
                },
                new LanguageValue
                {
                    Id = 1267,
                    LanguageId = 2,
                    Text = "Deleted",
                    LanguageKeyId = 152
                },
                new LanguageValue
                {
                    Id = 1268,
                    LanguageId = 2,
                    Text = "Visible",
                    LanguageKeyId = 151
                },
                new LanguageValue
                {
                    Id = 1269,
                    LanguageId = 2,
                    Text = "User",
                    LanguageKeyId = 150
                },
                new LanguageValue
                {
                    Id = 1270,
                    LanguageId = 2,
                    Text = "Number of Reads",
                    LanguageKeyId = 149
                },
                new LanguageValue
                {
                    Id = 1271,
                    LanguageId = 2,
                    Text = "Description",
                    LanguageKeyId = 148
                },
                new LanguageValue
                {
                    Id = 1272,
                    LanguageId = 2,
                    Text = "Publication Date",
                    LanguageKeyId = 147
                },
                new LanguageValue
                {
                    Id = 1273,
                    LanguageId = 2,
                    Text = "Type",
                    LanguageKeyId = 146
                },
                new LanguageValue
                {
                    Id = 1274,
                    LanguageId = 2,
                    Text = "List Notification",
                    LanguageKeyId = 145
                },
                new LanguageValue
                {
                    Id = 1275,
                    LanguageId = 2,
                    Text = "Add Notification",
                    LanguageKeyId = 144
                },
                new LanguageValue
                {
                    Id = 1276,
                    LanguageId = 2,
                    Text = "One Time Only",
                    LanguageKeyId = 143
                },
                new LanguageValue
                {
                    Id = 1277,
                    LanguageId = 2,
                    Text = "Monthly",
                    LanguageKeyId = 142
                },
                new LanguageValue
                {
                    Id = 1278,
                    LanguageId = 2,
                    Text = "Weekly",
                    LanguageKeyId = 141
                },
                new LanguageValue
                {
                    Id = 1279,
                    LanguageId = 2,
                    Text = "Diary",
                    LanguageKeyId = 140
                },
                new LanguageValue
                {
                    Id = 1280,
                    LanguageId = 2,
                    Text = "Seeds",
                    LanguageKeyId = 139
                },
                new LanguageValue
                {
                    Id = 1281,
                    LanguageId = 2,
                    Text = "Kayıt Tarihi",
                    LanguageKeyId = 138
                },
                new LanguageValue
                {
                    Id = 1282,
                    LanguageId = 2,
                    Text = "Update Successful",
                    LanguageKeyId = 137
                },
                new LanguageValue
                {
                    Id = 1283,
                    LanguageId = 2,
                    Text = "List Page",
                    LanguageKeyId = 136
                },
                new LanguageValue
                {
                    Id = 1284,
                    LanguageId = 2,
                    Text = "Add Page",
                    LanguageKeyId = 135
                },
                new LanguageValue
                {
                    Id = 1285,
                    LanguageId = 2,
                    Text = "Language Keys",
                    LanguageKeyId = 134
                },
                new LanguageValue
                {
                    Id = 1286,
                    LanguageId = 2,
                    Text = "Language and Values",
                    LanguageKeyId = 133
                },
                new LanguageValue
                {
                    Id = 1287,
                    LanguageId = 2,
                    Text = "Add Language",
                    LanguageKeyId = 132
                },
                new LanguageValue
                {
                    Id = 1288,
                    LanguageId = 2,
                    Text = "List User",
                    LanguageKeyId = 131
                },
                new LanguageValue
                {
                    Id = 1289,
                    LanguageId = 2,
                    Text = "Add User",
                    LanguageKeyId = 130
                },
                new LanguageValue
                {
                    Id = 1290,
                    LanguageId = 2,
                    Text = "Pages",
                    LanguageKeyId = 129
                },
                new LanguageValue
                {
                    Id = 1291,
                    LanguageId = 2,
                    Text = "Panel Languages",
                    LanguageKeyId = 128
                },
                new LanguageValue
                {
                    Id = 1292,
                    LanguageId = 2,
                    Text = "Site Languages",
                    LanguageKeyId = 127
                },
                new LanguageValue
                {
                    Id = 1293,
                    LanguageId = 2,
                    Text = "Users",
                    LanguageKeyId = 126
                },
                new LanguageValue
                {
                    Id = 1294,
                    LanguageId = 2,
                    Text = "Name Surname",
                    LanguageKeyId = 125
                },
                new LanguageValue
                {
                    Id = 1295,
                    LanguageId = 2,
                    Text = "Surname",
                    LanguageKeyId = 124
                },
                new LanguageValue
                {
                    Id = 1296,
                    LanguageId = 2,
                    Text = "Generate Password",
                    LanguageKeyId = 123
                },
                new LanguageValue
                {
                    Id = 1297,
                    LanguageId = 2,
                    Text = "Password Again",
                    LanguageKeyId = 122
                },
                new LanguageValue
                {
                    Id = 1298,
                    LanguageId = 2,
                    Text = "Export",
                    LanguageKeyId = 121
                },
                new LanguageValue
                {
                    Id = 1299,
                    LanguageId = 2,
                    Text = "Deletion",
                    LanguageKeyId = 120
                },
                new LanguageValue
                {
                    Id = 1300,
                    LanguageId = 2,
                    Text = "Regulation",
                    LanguageKeyId = 119
                },
                new LanguageValue
                {
                    Id = 1301,
                    LanguageId = 2,
                    Text = "Addition",
                    LanguageKeyId = 118
                },
                new LanguageValue
                {
                    Id = 1302,
                    LanguageId = 2,
                    Text = "Listing",
                    LanguageKeyId = 117
                },
                new LanguageValue
                {
                    Id = 1303,
                    LanguageId = 2,
                    Text = "All",
                    LanguageKeyId = 116
                },
                new LanguageValue
                {
                    Id = 1304,
                    LanguageId = 2,
                    Text = "Notification Status",
                    LanguageKeyId = 115
                },
                new LanguageValue
                {
                    Id = 1305,
                    LanguageId = 2,
                    Text = "Password",
                    LanguageKeyId = 114
                },
                new LanguageValue
                {
                    Id = 1306,
                    LanguageId = 2,
                    Text = "Email",
                    LanguageKeyId = 113
                },
                new LanguageValue
                {
                    Id = 1307,
                    LanguageId = 2,
                    Text = "Surname",
                    LanguageKeyId = 112
                },
                new LanguageValue
                {
                    Id = 1308,
                    LanguageId = 2,
                    Text = "Ad",
                    LanguageKeyId = 111
                },
                new LanguageValue
                {
                    Id = 1309,
                    LanguageId = 2,
                    Text = "Close",
                    LanguageKeyId = 110
                },
                new LanguageValue
                {
                    Id = 1310,
                    LanguageId = 2,
                    Text = "Passive",
                    LanguageKeyId = 109
                },
                new LanguageValue
                {
                    Id = 1311,
                    LanguageId = 2,
                    Text = "Detail",
                    LanguageKeyId = 108
                },
                new LanguageValue
                {
                    Id = 1312,
                    LanguageId = 2,
                    Text = "Content",
                    LanguageKeyId = 107
                },
                new LanguageValue
                {
                    Id = 1313,
                    LanguageId = 2,
                    Text = "Slug",
                    LanguageKeyId = 106
                },
                new LanguageValue
                {
                    Id = 1314,
                    LanguageId = 2,
                    Text = "Title",
                    LanguageKeyId = 105
                },
                new LanguageValue
                {
                    Id = 1315,
                    LanguageId = 2,
                    Text = "Footer Visibility",
                    LanguageKeyId = 104
                },
                new LanguageValue
                {
                    Id = 1316,
                    LanguageId = 2,
                    Text = "Sequence",
                    LanguageKeyId = 103
                },
                new LanguageValue
                {
                    Id = 1317,
                    LanguageId = 2,
                    Text = "Not read",
                    LanguageKeyId = 102
                },
                new LanguageValue
                {
                    Id = 1318,
                    LanguageId = 2,
                    Text = "Read out",
                    LanguageKeyId = 101
                },
                new LanguageValue
                {
                    Id = 1319,
                    LanguageId = 1,
                    Text = "Yeni Ekle Düzenle",
                    LanguageKeyId = 155
                },
                new LanguageValue
                {
                    Id = 1320,
                    LanguageId = 2,
                    Text = "Add Edit New",
                    LanguageKeyId = 155
                },
                new LanguageValue
                {
                    Id = 1321,
                    LanguageId = 1,
                    Text = "Durumu",
                    LanguageKeyId = 157
                },
                new LanguageValue
                {
                    Id = 1322,
                    LanguageId = 1,
                    Text = "YayınlanmaTarihi",
                    LanguageKeyId = 156
                },
                new LanguageValue
                {
                    Id = 1323,
                    LanguageId = 2,
                    Text = "Status",
                    LanguageKeyId = 157
                },
                new LanguageValue
                {
                    Id = 1324,
                    LanguageId = 2,
                    Text = "Release Date",
                    LanguageKeyId = 156
                },
                new LanguageValue
                {
                    Id = 1325,
                    LanguageId = 1,
                    Text = "Rol Listele",
                    LanguageKeyId = 160
                },
                new LanguageValue
                {
                    Id = 1326,
                    LanguageId = 1,
                    Text = "Rol Ekle",
                    LanguageKeyId = 159
                },
                new LanguageValue
                {
                    Id = 1327,
                    LanguageId = 1,
                    Text = "Roller",
                    LanguageKeyId = 158
                },
                new LanguageValue
                {
                    Id = 1328,
                    LanguageId = 2,
                    Text = "Role List",
                    LanguageKeyId = 160
                },
                new LanguageValue
                {
                    Id = 1329,
                    LanguageId = 2,
                    Text = "Add Role",
                    LanguageKeyId = 159
                },
                new LanguageValue
                {
                    Id = 1330,
                    LanguageId = 2,
                    Text = "Roles",
                    LanguageKeyId = 158
                },
                new LanguageValue
                {
                    Id = 1331,
                    LanguageId = 1,
                    Text = "Ek Menu Yetkileri Manuel Verilidir",
                    LanguageKeyId = 162
                },
                new LanguageValue
                {
                    Id = 1332,
                    LanguageId = 1,
                    Text = "Yetki Şablonları",
                    LanguageKeyId = 161
                },
                new LanguageValue
                {
                    Id = 1333,
                    LanguageId = 2,
                    Text = "Additional Menu Authorisations are Manual",
                    LanguageKeyId = 162
                },
                new LanguageValue
                {
                    Id = 1334,
                    LanguageId = 2,
                    Text = "Authorisation Templates",
                    LanguageKeyId = 161
                },
                new LanguageValue
                {
                    Id = 1335,
                    LanguageId = 1,
                    Text = "Menü Erişim Yetkiniz Bulunmamaktadır.",
                    LanguageKeyId = 163
                },
                new LanguageValue
                {
                    Id = 1336,
                    LanguageId = 2,
                    Text = "You are not authorised to access the menu.",
                    LanguageKeyId = 163
                }
            );
        }
    }
}
