using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Project;
using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Controllers
{

    public class ImageController : Controller
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> AddImages()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImages(ProjectGalleryServiceModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(nameof(Gallery), model);
            //}
            var models = new List<ImageServiceModel>();

            for (int i = 0; i < model.UploadedImages.Count; i++)
            {
                var imageFormFile = model.UploadedImages[i];
                string fileName = imageFormFile.FileName;
                models.Add(new ImageServiceModel()
                {
                    ProjectId = model.ProjectId,
                    ImageUrl = $"/img/Projects/{model.ProjectId}/{fileName}"
                });
            }

            await imageService.CreateRangeAsync(models);

            foreach (var image in model.UploadedImages)
            {
                imageService.CopyFileToRoot(model.ProjectId, image, "Projects");
            }

            return RedirectToAction("Gallery", "Project", new { id = model.ProjectId });
        }
    }
}
