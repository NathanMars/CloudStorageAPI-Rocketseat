using CloudStorage_Rocketseat.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CloudStorage_Rocketseat.Domain.Storage;
public interface IStorageService
{
    string Upload(IFormFile file, User user);
}
