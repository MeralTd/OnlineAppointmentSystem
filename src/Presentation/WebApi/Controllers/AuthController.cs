using Application.Features.Authorizations.Commands;
using Application.Features.Users.Commands;
using Application.Wrappers.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : BaseApiController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResult))]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUser createUser)
    {
        return GetResponseOnlyResult(await Mediator.Send(createUser));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResult))]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
    {
        return GetResponseOnlyResult(await Mediator.Send(loginUser));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IResponseResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResponseResult))]
    [HttpPost]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePassword changePassword)
    {
        return GetResponseOnlyResult(await Mediator.Send(changePassword));
    }

}