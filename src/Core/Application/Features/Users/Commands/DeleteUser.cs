using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using MediatR;

namespace Application.Features.Users.Commands;

public class DeleteUser : IRequest<IResponseResult>
{
    public int Id { get; set; }

    public class DeleteUserHandler : IRequestHandler<DeleteUser, IResponseResult>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IResponseResult> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            try
            {
                var offer = await _userRepository.GetAsync(x => x.Id == request.Id);
                if (offer == null)
                    return new ErrorResult("User not found");


                await _userRepository.RemoveAsync(offer);
                return new SuccessResult("User deleted");
            }
            catch (Exception)
            {
                return new ErrorResult("User not deleted");
            }

        }
    }
}