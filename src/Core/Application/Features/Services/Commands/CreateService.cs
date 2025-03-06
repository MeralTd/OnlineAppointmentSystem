using Application.Features.Services.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Services.Commands;

public class CreateService : IRequest<IDataResult<CreatedServiceDto>>
{
    public string Name { get; set; }

    public class CreateServiceHandler : IRequestHandler<CreateService, IDataResult<CreatedServiceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceHandler(IMapper mapper, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<IDataResult<CreatedServiceDto>> Handle(CreateService request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<ServiceEntity>(request);
            await _serviceRepository.AddAsync(service);

            var mappedModel = _mapper.Map<CreatedServiceDto>(service);
            return new SuccessDataResult<CreatedServiceDto>(mappedModel);
        }
    }
}