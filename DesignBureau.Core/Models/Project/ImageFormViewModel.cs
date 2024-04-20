using Microsoft.AspNetCore.Http;

namespace DesignBureau.Core.Models.Project
{
    public class ImageFormViewModel
    {
        public ImageFormViewModel()
        {
            this.UploadedImages = new FormFileCollection();
        }
        public int ProjectId { get; set; }
        public IFormFileCollection UploadedImages { get; set; }
    }
}
