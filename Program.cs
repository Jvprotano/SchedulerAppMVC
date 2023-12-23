using AppAgendamentos.Infrastructure;
using AppAgendamentos.Infrastructure.Extensions;
using AppAgendamentos.Models;
using AppAgendamentos.Models.Base;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));


// Add services to the container.
builder.Services.AddControllersWithViews();

// Obter a seção ConnectionStrings do arquivo appsettings.json
var connectionStrings = builder.Configuration.GetSection("ConnectionStrings");

// Obter a string de conexão do SQL Server a partir da seção ConnectionStrings
var sqlServerConnectionString = connectionStrings["DefaultConnection"];

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(sqlServerConnectionString),
    ServiceLifetime.Scoped
);

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRepositories();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
