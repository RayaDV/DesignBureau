using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;

namespace DesignBureau.Core.Services
{
    public class FileService: IFileService
    {
        private readonly IWebHostEnvironment webHostEnv;

        public FileService(IWebHostEnvironment webHostEnv)
        {
            this.webHostEnv = webHostEnv;
        }

        public void CopyFileToRoot(int projectId, IFormFile file, string subDir)
        {
            string path = this.webHostEnv.WebRootPath + $"/img/{subDir}/{projectId}/{file.FileName}";

            if (File.Exists(path))
            {
                return;
            }

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                var bytes = memoryStream.ToArray();

                File.WriteAllBytes(path, bytes);
            }
        }
      
    }
}
