using Microsoft.AspNetCore.Mvc;
using CloudStorage.Application.UseCases.Users.UploadProfilePic;

namespace CloudStorage.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage(IFormFile file)
    {
        var useCase = new UploadProfilePicUseCase();
        
        useCase.Execute(file);

        return Created();
    }
}
