using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserEntityConfiguration : BaseConfiguration<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
        builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(15).IsRequired();
        builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(x => x.Type).HasColumnName("Type").IsRequired();
        builder.Property(x => x.Gender).HasColumnName("Gender").IsRequired(); ;

        builder.HasMany(u => u.UserOperationClaims);

        base.Configure(builder);
    }
}
