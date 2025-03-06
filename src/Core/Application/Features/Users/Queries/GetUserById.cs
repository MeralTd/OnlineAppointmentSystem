using Application.Features.Users.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries;

public class GetUserById : IRequest<IDataResult<UserDto>>
{
    public int Id { get; set; }

    public class GetUserByIdHandler : IRequestHandler<GetUserById, IDataResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserDto>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.Id);
            if (user == null)
                return new ErrorDataResult<UserDto>("User not found");

            var mappedModel = _mapper.Map<UserDto>(user);
            return new SuccessDataResult<UserDto>(mappedModel);
        }
    }
}