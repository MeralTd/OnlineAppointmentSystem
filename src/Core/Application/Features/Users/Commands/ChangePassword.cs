using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using MediatR;
using Security.Hashing;

namespace Application.Features.Users.Commands;

public class ChangePassword : IRequest<IResponseResult>
{
    public int UserId { get; set; }
    public string ExPassword { get; set; }
    public string Password { get; set; }

    public class ChangePasswordHandler : IRequestHandler<ChangePassword, IResponseResult>
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IResponseResult> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.UserId);
            if (user == null)
                return new ErrorResult("User Not Found");

            if (!HashingHelper.VerifyPasswordHash(request.ExPassword, user!.PasswordHash, user.PasswordSalt))
                return new ErrorResult("Ex Password is wrong");

            HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userRepository.UpdateAsync(user);
            return new SuccessResult("Password Updated");
        }
    }
}