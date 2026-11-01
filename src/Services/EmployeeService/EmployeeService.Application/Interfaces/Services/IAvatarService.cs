using Microsoft.AspNetCore.Http;

namespace EmployeeService.Application.Interfaces.Services;

public interface IAvatarService
{
    Task<string?> UploadAvatarAsync(IFormFile avatar, CancellationToken cancellationToken = default);
}
