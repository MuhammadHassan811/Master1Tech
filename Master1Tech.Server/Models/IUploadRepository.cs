using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Server.Models
{
    public interface IUploadRepository
    {
        PagedResult<Upload> GetUploads(string? name, int page);
        Task<Upload?> GetUpload(int Id);
        Task<Upload> AddUpload(Upload upload);
        Task<Upload?> UpdateUpload(Upload upload);
        Task<Upload?> DeleteUpload(int id);
    }
}