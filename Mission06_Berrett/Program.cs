using Microsoft.EntityFrameworkCore;
using Mission06_Berrett.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the database context with the SQLite connection string 
builder.Services.AddDbContext<MovieCollectionContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();