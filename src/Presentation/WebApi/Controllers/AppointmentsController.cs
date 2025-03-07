using Application.Features.Appointments.Commands;
using Application.Features.Appointments.Dtos;
using Application.Features.Appointments.Queries;
using Application.Wrappers.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AppointmentsController : BaseApiController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<IEnumerable<AppointmentDto>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<IEnumerable<AppointmentDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return GetResponse(await Mediator.Send(new GetAllAppointment()));
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AppointmentDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<AppointmentDto>))]
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetAppointmentById getAppointmentById)
    {
        return GetResponse(await Mediator.Send(getAppointmentById));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IDataResult<AppointmentDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<AppointmentDto>))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointment createAppointment)
    {
        return GetResponseOnlyResultCreated(await Mediator.Send(createAppointment));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AppointmentDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<AppointmentDto>))]
    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateAppointment updateAppointment)
    {
        return GetResponseOnlyResult(await Mediator.Send(updateAppointment));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AppointmentDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<AppointmentDto>))]
    [HttpPost]
    public async Task<IActionResult> ChangeStatus([FromBody] ChangeAppointmentStatus changeAppointment)
    {
        return GetResponseOnlyResult(await Mediator.Send(changeAppointment));
    }


    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResponseResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResponseResult))]
    [HttpPost("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteAppointment deleteAppointment)
    {
        return GetResponseOnlyResult(await Mediator.Send(deleteAppointment));
    }
}
