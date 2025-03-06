using Application.Features.Services.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.Services.Queries;

public class GetServiceById : IRequest<IDataResult<ServiceDto>>
{
    public int Id { get; set; }

    public class GetServiceByIdHandler : IRequestHandler<GetServiceById, IDataResult<ServiceDto>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public GetServiceByIdHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<ServiceDto>> Handle(GetServiceById request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetAsync(x => x.Id == request.Id);
            if (service == null)
                return new ErrorDataResult<ServiceDto>("Service not found");

            var mappedModel = _mapper.Map<ServiceDto>(service);
            return new SuccessDataResult<ServiceDto>(mappedModel);
        }
    }
}