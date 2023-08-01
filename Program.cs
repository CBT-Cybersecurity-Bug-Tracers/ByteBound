using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ByteBound.Data;
using Microsoft.AspNetCore.Identity;
using ByteBound.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/User/Create");
    options.Conventions.AuthorizePage("/User/Index");
    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Manage");
});

builder.Services.AddDbContext<ByteBoundContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ByteBoundContext") ?? throw new InvalidOperationException("Connection string 'ByteBoundContext' not found.")));


builder.Services.AddIdentity<ApplicationUsers, ApplicationRole>(options =>
options.SignIn.RequireConfirmedAccount = false)
 .AddDefaultUI()
 .AddEntityFrameworkStores<ByteBoundContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 14;
    options.Password.RequiredUniqueChars = 1;
    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
