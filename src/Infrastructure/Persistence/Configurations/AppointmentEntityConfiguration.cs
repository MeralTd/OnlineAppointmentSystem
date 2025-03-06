using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppointmentEntityConfiguration : BaseConfiguration<AppointmentEntity>
{
    public override void Configure(EntityTypeBuilder<AppointmentEntity> builder)
    {
        builder.ToTable("Appointments");
        builder.Property(x => x.AppointmentDate).HasColumnName("AppointmentDate").IsRequired();
        builder.Property(x => x.Status).HasColumnName("Status").IsRequired();

        builder.HasOne(a => a.User)
            .WithMany(u => u.Appointments)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Service)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        base.Configure(builder);
    }
}