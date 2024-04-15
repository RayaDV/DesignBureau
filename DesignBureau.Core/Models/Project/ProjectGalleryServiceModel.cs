using Microsoft.AspNetCore.Http;

namespace DesignBureau.Core.Models.Project
{
    public class ProjectGalleryServiceModel
    {
        public int ProjectId { get; set; }

        public string Title { get; set; } = string.Empty;

        public IFormFile? UploadedImages { get; set; }

        public IFormFile? DeletedImages { get; set; }

        public IEnumerable<ImageServiceModel> Gallery { get; set; }
            = new List<ImageServiceModel>();
    }
}
