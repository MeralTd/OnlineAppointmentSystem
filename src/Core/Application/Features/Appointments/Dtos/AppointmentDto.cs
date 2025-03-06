using Domain.Entities;
using Domain.Enums.AppointmentEnums;

namespace Application.Features.Appointments.Dtos;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatusEnum Status { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }

    public UserEntity User { get; set; }
    public ServiceEntity Service { get; set; }
}
