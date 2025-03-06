using Application.Features.Authorizations.Commands;
using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserEntity, CreatedUserDto>().ReverseMap();
        CreateMap<UserEntity, CreateUser>().ReverseMap();
        CreateMap<UserEntity, UpdateUser>().ReverseMap();
        CreateMap<UserEntity, UserDto>().ReverseMap();
        CreateMap<UserEntity, RegisterUser>().ReverseMap();


    }
}