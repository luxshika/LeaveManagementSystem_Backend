using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadProfileController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.FirstOrDefault();
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded or file is empty.");
                }

              
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return BadRequest("Invalid file type. Only images are allowed.");
                }

                var folderName = Path.Combine("Resources", "Profiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                // Generate a unique file name to avoid overwriting existing files
                var sanitizedFileName = Path.GetFileNameWithoutExtension(file.FileName).Replace(" ", "_");
                var newFileName = $"{sanitizedFileName}_{Guid.NewGuid()}{fileExtension}";
                var fullPath = Path.Combine(pathToSave, newFileName);
                var baseUri = $"{Request.Scheme}://{Request.Host}";
                var dbPath = Path.Combine(baseUri, folderName, newFileName);

                // Ensure the directory exists
                Directory.CreateDirectory(pathToSave);

                // Save the file
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { dbPath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
