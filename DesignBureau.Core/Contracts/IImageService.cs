using DesignBureau.Core.Models.Project;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace DesignBureau.Core.Contracts
{
    public interface IImageService
    {
        Task<int> CreateAsync(ImageServiceModel model);
        Task<IEnumerable<int>> CreateRangeAsync(IEnumerable<ImageServiceModel> models);

        void CopyFileToRoot(int projectId, IFormFile file, string path);
    }
}
