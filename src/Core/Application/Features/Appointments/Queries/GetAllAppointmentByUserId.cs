using Application.Features.Appointments.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Appointments.Queries;

public class GetAllAppointmentByUserId : IRequest<IDataResult<IEnumerable<AppointmentDto>>>
{
    public int UserId { get; set; }

    public class GetAllAppointmentByUserIdHandler : IRequestHandler<GetAllAppointmentByUserId, IDataResult<IEnumerable<AppointmentDto>>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAllAppointmentByUserIdHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<AppointmentDto>>> Handle(GetAllAppointmentByUserId request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetAllAsync(filter:x=>x.UserId == request.UserId, include: query => query.Include(a => a.User).Include(a => a.Service));
            if (appointments.Count <= 0)
                return new ErrorDataResult<IEnumerable<AppointmentDto>>("No appointments found");




            var mappedModel = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return new SuccessDataResult<IEnumerable<AppointmentDto>>(mappedModel);
        }
    }
}