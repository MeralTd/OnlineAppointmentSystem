using Application.Features.Users.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Enums.UserEnums;
using MediatR;

namespace Application.Features.Users.Commands;

public class UpdateUser : IRequest<IDataResult<UserDto>>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public UserTypeEnum Type { get; set; }
    public GenderEnum Gender { get; set; }


    public class UpdateUserHandler : IRequestHandler<UpdateUser, IDataResult<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IDataResult<UserDto>> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.Id);
            if (user == null)
                return new ErrorDataResult<UserDto>("User not found");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.IsActive = request.IsActive;
            user.Type = request.Type;
            user.Gender = request.Gender;
            await _userRepository.UpdateAsync(user);

            var mappedModel = _mapper.Map<UserDto>(user);
            return new SuccessDataResult<UserDto>(mappedModel, "User updated");
        }
    }
}