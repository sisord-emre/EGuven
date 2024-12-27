using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SysBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Repository
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageKey> LanguageKeys { get; set; }
        public DbSet<LanguageValue> LanguageValues { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<JsError> JsErrors { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageLanguageInfo> PageLanguageInfos { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SiteMenu> SiteMenus { get; set; }
        public DbSet<FooterMenu> FooterMenus { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogLanguageInfo> BlogLanguageInfos { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<QuickMenu> QuickMenus { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementLanguageInfo> AnnouncementLanguageInfos { get; set; }
        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<CorporateLanguageInfo> CorporateLanguageInfos { get; set; }
        public DbSet<ApiBasvuruRequest> ApiBasvuruRequests { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<SectorLanguageInfo> SectorLanguageInfos { get; set; }
        public DbSet<SectoralReference> SectoralReferences { get; set; }
        public DbSet<SectoralReferenceSector> SectoralReferenceSectors { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<SoftwareLanguageInfo> SoftwareLanguageInfos { get; set; }
        public DbSet<SupportDesk> SupportDesks { get; set; }
        public DbSet<SupportDeskLanguageInfo> SupportDeskLanguageInfos { get; set; }
        public DbSet<SoftwareCategory> SoftwareCategories { get; set; }
        public DbSet<SoftwareCategoryLanguageInfo> SoftwareCategoryLanguageInfos { get; set; }
        public DbSet<HelperVideo> HelperVideos { get; set; }
        public DbSet<HelperVideoLanguageInfo> HelperVideoLanguageInfos { get; set; }
        public DbSet<ProductSoftware> ProductSoftwares { get; set; }
        public DbSet<ProductSoftwareLanguageInfo> ProductSoftwareLanguageInfos { get; set; }
        public DbSet<SoftwareCategoryLanguageInfoContent> SoftwareCategoryLanguageInfoContents { get; set; }
        public DbSet<HomeProduct> HomeProducts { get; set; }
        public DbSet<HomeProductLanguageInfo> HomeProductLanguageInfos { get; set; }
        public DbSet<HomeProductSequence> HomeProductSequences { get; set; }
        public DbSet<HomeTabPost> HomeTabPosts { get; set; }
        public DbSet<HomeTabPostLanguageInfo> HomeTabPostLanguageInfos { get; set; }
        public DbSet<HomeTabPostLanguageInfoContent> HomeTabPostLanguageInfoContents { get; set; }
        public DbSet<CompanyInvoice> CompanyInvoices { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLanguageInfo> ProductLanguageInfos { get; set; }
        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<ConfigLanguageInfo> ConfigLanguageInfos { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<MailTemplateLanguageInfo> MailTemplateLanguageInfos { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Route> Routes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Configuration ve seeds lerin çalışması için

            base.OnModelCreating(modelBuilder);
        }
    }
}
