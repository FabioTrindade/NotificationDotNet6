using Microsoft.EntityFrameworkCore;
using NotificationDotNet6.Domain.Repositories;
using NotificationDotNet6.Infra.Contexts;
using NotificationDotNet6.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NotificationDataContext>(options
    => options.UseSqlite(builder.Configuration.GetConnectionString("NotificationConnection"),
    m => m.MigrationsHistoryTable("NotificationMigrations")));

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();


var app = builder.Build();

// Create database end execute migrations on start project
var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
scope.ServiceProvider.GetRequiredService<NotificationDataContext>().Database.Migrate();

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