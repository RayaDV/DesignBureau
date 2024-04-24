using Microsoft.AspNetCore.Http;

namespace DesignBureau.Core.Models.Project
{
    public class ProjectGalleryServiceModel
    {
        public int ProjectId { get; set; }

        public string Title { get; set; } = string.Empty;

        public IFormFileCollection UploadedImages { get; set; } = null!;

        public IEnumerable<string> Gallery { get; set; }
            = new List<string>();
    }
}
