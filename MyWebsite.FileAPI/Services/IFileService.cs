using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.FileAPI.Services
{
    public interface IFileService
    {
        Task<Result<MyWebsite.FileAPI.Models.FileUploadResult>> UploadFileAsync(IFormFile file);
        FileStreamResult DownloadFile(string fileName);
        Task<Result<bool>> DeleteFileAsync(string fileName);
    }
}
