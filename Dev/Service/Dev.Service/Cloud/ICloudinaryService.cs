using Microsoft.AspNetCore.Http;

namespace Dev.Service.Cloud
{
    public interface ICloudinaryService
    {
        Task<Dictionary<string, object>> UploadFile(IFormFile file);
    }
}