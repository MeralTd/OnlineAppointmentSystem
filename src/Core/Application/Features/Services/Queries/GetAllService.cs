using Application.Features.Services.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.Services.Queries;

public class GetAllService : IRequest<IDataResult<IEnumerable<ServiceDto>>>
{
    public class GetAllServiceHandler : IRequestHandler<GetAllService, IDataResult<IEnumerable<ServiceDto>>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public GetAllServiceHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<ServiceDto>>> Handle(GetAllService request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetAllAsync();
            if (services.Count <= 0)
                return new ErrorDataResult<IEnumerable<ServiceDto>>("No services found");

            var mappedModel = _mapper.Map<IEnumerable<ServiceDto>>(services);
            return new SuccessDataResult<IEnumerable<ServiceDto>>(mappedModel);
        }
    }
}