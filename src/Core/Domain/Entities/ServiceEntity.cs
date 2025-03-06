using Domain.Common;

namespace Domain.Entities;

public class ServiceEntity : BaseEntity
{
    public string Name { get; set; }
    public ICollection<AppointmentEntity> Appointments { get; set; }

}
