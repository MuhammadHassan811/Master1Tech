using Master1Tech.Shared.DTOs.FileUpload;

namespace Master1Tech.Server.Services.FileService
{
    public interface IFileService
    {
        Task<FileUploadResult> SaveFileAsync(IFormFile file, string subfolder = null);
        Task<bool> DeleteFileAsync(string filePath);
        bool FileExists(string filePath);
        string GetFileUrl(string filePath);
        Task<FileUploadResult> UpdateFileAsync(IFormFile newFile, string oldFilePath, string subfolder = null);
    }
}
