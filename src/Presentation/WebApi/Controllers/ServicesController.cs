using Application.Features.Services.Commands;
using Application.Features.Services.Dtos;
using Application.Features.Services.Queries;
using Application.Wrappers.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class ServicesController : BaseApiController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<IEnumerable<ServiceDto>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<IEnumerable<ServiceDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return GetResponse(await Mediator.Send(new GetAllService()));
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<ServiceDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<ServiceDto>))]
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetServiceById getServiceById)
    {
        return GetResponse(await Mediator.Send(getServiceById));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IDataResult<CreatedServiceDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<CreatedServiceDto>))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateService createService)
    {
        return GetResponseOnlyResultCreated(await Mediator.Send(createService));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<ServiceDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<ServiceDto>))]
    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateService updateService)
    {
        return GetResponseOnlyResult(await Mediator.Send(updateService));
    }



    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResponseResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResponseResult))]
    [HttpPost("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteService deleteService)
    {
        return GetResponseOnlyResult(await Mediator.Send(deleteService));
    }
}
