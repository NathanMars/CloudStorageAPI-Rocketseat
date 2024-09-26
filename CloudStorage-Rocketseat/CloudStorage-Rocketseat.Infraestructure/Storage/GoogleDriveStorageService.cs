using CloudStorage_Rocketseat.Domain.Entities;
using CloudStorage_Rocketseat.Domain.Storage;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;

namespace CloudStorage_Rocketseat.Infraestructure.Storage;
internal class GoogleDriveStorageService : IStorageService
{
    public string Upload(IFormFile file, User user)
    {
        var service = new DriveService();

        var driveFile = new Google.Apis.Drive.v3.Data.File
        {
            Name = file.Name,
            MimeType = file.ContentType,
        };

        var command = service.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);
        command.Fields = "id";

        var response = command.Upload();

        if (response.Status is not Google.Apis.Upload.UploadStatus.Completed or Google.Apis.Upload.UploadStatus.NotStarted)
            throw response.Exception;
        return command.ResponseBody.Id;
    }
}
