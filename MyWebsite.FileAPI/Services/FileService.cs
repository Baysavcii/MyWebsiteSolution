using Ardalis.Result;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.FileAPI.Services
{
    public class FileService : IFileService
    {
        private readonly string _uploadPath;
        private readonly string _baseUrl;
        public FileService(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _uploadPath = Path.Combine(environment.ContentRootPath, configuration["FileStorage:UploadPath"]);
            _baseUrl = configuration["FileStorage:BaseUrl"];
        }

        public async Task<Result<MyWebsite.FileAPI.Models.FileUploadResult>> UploadFileAsync(IFormFile file)
        {
            const long MaxFileSize = 10 * 1024 * 1024;
            if (file == null || file.Length == 0)
            {
                return Result<MyWebsite.FileAPI.Models.FileUploadResult>.Error("No file provided.");
            }

            if (file.Length > MaxFileSize)
            {
                return Result<MyWebsite.FileAPI.Models.FileUploadResult>.Error("File size exceeds the allowed limit of 10 MB.");
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
            {
                return Result<MyWebsite.FileAPI.Models.FileUploadResult>.Error("File type not allowed.");
            }

            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(_uploadPath, uniqueFileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var result = new Models.FileUploadResult
                {
                    FileName = uniqueFileName,
                    FileUrl = $"{_baseUrl}/{uniqueFileName}",
                    Message = "File uploaded successfully."
                };

                return Result<MyWebsite.FileAPI.Models.FileUploadResult>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<MyWebsite.FileAPI.Models.FileUploadResult>.Error($"Error uploading file: {ex.Message}");
            }
        }

        public FileStreamResult DownloadFile(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            var filePath = Path.Combine(_uploadPath, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }

            var mimeType = "application/octet-stream";
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = fileName
            };
        }

        public async Task<Result<bool>> DeleteFileAsync(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            var filePath = Path.Combine(_uploadPath, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return Result<bool>.Error("File not found.");
            }
            try
            {
                await Task.Run(() => System.IO.File.Delete(filePath));
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Error($"Error deleting file: {ex.Message}");
            }
        }
    }
}
