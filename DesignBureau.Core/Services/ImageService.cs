using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;

namespace DesignBureau.Core.Services
{
    public class ImageService: IImageService
    {
        private readonly IRepository repository;
        private readonly IWebHostEnvironment webHostEnv;

        public ImageService(IRepository repository, IWebHostEnvironment webHostEnv)
        {
            this.repository = repository;
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



        public async Task<int> CreateAsync(ImageServiceModel model)
        {
            var image = new Image
            {
                ProjectId = model.ProjectId,
                ImageUrl = model.ImageUrl,
            };
            
            await repository.AddAsync<Image>(image);
            await repository.SaveChangesAsync();

            return image.Id;
        }

        public async Task<IEnumerable<int>> CreateRangeAsync(IEnumerable<ImageServiceModel> models)
        {
            var images = new List<Image>();

            foreach (var model in models)
            {
                images.Add(new Image
                {
                    ProjectId = model.ProjectId,
                    ImageUrl = model.ImageUrl,
                });
            }
            
            await repository.AddRangeAsync<Image>(images);
            await repository.SaveChangesAsync();

            return images.Select(i => i.Id);
        }
    }
}
