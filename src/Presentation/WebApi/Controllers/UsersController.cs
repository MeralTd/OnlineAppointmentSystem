using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries;
using Application.Wrappers.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : BaseApiController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<IEnumerable<UserDto>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<IEnumerable<UserDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return GetResponse(await Mediator.Send(new GetAllUser()));
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<UserDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<UserDto>))]
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetUserById getUserById)
    {
        return GetResponse(await Mediator.Send(getUserById));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IDataResult<CreatedUserDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<CreatedUserDto>))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUser createUser)
    {
        return GetResponseOnlyResultCreated(await Mediator.Send(createUser));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<UserDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<UserDto>))]
    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateUser updateUser)
    {
        return GetResponseOnlyResult(await Mediator.Send(updateUser));
    }



    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResponseResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResponseResult))]
    [HttpPost("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUser deleteUser)
    {
        return GetResponseOnlyResult(await Mediator.Send(deleteUser));
    }



}