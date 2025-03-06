using Application.Features.Appointments.Commands;
using Application.Features.Appointments.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Appointments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AppointmentEntity, CreateAppointment>().ReverseMap();
        CreateMap<AppointmentEntity, AppointmentDto>().ReverseMap();
        CreateMap<AppointmentEntity, UpdateAppointment>().ReverseMap();
    }
}