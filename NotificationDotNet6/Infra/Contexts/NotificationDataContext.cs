using Microsoft.EntityFrameworkCore;
using NotificationDotNet6.Domain.Entities;
using NotificationDotNet6.Extensions;
using NotificationDotNet6.Infra.Mappings;

namespace NotificationDotNet6.Infra.Contexts;

public class NotificationDataContext : DbContext
{
    private readonly IConfiguration _configuration;

	public NotificationDataContext()
	{
	}

	public NotificationDataContext(DbContextOptions options) : base (options)
	{
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Notification> Notifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite(_configuration.GetConnectionString("NotificationConnection"),
                x => x.MigrationsHistoryTable("NotificationMigrations"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.AddConfiguration(new UserMapping());
        modelBuilder.AddConfiguration(new NotificationMapping());
    }
}