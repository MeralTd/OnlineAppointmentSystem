using Application.Features.Services.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.Services.Commands;

public class UpdateService : IRequest<IDataResult<ServiceDto>>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateServiceHandler : IRequestHandler<UpdateService, IDataResult<ServiceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public UpdateServiceHandler(IMapper mapper, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<IDataResult<ServiceDto>> Handle(UpdateService request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetAsync(x => x.Id == request.Id);
            if (service == null)
                return new ErrorDataResult<ServiceDto>("Service not found");

            service.Name = request.Name;

            await _serviceRepository.UpdateAsync(service);

            var mappedModel = _mapper.Map<ServiceDto>(service);
            return new SuccessDataResult<ServiceDto>(mappedModel, "Service updated");
        }
    }
}