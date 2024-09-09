using Microsoft.EntityFrameworkCore;

namespace SysBase.Core.Models
{
    public class Config
    {
        public int Id { get; set; }
        public string SiteUrl { get; set; }
        public string SiteName { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string MailPassword { get; set; }
        public string MailTitle { get; set; }
        public string MailHost { get; set; }
        public int MailPort { get; set; }
        [Comment("SSL/TLS")]
        public string MailSecurity { get; set; }
        public bool Log { get; set; }
        public bool IpControl { get; set; }
        public string AllowedIPList { get; set; }
        [Comment("1:S2, 2:S3, 3:CloudFLare")]
        public int RecaptchaType { get; set; }
        [Comment("hem public hem private dolu ise aktiftir")]
        public string RecaptchaPublicKey { get; set; }
        public string RecaptchaPrivateKey { get; set; }
        public string LicenseCompanyName { get; set; }
        public string LicenseUrl { get; set; }
        public string MadeCompanyName { get; set; }
        public int DefaultLanguageId { get; set; }
        public int AdminLanguageId { get; set; }
        public bool LanguageShow { get; set; }
        public bool AdminLanguageShow { get; set; }
        public int LanguageVersion { get; set; }
        public bool LanguageKeyAutoRegister { get; set; }
        public bool AdminLanguageKeyAutoRegister { get; set; }
        public int AssetsVersion { get; set; }
        public string ImageBaseUrl { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string Youtube { get; set; }
    }
}
