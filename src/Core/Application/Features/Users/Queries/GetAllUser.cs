using Application.Features.Users.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries;

public class GetAllUser : IRequest<IDataResult<IEnumerable<UserDto>>>
{
    public class GetAllUserHandler : IRequestHandler<GetAllUser, IDataResult<IEnumerable<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<UserDto>>> Handle(GetAllUser request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            if (users.Count <= 0)
                return new ErrorDataResult<IEnumerable<UserDto>>("No users found");

            var mappedModel = _mapper.Map<IEnumerable<UserDto>>(users);
            return new SuccessDataResult<IEnumerable<UserDto>>(mappedModel);
        }
    }
}