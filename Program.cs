var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();



app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();