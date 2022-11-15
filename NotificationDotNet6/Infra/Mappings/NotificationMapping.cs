using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationDotNet6.Domain.Entities;
using static NotificationDotNet6.Extensions.ModelBuilderExtensions;

namespace NotificationDotNet6.Infra.Mappings;

internal class NotificationMapping : DbEntityConfiguration<Notification>
{
    public override void Configure(EntityTypeBuilder<Notification> entityBuilder)
    {
        entityBuilder.ToTable("Notifications");
        entityBuilder.HasKey(t => t.Id).HasName("Pk_Notifications_Id");
        entityBuilder.Property(t => t.CreatedAt).IsRequired().HasColumnType("DATETIME");
        entityBuilder.Property(t => t.UpdatedAt).HasColumnType("DATETIME");
        entityBuilder.Property(t => t.Active).IsRequired().HasColumnType("BIT").HasDefaultValueSql("1");
        entityBuilder.Property(t => t.Header).IsRequired().HasColumnType("VARCHAR(MAX)");
        entityBuilder.Property(t => t.Body).IsRequired().HasColumnType("VARCHAR(MAX)");
        entityBuilder.Property(t => t.IsRead).IsRequired().HasColumnType("BIT").HasDefaultValueSql("0");
        entityBuilder.Property(t => t.Url).IsRequired().HasColumnType("VARCHAR(MAX)");

        entityBuilder.HasOne(fu => fu.FromUser)
            .WithMany(n => n.Notifications)
            .HasForeignKey(fk => fk.FromUserId)
            .OnDelete(DeleteBehavior.Restrict);

        entityBuilder.HasOne(to => to.ToUser)
            .WithMany(n => n.Notifications)
            .HasForeignKey(fk => fk.ToUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}