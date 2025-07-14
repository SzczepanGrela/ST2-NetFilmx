using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using NetFilmx_User.Data;
using NetFilmx_User.Models;
using NetFilmx_User.Extensions;
using NetFilmx_Storage.Context;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly()));

// Add NetFilmx services (repositories, business logic)
builder.Services.AddNetFilmxServices();
builder.Services.AddAutoMapperProfiles();
builder.Services.AddRequestHandlers();
builder.Services.AddCommandHandlers();

// Add session support for shopping cart
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add HttpContextAccessor for cart service
builder.Services.AddHttpContextAccessor();

// Add HttpClient for API communication
builder.Services.AddHttpClient("NetFilmxAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5032"); // API URL
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Add API Service
builder.Services.AddScoped<NetFilmx_User.Services.IApiService, NetFilmx_User.Services.ApiService>();

// Add User Sync Service
builder.Services.AddScoped<NetFilmx_User.Services.IUserSyncService, NetFilmx_User.Services.UserSyncService>();

// Identity configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure()));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Cookie configuration
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Polish culture for decimal numbers
var defaultDateCulture = "pl-PL";
var ci = new CultureInfo(defaultDateCulture);
ci.NumberFormat.CurrencyDecimalSeparator = ",";
ci.NumberFormat.NumberDecimalSeparator = ",";
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ci),
    SupportedCultures = new List<CultureInfo> { ci },
    SupportedUICultures = new List<CultureInfo> { ci }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add session middleware before authentication
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// Map Identity Razor Pages
app.MapRazorPages();

// Map MVC routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Auto-launch browser in development
if (app.Environment.IsDevelopment())
{
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        var urls = app.Urls;
        if (urls.Any())
        {
            var url = urls.First();
            try
            {
                // Try to open in new window for different browsers
                var browserArgs = Environment.OSVersion.Platform == PlatformID.Win32NT 
                    ? $"--new-window {url}" 
                    : $"--new-window {url}";
                
                try
                {
                    // Try Chrome first with new window flag
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "chrome",
                        Arguments = $"--new-window {url}",
                        UseShellExecute = true
                    });
                }
                catch
                {
                    try
                    {
                        // Try Edge with new window flag
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "msedge",
                            Arguments = $"--new-window {url}",
                            UseShellExecute = true
                        });
                    }
                    catch
                    {
                        // Fallback to default browser
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error but don't crash the application
                Console.WriteLine($"Could not open browser: {ex.Message}");
            }
        }
    });
}

app.Run();
