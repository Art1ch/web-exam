using AuthService.Application.Abstractions;
using AuthService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace AuthService.Application.Commands.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public LoginCommandHandler(IMapper mapper, IAuthService authService)
    {
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.LoginAsync(request, cancellationToken);

        var commandResult = _mapper.Map<LoginCommandResult>(authResult);

        return commandResult;
    }
}