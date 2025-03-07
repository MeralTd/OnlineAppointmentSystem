using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Enums.AppointmentEnums;
using MediatR;

namespace Application.Features.Appointments.Commands;

public class ChangeAppointmentStatus : IRequest<IResponseResult>
{
    public int Id { get; set; }
    public AppointmentStatusEnum Status { get; set; }

    public class ChangeAppointmentStatusHandler : IRequestHandler<ChangeAppointmentStatus, IResponseResult>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public ChangeAppointmentStatusHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IResponseResult> Handle(ChangeAppointmentStatus request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAsync(x => x.Id == request.Id);
            if (appointment == null)
                return new ErrorResult("Appointment not found");

            appointment.Status = request.Status;
            await _appointmentRepository.UpdateAsync(appointment);

            return new SuccessResult("Appointment status changed");
        }
    }
}
