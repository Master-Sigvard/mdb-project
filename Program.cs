using mdb_project.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Cookies";
    options.DefaultSignInScheme = "Cookies";
    options.DefaultChallengeScheme = "Cookies";
})
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login";
    });

builder.Services.AddDbContext<FilmDBContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-PDNGHNS\\SQLEXPRESS;Database=FilmDB;" +
        "Trusted_Connection=True;TrustServerCertificate=True");
});

var app = builder.Build();


app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();