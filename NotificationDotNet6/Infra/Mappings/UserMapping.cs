using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationDotNet6.Domain.Entities;
using static NotificationDotNet6.Extensions.ModelBuilderExtensions;

namespace NotificationDotNet6.Infra.Mappings;

internal class UserMapping : DbEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> entityBuilder)
    {
        entityBuilder.ToTable("Users");
        entityBuilder.HasKey(t => t.Id).HasName("Pk_Users_Id");
        entityBuilder.Property(t => t.CreatedAt).IsRequired().HasColumnType("DATETIME");
        entityBuilder.Property(t => t.UpdatedAt).HasColumnType("DATETIME");
        entityBuilder.Property(t => t.Active).IsRequired().HasColumnType("BIT").HasDefaultValueSql("1");
        entityBuilder.Property(t => t.Name).HasMaxLength(200).HasColumnType("VARCHAR(200)");

        entityBuilder.HasIndex(t => t.Name).IsUnique().HasName("Ux_Users_Name");
    }
}