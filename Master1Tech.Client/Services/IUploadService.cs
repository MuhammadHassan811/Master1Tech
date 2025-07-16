using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;

namespace Master1Tech.Client.Services
{
    public interface IUploadService
    {
        Task<PagedResult<Upload>> GetUploads(string name, string page);
        Task<Upload> GetUpload(int id);

        Task DeleteUpload(int id);

        Task AddUpload(Upload upload);

        Task UpdateUpload(Upload upload);
    }
}