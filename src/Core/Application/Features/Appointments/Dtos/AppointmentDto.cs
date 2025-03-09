using Application.Features.Services.Dtos;
using Application.Features.Users.Dtos;
using Domain.Enums.AppointmentEnums;

namespace Application.Features.Appointments.Dtos;

public class AppointmentDto
{
	public int Id { get; set; }
	public DateTime AppointmentDate { get; set; }
	public AppointmentStatusEnum Status { get; set; }
	public int UserId { get; set; }
	public int ServiceId { get; set; }

	public UserDto User { get; set; }
	public ServiceDto Service { get; set; }
}
