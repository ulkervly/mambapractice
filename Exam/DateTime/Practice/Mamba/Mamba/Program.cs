using Microsoft.EntityFrameworkCore;
using Mamba.Data.DAL;
using Microsoft.AspNetCore.Identity;
using Mamba.Core.Repostories.Interfaces;
using Mamba.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<ITeamRepository, TeamRepository>();


builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(20);
});
builder.Services.AddDbContext<MambaContext>(opt =>
{
    opt.UseSqlServer("Server=DESKTOP-1TG370G;Database=Mamba;Trusted_Connection=True");
});
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.User.RequireUniqueEmail = false;

}
).AddEntityFrameworkStores<MambaContext>().AddDefaultTokenProviders();



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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
