using Microsoft.AspNetCore.Localization;
using NetFilmx_Storage;
using NetFilmx_Web.Extensions;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly()));







builder.Services.AddNetFilmxServices();

builder.Services.AddRequestHandlers();

builder.Services.AddCommandHandlers();

builder.Services.AddAutoMapProfiles();


builder.Services.AddDbContext<NetFilmxDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// setting up polish culture, so validators can recognize numbers with , as decimal numbers

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

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
