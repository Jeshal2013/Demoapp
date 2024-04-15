using DataAccess.Repository;
using DataAccess.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleDemoWithoutIdentity.Data;
using SampleDemoWithoutIdentity.Models;
using System.Security.Policy;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SampleDemoWithoutIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'SampleDemoWithoutIdentityContextConnection' not found.");

builder.Services.AddDbContext<SampleDemoWithoutIdentityContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<SampleDemoWithoutIdentityContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<IEmployeeInterface>(serviceProvider =>
//{
//    return new EmployeeService(connectionString); // Pass the dependency to the constructor
//});

//builder.Services.AddTransient<IEmployeeInterface>(serviceProvider =>
//{
//    return new EmployeeService(connectionString); // Pass the dependency to the constructor
//});

builder.Services.AddSingleton<IEmployeeInterface>(serviceProvider =>
{
    return new EmployeeService(connectionString); // Pass the dependency to the constructor
});

builder.Services.AddMemoryCache(options =>
{
    // Set cache size limit (in bytes)
    options.SizeLimit = 1024 * 1024 * 100; // 100 MB
    // Set cache expiration scan frequency
    options.ExpirationScanFrequency = TimeSpan.FromMinutes(1); // 5 minutes
});


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
    name: "MyAreas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");





app.MapRazorPages();
app.Run();
