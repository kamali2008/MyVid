using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyVid.Core;
using MyVid.Core.Models;
using MyVid.Core.Services.Users;
using MyVid.Data;
using MyVid.Services.Users;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(options => options
                                .UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                                                    x => x.MigrationsAssembly("MyVid.Data")));
// For Identity  
builder.Services.AddIdentity<Usuario, IdentityRole>(opt =>{ 
                                            opt.User.RequireUniqueEmail = true; 
                                            opt.Password.RequireNonAlphanumeric = false;
                                            opt.Password.RequireDigit = false;
                                            opt.Password.RequireLowercase = false;
                                            opt.Password.RequireUppercase = false;
                                            opt.Password.RequiredLength = 6;
                                            })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Auth/Login");

//add services to container
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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


app.MapAreaControllerRoute(
      name: "areas",
      areaName:"Admin",

      pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
