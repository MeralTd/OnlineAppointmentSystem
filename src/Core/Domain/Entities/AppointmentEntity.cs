using Domain.Common;
using Domain.Enums.AppointmentEnums;

namespace Domain.Entities;

public class AppointmentEntity : BaseEntity
{
    public DateTime AppointmentDate { get; set; };
    public AppointmentStatusEnum Status { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }

    public UserEntity User { get; set; }
    public ServiceEntity Service { get; set; }
}