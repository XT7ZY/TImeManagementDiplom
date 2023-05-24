using NLog.Web;
using Microsoft.EntityFrameworkCore;
using TImeManagement.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using TImeManagement;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

#region nlogConnect
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
#endregion nlog

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region DataBaseConnect
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DataBase")
    ));
#endregion

#region Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    });
#endregion

#region Authorization
AddAuthorizationPolicies(builder.Services);
#endregion

#region AddScope
builder.Services.InitializeRepositories();
builder.Services.InitializeServices();
#endregion

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
app.Run();

#region RolesPolices
void AddAuthorizationPolicies(IServiceCollection services)
{
    services.AddAuthorization(options =>
    {
        options.AddPolicy("RootOnly", policy => policy.RequireClaim("Root"));
        options.AddPolicy("EmployOnly", policy => policy.RequireClaim("Employer"));
        options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));

    });
}
#endregion