using iDss.X.Components;
using iDss.X.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Blazored.SessionStorage;
using iDss.X.Models;
using Microsoft.AspNetCore.Identity;
using iDss.X.Services;
using AutoMapper;
using iDss.X;
using iDss.X.Data.Seed;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddBootstrapBlazor();

// Baca Environment (Default = Development)
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); 

// Cek Environment Name (Debugging)
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

builder.Services.AddDbContextFactory<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddDbContext<AuthDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 8;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = false;
})
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login"; // path ke custom login page
    //// untuk API
    //options.Events.OnRedirectToLogin = context =>
    //{
    //    context.Response.StatusCode = 401; // untuk API
    //    return Task.CompletedTask;
    //};
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthorization();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add IDSS Services operation class
builder.Services.AddIDSSServices();

// Add Table demo data service operation class
builder.Services.AddTableDemoDataService();

// Add SignalR service data transfer size limit configuration
builder.Services.Configure<HubOptions>(option => option.MaximumReceiveMessageSize = null);

builder.Services.AddBlazoredSessionStorage();

builder.Services.AddResponseCompression();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthorization();

// Tambahkan service controller
builder.Services.AddControllers();

// untuk @inject HttpClient Http
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp =>
{
    var navManager = sp.GetRequiredService<NavigationManager>();
    return new HttpClient
    {
        BaseAddress = new Uri(navManager.BaseUri)
    };
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseResponseCompression();
}

app.UseStaticFiles(); // Penting: aktifkan file statis (js/css)
app.UseRouting(); // HARUS sebelum UseAuthentication dan MapControllers

// Middleware
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

// API Controller
app.MapControllers();

// SignalR Blazor
//app.MapBlazorHub();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

// Tambahkan file seed untuk identity
using (var scope = app.Services.CreateScope())
{
    await IdentitySeeding.InitializeAsync(scope.ServiceProvider);
}

ApplyMigration();
app.Run();
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var _db2 = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }

        if (_db2.Database.GetPendingMigrations().Count() > 0)
        {
            _db2.Database.Migrate();
        }
    }
}
