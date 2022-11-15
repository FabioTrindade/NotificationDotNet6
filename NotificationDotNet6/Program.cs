﻿using Microsoft.EntityFrameworkCore;
using NotificationDotNet6.Infra.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NotificationDataContext>(options
    => options.UseSqlite(builder.Configuration.GetConnectionString("NotificationConnection"),
    m => m.MigrationsHistoryTable("NotificationMigrations")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

