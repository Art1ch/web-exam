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
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public AuthController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        var commandResult = await _sender.Send(command);

        var response = _mapper.Map<RegisterResponse>(commandResult);

        return response;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);

        var commandResult = await _sender.Send(command);

        var response = _mapper.Map<LoginResponse>(commandResult);

        return response;
    }
}
