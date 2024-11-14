using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using SysBase.Core.Models;
using SysBase.Repository;
using SysBase.Service.Mapping;
using SysBase.Web.Areas.Admin.Models;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using Serilog.Core;
using SysBase.Web.Configurations;
using Serilog.Context;

var builder = WebApplication.CreateBuilder(args);

//dil bilgisi
builder.Services.AddLocalization();
builder.Services.AddMvc().AddViewLocalization();
//also important, use this to create your app's IStringLocalizerFactory
builder.Services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
CultureInfo[] supportedCultures = new[]{
    new CultureInfo("en"),
    new CultureInfo("tr"),
};
//!dil bilgisi

//repo katmanýndakiler ekleniyor
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);//tip güvenli olarka hangi repository katmanýndan çekeceðini belirttik
    });
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
});
//cookie ve login page configure
builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();
    cookieBuilder.Name = "AppCookie";
    opt.LoginPath = new PathString("/Admin/Login");
    opt.LogoutPath = new PathString("/Admin/Home/LogOut");
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(30);
    opt.SlidingExpiration = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


SqlColumn userNameColumn = new SqlColumn
{
    ColumnName = "UserName",
    DataType = System.Data.SqlDbType.NVarChar,
    PropertyName = "UserName",
    DataLength = 50,
    AllowNull = true
};

SqlColumn typeNameColumn = new SqlColumn
{
    ColumnName = "TypeName",
    DataType = System.Data.SqlDbType.NVarChar,
    PropertyName = "TypeName",
    DataLength = 50,
    AllowNull = true
};

ColumnOptions columnOpt = new ColumnOptions();
columnOpt.Store.Remove(StandardColumn.Properties);
columnOpt.Store.Add(StandardColumn.LogEvent);
columnOpt.AdditionalColumns = new Collection<SqlColumn> { userNameColumn, typeNameColumn };

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(
    connectionString: builder.Configuration.GetConnectionString("SqlConnection"),
     sinkOptions: new MSSqlServerSinkOptions
     {
         AutoCreateSqlTable = true,
         TableName = "logs",
     },
     appConfiguration: null,
     columnOptions: columnOpt
    )
    .Enrich.FromLogContext()
    .Enrich.With<CustomUserNameColumn>()
    .Enrich.With<CustomTypeNameColumn>()
    .MinimumLevel.Fatal()
    .CreateLogger();
builder.Host.UseSerilog(log);

var app = builder.Build();

//dil bilgisi
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});
//!dil bilgisi

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("UserName", username);
    await next();
});

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{slug?}/{action=Index}");

app.MapControllerRoute(
    name: "Corporate",
    pattern: "kurumsal/{controller=Corporate}/{action=Index}");

app.MapControllerRoute(
    name: "SectoralReference",
    pattern: "sektorel-referanslarimiz/{controller=SectoralReference}/{action=Index}");

app.MapControllerRoute(
    name: "BusinessPartners",
    pattern: "is-ortaklarimiz/{controller=BusinessPartners}/{action=Index}");

app.MapControllerRoute(
    name: "Blog",
    pattern: "blog-list/{controller=Blog}/{action=Index}");


app.MapControllerRoute(
    name: "BlogListRow",
    pattern: "blog-list-row/{controller=BlogListRow}/{action=Index}");

app.MapControllerRoute(
    name: "BlogDetail",
    pattern: "blog-detay/{slug}/{controller=BlogDetail}/{action=Index}");

app.Run();
