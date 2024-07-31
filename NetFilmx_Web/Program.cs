using Microsoft.EntityFrameworkCore;
using NetFilmx_Service.Mappings;
using NetFilmx_Storage.Entities;
using System.Reflection;
using MediatR;
using NetFilmx_Service.Query.Category.GetAll;
using NetFilmx_Web.Extensions;
using NetFilmx_Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddNetFilmxServices();


//builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(VideoMappingProfile));
builder.Services.AddAutoMapper(typeof(TagMappingProfile));
builder.Services.AddAutoMapper(typeof(SeriesMappingProfile));
builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddAutoMapper(typeof(CommentMappingProfile));




builder.Services.AddDbContext<NetFilmxDbContext>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    typeof(GetAllCategoriesQueryHandler<>).Assembly  // Register handlers from srrvice layer
));

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
