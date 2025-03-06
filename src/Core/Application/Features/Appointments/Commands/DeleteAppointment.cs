using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using MediatR;

namespace Application.Features.Appointments.Commands;

public class DeleteAppointment : IRequest<IResponseResult>
{
    public int Id { get; set; }

    public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointment, IResponseResult>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteAppointmentHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IResponseResult> Handle(DeleteAppointment request, CancellationToken cancellationToken)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAsync(x => x.Id == request.Id);
                if (appointment == null)
                    return new ErrorResult("Appointment not found");

                await _appointmentRepository.RemoveAsync(appointment);
                return new SuccessResult("Appointment deleted");
            }
            catch (Exception)
            {
                return new ErrorResult("Appointment not deleted");
            }

        }
    }
}