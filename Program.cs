using Scheduler.Infrastructure;
using Scheduler.Infrastructure.Extensions;
using Scheduler.Models;

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

// Configure o User para permitir logins com e-mail ou nome de usuário
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = false; // Configuração opcional
    options.SignIn.RequireConfirmedPhoneNumber = false; // Configuração opcional

    options.User.RequireUniqueEmail = true; // Certifique-se de que os e-mails sejam únicos
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; // Adicione caracteres permitidos no nome de usuário
});

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
