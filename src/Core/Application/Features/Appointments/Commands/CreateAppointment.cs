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
    public int UserId { get; set; }
    public int ServiceId { get; set; }

    public class CreateAppointmentHandler : IRequestHandler<CreateAppointment, IDataResult<AppointmentEntity>>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IServiceRepository _serviceRepository;

        public CreateAppointmentHandler(IMapper mapper, IAppointmentRepository appointmentRepository, IUserRepository userRepository, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<IDataResult<AppointmentEntity>> Handle(CreateAppointment request, CancellationToken cancellationToken)
        {
            var appointment = _mapper.Map<AppointmentEntity>(request);
            appointment.Status = AppointmentStatusEnum.Waiting;
            await _appointmentRepository.AddAsync(appointment);


            appointment.User = await _userRepository.GetAsync(x => x.Id == request.UserId);
            appointment.Service = await _serviceRepository.GetAsync(x => x.Id == request.ServiceId);

            var mappedModel = _mapper.Map<AppointmentEntity>(appointment);

            return new SuccessDataResult<AppointmentEntity>(mappedModel);
        }
    }
}
