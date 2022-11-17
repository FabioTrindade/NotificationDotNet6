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
        entityBuilder.Property(t => t.Header).IsRequired().HasColumnType("TEXT");
        entityBuilder.Property(t => t.Body).IsRequired().HasColumnType("TEXT");
        entityBuilder.Property(t => t.IsRead).IsRequired().HasColumnType("BIT").HasDefaultValueSql("0");
        entityBuilder.Property(t => t.Url).IsRequired().HasColumnType("TEXT");

        entityBuilder.HasOne(u => u.User)
            .WithMany(n => n.Notifications)
            .HasForeignKey(fk => fk.FromUserId)
            .HasForeignKey(fk => fk.ToUserId)
            .HasConstraintName("Fk_User_Notifications_Id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}