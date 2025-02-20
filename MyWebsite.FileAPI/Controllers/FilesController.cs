using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.FileAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace MyWebsite.FileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        [Authorize]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Only .jpg, .jpeg, .png, and .pdf files are allowed.");
            }

            var result = await _fileService.UploadFileAsync(file);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("download/{fileName}")]
        [Authorize]
        public IActionResult Download(string fileName)
        {
            var fileStreamResult = _fileService.DownloadFile(fileName);

            if (fileStreamResult == null)
            {
                return NotFound("File not found.");
            }

            return fileStreamResult;
        }

        [HttpDelete("delete/{fileName}")]
        [Authorize(Policy = "AdminOnly")] 
        public async Task<IActionResult> Delete(string fileName)
        {
            var result = await _fileService.DeleteFileAsync(fileName);

            if (result.IsSuccess)
            {
                return Ok("File deleted successfully.");
            }

            return NotFound(result.Errors);
        }
    }
}
