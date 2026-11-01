using EmployeeService.Application.Interfaces.Repositories;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Core.Entities;
using MapsterMapper;
using MediatR;

namespace EmployeeService.Application.Commands.Employee.Update;

internal sealed class UpdateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IMapper mapper,
    IAvatarService avatarService
) : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeCommandResult>
{
    public async Task<UpdateEmployeeCommandResult> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<EmployeeEntity>(request);

        if (request.NewAvatar != null)
        {
            var newAvatarUrl = await avatarService.UploadAvatarAsync(request.NewAvatar, cancellationToken);
            entity.AvatarUrl = newAvatarUrl;
        }

        await employeeRepository.UpdateAsync(entity);

        return new UpdateEmployeeCommandResult();
    }
}
