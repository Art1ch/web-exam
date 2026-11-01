using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EmployeeService.Application.Interfaces.Services;
using EmployeeService.Infrastructure.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EmployeeService.Infrastructure.Implementations.Services;

internal sealed class CloudinaryAvatarService : IAvatarService
{
    private readonly Cloudinary _cloudinary;
    private readonly CloudinarySettings _cloudinarySettings;

    public CloudinaryAvatarService(IOptions<CloudinarySettings> options)
    {
        _cloudinarySettings = options.Value;

        var account = new Account(
            _cloudinarySettings.AccountName,
            _cloudinarySettings.ApiKey,
            _cloudinarySettings.ApiSecret
        );
        _cloudinary = new Cloudinary(account);
    }

    public async Task<string?> UploadAvatarAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        if (file == null || file.Length == 0)
            return null;

        using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, stream),
            Folder = _cloudinarySettings.FolderName,
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams, cancellationToken);

        return uploadResult.SecureUrl?.ToString();
    }
}
