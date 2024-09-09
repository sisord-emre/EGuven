using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysBase.Core.Models;

namespace SysBase.Repository.Seeds
{
    internal class ConfigSeed : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.HasData(
                new Config { Id = 1, SiteUrl = "https://localhost:7138/", SiteName = "Sys Base", Title = "Sys Base", Phone = "5555555", Address = "", Mail = "noreply1@sisord.com", MailPassword = "63427xykru", MailTitle = "Sys Base", MailHost = "smtp.yandex.com.tr", MailPort = 465, MailSecurity = "ssl", Log = true, IpControl = true, AllowedIPList = "", RecaptchaType = 1, RecaptchaPublicKey = "6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI", RecaptchaPrivateKey = "6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe", LicenseCompanyName = "Sisord Teknoloji", LicenseUrl = "https://sisord.com", MadeCompanyName = "Firma adı", DefaultLanguageId = 1, AdminLanguageId = 1, LanguageShow = true, AdminLanguageShow = true, LanguageVersion = 1, LanguageKeyAutoRegister = false, AdminLanguageKeyAutoRegister = false, AssetsVersion = 1, ImageBaseUrl = "https://localhost:7138/Images/", Facebook = "#", Twitter = "#", Instagram = "#", Linkedin = "#", Youtube = "#" }
            );
        }
    }
}
