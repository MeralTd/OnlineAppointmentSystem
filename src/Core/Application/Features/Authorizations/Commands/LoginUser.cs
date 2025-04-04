using Application.Features.Authorizations.Dtos;
using Application.Features.Users.Dtos;
using Application.Interfaces.Repository;
using Application.Pipelines.Transaction;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Security.Hashing;
using Security.JWT;

namespace Application.Features.Authorizations.Commands;

public class LoginUser : IRequest<IDataResult<LoggedResponseDto>>, ITransactionalRequest
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class LoginUserHandler : IRequestHandler<LoginUser, IDataResult<LoggedResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public LoginUserHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<LoggedResponseDto>> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Email == request.Email && x.IsActive == true);
            if (user == null)
                return new ErrorDataResult<LoggedResponseDto>("User not found");

            if (!HashingHelper.VerifyPasswordHash(request.Password, user!.PasswordHash, user.PasswordSalt))
                return new ErrorDataResult<LoggedResponseDto>("Email or password is wrong");




            IList<OperationClaimEntity> operationClaims = await _userOperationClaimRepository
                .Query()
                .Where(p => p.UserId == user.Id)
                .Select(p => new OperationClaimEntity { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
                .ToListAsync(cancellationToken: cancellationToken);

            var accessToken = _tokenHelper.CreateToken(user, operationClaims);

            var userDto = _mapper.Map<UserDto>(user);


            LoggedResponseDto loggedResponse = new();
            loggedResponse.AccessToken = accessToken;
            loggedResponse.User = userDto;
            return new SuccessDataResult<LoggedResponseDto>(loggedResponse);
        }
    }
}