using AuthService.Application.Commands.Login;
using AuthService.Application.Commands.Register;
using AuthService.Application.Requests;
using AuthService.Application.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[Route("api/v1/auth")]
[ApiController]
public sealed class AuthController(
    IMapper mapper,
    ISender sender
) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);

        var commandResult = await sender.Send(command);

        var response = mapper.Map<RegisterResponse>(commandResult);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var command = mapper.Map<LoginCommand>(request);

        var commandResult = await sender.Send(command);

        var response = mapper.Map<LoginResponse>(commandResult);

        return Ok(response);
    }
}
