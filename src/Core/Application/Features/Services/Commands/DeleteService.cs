using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using MediatR;

namespace Application.Features.Services.Commands;

public class DeleteService : IRequest<IResponseResult>
{
    public int Id { get; set; }

    public class DeleteServiceHandler : IRequestHandler<DeleteService, IResponseResult>
    {
        private readonly IServiceRepository _serviceRepository;

        public DeleteServiceHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IResponseResult> Handle(DeleteService request, CancellationToken cancellationToken)
        {
            try
            {
                var service = await _serviceRepository.GetAsync(x => x.Id == request.Id);
                if (service == null)
                    return new ErrorResult("Service not found");

                await _serviceRepository.RemoveAsync(service);
                return new SuccessResult("Service deleted");
            }
            catch (Exception)
            {
                return new ErrorResult("Service not deleted");
            }

        }
    }
}