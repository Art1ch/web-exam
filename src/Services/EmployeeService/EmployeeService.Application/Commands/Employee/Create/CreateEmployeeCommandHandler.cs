using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Commands.Employee.Create;

internal sealed class CreateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IMapper mapper,
    IAvatarService avatarService
) : IRequestHandler<CreateEmployeeCommand, CreateEmployeeCommandResult>
{
    public async Task<CreateEmployeeCommandResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<EmployeeEntity>(request);

        if (request.Avatar != null)
        {
            entity.AvatarUrl = await avatarService.UploadAvatarAsync(request.Avatar, cancellationToken);
        }

        await employeeRepository.CreateAsync(entity, cancellationToken);

        return new CreateEmployeeCommandResult();
    }
}
