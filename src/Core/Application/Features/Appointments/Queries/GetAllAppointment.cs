using Application.Features.Appointments.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Appointments.Queries;

public class GetAllAppointment : IRequest<IDataResult<IEnumerable<AppointmentDto>>>
{
    public class GetAllAppointmentHandler : IRequestHandler<GetAllAppointment, IDataResult<IEnumerable<AppointmentDto>>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAllAppointmentHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<AppointmentDto>>> Handle(GetAllAppointment request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetAllAsync(include: query => query.Include(a => a.User).Include(a => a.Service));
            if (appointments.Count <= 0)
                return new ErrorDataResult<IEnumerable<AppointmentDto>>("No appointments found");




            var mappedModel = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return new SuccessDataResult<IEnumerable<AppointmentDto>>(mappedModel);
        }
    }
}