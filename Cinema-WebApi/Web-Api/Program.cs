using BusinessLogic.Extentions;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services;
using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Extencions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = @"Server=(localdb)\mssqllocaldb;Database=CinemaDb;Trusted_Connection=True;";
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContextFactory<CinemaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaContext")
        ?? throw new InvalidOperationException("Connection string not found.")));

builder.Services.AddRepository();

builder.Services.AddScoped<DbContext, CinemaContext>();
//Services
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<ICinemaHallService, CinemaHallService>();

builder.Services.AddScoped<IUserService, UserServise>();
builder.Services.AddAutoMapper();

builder.Services.AddValidators();

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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
