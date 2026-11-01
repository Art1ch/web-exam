using AuthService.Application.Abstractions;
using AuthService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace AuthService.Application.Commands.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IMapper mapper, IAuthService authService)
    {
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.RegisterAsync(request, cancellationToken);

        var commandResult = _mapper.Map<RegisterCommandResult>(authResult);

        return commandResult;
    }
}
