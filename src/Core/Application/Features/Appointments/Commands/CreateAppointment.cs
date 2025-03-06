using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Entities;
using Domain.Enums.AppointmentEnums;
using MediatR;

namespace Application.Features.Appointments.Commands;

public class CreateAppointment : IRequest<IDataResult<AppointmentEntity>>
{
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatusEnum Status { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }

    public class CreateAppointmentHandler : IRequestHandler<CreateAppointment, IDataResult<AppointmentEntity>>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IDataResult<AppointmentEntity>> Handle(CreateAppointment request, CancellationToken cancellationToken)
        {
            var appointment = _mapper.Map<AppointmentEntity>(request);

            await _appointmentRepository.AddAsync(appointment);

            var mappedModel = _mapper.Map<AppointmentEntity>(appointment);
            return new SuccessDataResult<AppointmentEntity>(mappedModel);
        }
    }
}
