using Application.Features.Appointments.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.Appointments.Queries;

public class GetAppointmentById : IRequest<IDataResult<AppointmentDto>>
{
    public int Id { get; set; }

    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentById, IDataResult<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAppointmentByIdHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<AppointmentDto>> Handle(GetAppointmentById request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAsync(x => x.Id == request.Id);
            if (appointment == null)
                return new ErrorDataResult<AppointmentDto>("Appointment not found");

            var mappedModel = _mapper.Map<AppointmentDto>(appointment);
            return new SuccessDataResult<AppointmentDto>(mappedModel);
        }
    }
}
