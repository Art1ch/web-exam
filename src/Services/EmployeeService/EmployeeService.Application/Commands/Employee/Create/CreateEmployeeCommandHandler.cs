using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Commands.Employee.Create;

internal sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeCommandResult>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly IAvatarService _avatarService;

    public CreateEmployeeCommandHandler(
        IEmployeeRepository employeeRepository,
        IMapper mapper,
        IAvatarService avatarService
    )
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _avatarService = avatarService;
    }

    public async Task<CreateEmployeeCommandResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<EmployeeEntity>(request);

        if (request.Avatar != null)
        {
            entity.AvatarUrl = await _avatarService.UploadAvatarAsync(request.Avatar, cancellationToken);
        }

        await _employeeRepository.CreateAsync(entity, cancellationToken);

        return new CreateEmployeeCommandResult();
    }
}
