using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserOperationClaimEntityConfiguration : BaseConfiguration<UserOperationClaimEntity>
{
    public override void Configure(EntityTypeBuilder<UserOperationClaimEntity> builder)
    {
        builder.ToTable("UserOperationClaims");
        builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);

        builder.HasOne(x => x.User);
        builder.HasOne(x => x.OperationClaim);

        base.Configure(builder);
    }
}