using Microsoft.AspNetCore.Mvc;
using CloudStorage.Application.UseCases.Users.UploadProfilePic;

namespace CloudStorage.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage([FromServices] IUploadProfilePicUseCase useCase, IFormFile file)
    {
        useCase.Execute(file);

        return Created();
    }
}
