using Microsoft.AspNetCore.Http;

namespace CloudStorage.Application.UseCases.Users.UploadProfilePic
{
    public interface IUploadProfilePicUseCase
    {
        public void Execute(IFormFile file);
    }
}
