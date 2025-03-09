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
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteUserHandler(IUserRepository userRepository, IAppointmentRepository appointmentRepository)
        {
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IResponseResult> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            try
            {
                var offer = await _userRepository.GetAsync(x => x.Id == request.Id);
                if (offer == null)
                    return new ErrorResult("User not found");

                var appointments = await _appointmentRepository.GetAsync(x => x.UserId == request.Id);


                if (appointments != null)
                {
                    await _appointmentRepository.RemoveRangeAsync(appointments);
                }

                await _userRepository.RemoveAsync(offer);
                return new SuccessResult("User and associated appointments deleted");
            }
            catch (Exception)
            {
                return new ErrorResult("User not deleted");
            }

        }
    }
}