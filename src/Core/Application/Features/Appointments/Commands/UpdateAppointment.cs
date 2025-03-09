using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Entities;
using Domain.Enums.AppointmentEnums;
using MediatR;

namespace Application.Features.Appointments.Commands;

public class UpdateAppointment : IRequest<IResponseResult>
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatusEnum Status { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }

    public class UpdateAppointmentHandler : IRequestHandler<UpdateAppointment, IResponseResult>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public UpdateAppointmentHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IResponseResult> Handle(UpdateAppointment request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAsync(x => x.Id == request.Id);
            if (appointment == null)
                return new ErrorResult("Appointment not found");

            appointment = _mapper.Map<AppointmentEntity>(request);
            await _appointmentRepository.UpdateAsync(appointment);
            return new SuccessResult("Appointment updated");
        }
    }
}