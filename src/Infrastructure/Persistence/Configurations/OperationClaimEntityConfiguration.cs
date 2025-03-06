using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OperationClaimEntityConfiguration : BaseConfiguration<OperationClaimEntity>
{
    public override void Configure(EntityTypeBuilder<OperationClaimEntity> builder)
    {
        builder.ToTable("OperationClaims");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());

        base.Configure(builder);
    }

    private HashSet<OperationClaimEntity> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaimEntity> seeds =
            new()
            {
                new OperationClaimEntity { Id = ++id, Name = "Admin" },
                new OperationClaimEntity { Id = ++id, Name = "User" }
            };

        return seeds;
    }
}