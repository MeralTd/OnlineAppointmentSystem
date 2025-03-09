using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Hashing;

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

        builder.HasData(getSeeds());


        base.Configure(builder);
    }


    private HashSet<UserEntity> getSeeds()
    {
        int id = 0;
        string password = "admin123";

        HashingHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);


        HashSet<UserEntity> seeds =
            new()
            {
                new UserEntity {
                    Id = ++id,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@admin.com",
                    PhoneNumber = "1234567890",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IsActive = true,
                    Type = Domain.Enums.UserEnums.UserTypeEnum.Admin

                },


            };

        return seeds;
    }
}
