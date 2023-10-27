﻿using BirdFarmShop.Pages;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repositories.IRepository;
using Repositories.Repository;
using Services.IServices;
using Services.Services;
using Services.UnitOfWork;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAuthorization();
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = "Cookies";
//    options.DefaultChallengeScheme = "Google"; // Hoặc tên của nhà cung cấp xác thực khác
//})
//    .AddCookie("Cookies")
//    .AddGoogle("Google", googleOptions =>
//    {
//        // Đọc thông tin Authentication:Google từ appsettings.json
//        IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");

//        // Thiết lập ClientID và ClientSecret để truy cập API google
//        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//        // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
//        googleOptions.CallbackPath = "/LoginGoogleCallBack";

//    });
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IWardRepository, WardRepository>();
builder.Services.AddScoped<IWardService, WardService>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IBirdRepository, BirdRepository>();
builder.Services.AddScoped<IBirdService, BirdService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddRazorPages().AddRazorPagesOptions(options => { options.Conventions.AddPageRoute("/HomePage", ""); });
builder.Services.AddDbContext<BirdFarmShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BirdFarmShop") ?? throw new InvalidOperationException("Connection string 'BirdFarmShop' not found.")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
