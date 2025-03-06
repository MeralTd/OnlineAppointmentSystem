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

        builder.HasData(getSeeds());

        base.Configure(builder);
    }

    private HashSet<ServiceEntity> getSeeds()
    {
        int id = 0;
        HashSet<ServiceEntity> seeds =
            new()
            {
                new ServiceEntity { Id = ++id, Name = "Egzoz Gazı Ölçümü" },
                new ServiceEntity { Id = ++id, Name = "Fren Test" },
                new ServiceEntity { Id = ++id, Name = "Far Ayarı" }

            };

        return seeds;
    }
}
