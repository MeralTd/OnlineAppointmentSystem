using Application.Features.Services.Commands;
using Application.Features.Services.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Services.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ServiceEntity, CreatedServiceDto>().ReverseMap();
        CreateMap<ServiceEntity, CreateService>().ReverseMap();
        CreateMap<ServiceEntity, UpdateService>().ReverseMap();
        CreateMap<ServiceEntity, ServiceDto>().ReverseMap();
    }
}