using Microsoft.AspNetCore.Http;

namespace DesignBureau.Core.Contracts
{
    public interface IFileService
    {
        void CopyFileToRoot(int projectId, IFormFile file, string path);
    }
}
