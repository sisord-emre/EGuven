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
        public DbSet<FooterMenu> FooterMenus{ get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogLanguageInfo> BlogLanguageInfos { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<QuickMenu> QuickMenus { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementLanguageInfo> AnnouncementLanguageInfos { get; set; }
        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<CorporateLanguageInfo> CorporateLanguageInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Configuration ve seeds lerin çalışması için

            base.OnModelCreating(modelBuilder);
        }
    }
}
