using Microsoft.EntityFrameworkCore;
using NetFilmx_Service.Mappings;
using NetFilmx_Storage.Entities;
using System.Reflection;
using MediatR;
using NetFilmx_Service.Query.Category;
using NetFilmx_Web.Extensions;
using NetFilmx_Storage;
using NetFilmx_Service;
using Autofac;
using Microsoft.Build.Execution;
using Autofac.Extensions.DependencyInjection;
using NetFilmx_Service.Command.Category;

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
