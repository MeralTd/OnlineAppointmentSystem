using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ServiceEntityConfiguration : BaseConfiguration<ServiceEntity>
{
    public override void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.ToTable("Services");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();


        base.Configure(builder);
    }
}
