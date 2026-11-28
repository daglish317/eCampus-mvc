using eCampus.web.Data;
using eCampus.web.Models.EAcademie;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using eCampus.web.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

// 1) Connexion SQLite
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// 2) Identity avec notre ApplicationUser + rôles
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;   // plus simple pour dev
        options.Password.RequireNonAlphanumeric = false;  // plus simple pour dev
        options.Password.RequiredLength = 6;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Initialise les rôles et le compte administrateur au démarrage
// Applique les migrations en attente puis initialise les rôles et le compte administrateur
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.MigrateAsync();

    await DbSeeder.InitialiserAsync(scope.ServiceProvider);
}

// 3) Seed des rôles + admin au démarrage


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Route des Areas : doit être déclarée AVANT la route par défaut
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();   // nécessaire pour Identity

app.Run();