using Master1Tech.Shared.DTOs.FileUpload;
using Microsoft.Extensions.Options;

namespace Master1Tech.Server.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly FileUploadOptions _options;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<FileService> _logger;

        public FileService(
            IOptions<FileUploadOptions> options,
            IWebHostEnvironment environment,
            ILogger<FileService> logger)
        {
            _options = options.Value;
            _environment = environment;
            _logger = logger;
        }

        public async Task<FileUploadResult> SaveFileAsync(IFormFile file, string subfolder = null)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return new FileUploadResult
                    {
                        Success = false,
                        ErrorMessage = "No file provided"
                    };
                }

                // Validate file size
                if (file.Length > _options.MaxFileSize)
                {
                    return new FileUploadResult
                    {
                        Success = false,
                        ErrorMessage = $"File size exceeds maximum allowed size of {_options.MaxFileSize / 1024 / 1024}MB"
                    };
                }

                // Validate file extension
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_options.AllowedExtensions.Contains(extension))
                {
                    return new FileUploadResult
                    {
                        Success = false,
                        ErrorMessage = $"File type '{extension}' is not allowed"
                    };
                }

                // Create upload directory
                var uploadPath = Path.Combine(_environment.WebRootPath, _options.UploadPath);
                if (!string.IsNullOrEmpty(subfolder))
                {
                    uploadPath = Path.Combine(uploadPath, subfolder);
                }

                Directory.CreateDirectory(uploadPath);

                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadPath, fileName);

                // Save file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return relative path for storage
                var relativePath = Path.Combine(_options.UploadPath, subfolder ?? "", fileName)
                    .Replace('\\', '/');

                return new FileUploadResult
                {
                    Success = true,
                    FilePath = relativePath,
                    FileName = file.FileName,
                    FileSize = file.Length
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving file: {FileName}", file?.FileName);
                return new FileUploadResult
                {
                    Success = false,
                    ErrorMessage = "An error occurred while saving the file"
                };
            }
        }

        public async Task<bool> DeleteFileAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    return false;

                var fullPath = Path.Combine(_environment.WebRootPath, filePath.Replace('/', '\\'));

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file: {FilePath}", filePath);
                return false;
            }
        }

        public bool FileExists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            var fullPath = Path.Combine(_environment.WebRootPath, filePath.Replace('/', '\\'));
            return File.Exists(fullPath);
        }

        public string GetFileUrl(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;

            var fullPath = Path.Combine(_environment.WebRootPath, filePath.Replace('/', '\\'));
            if (File.Exists(fullPath))
            {
                return fullPath;
            }
            return $"/{filePath.Replace('\\', '/')}";
        }

        public async Task<FileUploadResult> UpdateFileAsync(IFormFile newFile, string oldFilePath, string subfolder = null)
        {
            var result = await SaveFileAsync(newFile, subfolder);

            if (result.Success && !string.IsNullOrEmpty(oldFilePath))
            {
                // Delete old file (don't wait for it)
                _ = Task.Run(() => DeleteFileAsync(oldFilePath));
            }

            return result;
        }
    }

}
