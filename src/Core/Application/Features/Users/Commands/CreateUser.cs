using Application.Features.Users.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Entities;
using Domain.Enums.UserEnums;
using MediatR;
using Security.Hashing;

namespace Application.Features.Users.Commands;

public class CreateUser : IRequest<IDataResult<CreatedUserDto>>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public required UserTypeEnum Type { get; set; }
    public GenderEnum Gender { get; set; }

    public class CreateUserHandler : IRequestHandler<CreateUser, IDataResult<CreatedUserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IDataResult<CreatedUserDto>> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var userControl = await _userRepository.GetAsync(x => x.Email == request.Email);
            if (userControl != null)
                return new ErrorDataResult<CreatedUserDto>("A user with this email address already exists");


            var user = _mapper.Map<UserEntity>(request);
            HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userRepository.AddAsync(user);

            var mappedModel = _mapper.Map<CreatedUserDto>(user);
            return new SuccessDataResult<CreatedUserDto>(mappedModel);
        }
    }
}