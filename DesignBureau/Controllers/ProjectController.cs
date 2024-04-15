using DesignBureau.Attributes;
using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Project;
using DesignBureau.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using static DesignBureau.Core.Constants.MessageConstants;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DesignBureau.Controllers
{
    public class ProjectController : BaseController
    {
		private readonly IProjectService projectService;
		private readonly IDesignerService designerService;
        public ProjectController(IProjectService projectService, IDesignerService designerService)
        {
            this.projectService = projectService;
			this.designerService = designerService;
        }

        [AllowAnonymous]
		[HttpGet]
        public async Task<IActionResult> All([FromQuery] AllProjectsViewModel model)
        {
			var projects = await projectService.AllProjectsAsync(
                model.Category,
                model.Phase,
                model.Town,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                AllProjectsViewModel.ProjectsPerPage);

			model.TotalProjectsCount = projects.TotalProjectsCount;
			model.Projects = projects.Projects;
			model.Categories = await projectService.AllCategoriesNamesAsync();
			model.Phases = await projectService.AllPhasesNamesAsync();
			model.Towns = await projectService.AllTownsNamesAsync();

            return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> Mine([FromQuery] MyProjectsViewModel model)
		{
			var userId = User.Id();

			if (await designerService.ExistsByUserIdAsync(userId) && User.IsAdmin() == false)
			{
				int designerId = await designerService.GetDesignerIdAsync(userId);

                var projects = await projectService.AllProjectsByDesignerIdAsync(
                        designerId,
                        model.CurrentPage,
						MyProjectsViewModel.HousesPerPage);

                model.TotalProjectsCount = projects.TotalProjectsCount;
                model.Projects = projects.Projects;
            }

			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
		{
			if (await projectService.ExistsByIdAsync(id) == false)
			{
				return BadRequest();
			}

			var model = await projectService.ProjectDetailsByIdAsync(id);

			return View(model);
		}


		[HttpGet]
		[MustBeDesigner]
		public async Task<IActionResult> Add()
		{
			var model = new ProjectFormViewModel
			{
				Categories = await projectService.AllCategoriesAsync(),
				Phases = await projectService.AllPhasesAsync(),
            };

			return View(model);
		}

		[HttpPost]
        [MustBeDesigner]
        public async Task<IActionResult> Add(ProjectFormViewModel model)
		{
			if (await projectService.CategoryExistAsync(model.CategoryId) == false)
			{
				this.ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExist);
			}

            if (await projectService.PhaseExistAsync(model.PhaseId) == false)
            {
                this.ModelState.AddModelError(nameof(model.PhaseId), PhaseDoesNotExist);
            }

            if (!ModelState.IsValid)
			{
				model.Categories = await projectService.AllCategoriesAsync();
				model.Phases = await projectService.AllPhasesAsync();

				return View(model);
			}

			int designerId = await designerService.GetDesignerIdAsync(User.Id());

			int newProjectId = await projectService.CreateAsync(model, designerId);

			return RedirectToAction(nameof(Details), new { id = newProjectId });
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
            if (await projectService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            if (await projectService.HasDesignerWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await projectService.GetProjectFormViewModelByIdAsync(id);

            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(int id, ProjectFormViewModel model)
		{
            if (await projectService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            if (await projectService.HasDesignerWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

			if (await projectService.CategoryExistAsync(model.CategoryId) == false)
			{
                ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExist);
            }

            if (await projectService.PhaseExistAsync(model.PhaseId) == false)
            {
                ModelState.AddModelError(nameof(model.PhaseId), PhaseDoesNotExist);
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await projectService.AllCategoriesAsync();
                model.Phases = await projectService.AllPhasesAsync();

                return View(model);
            }

			await projectService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id = id });
		}


		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (await projectService.ExistsByIdAsync(id) == false)
			{
				return BadRequest();
			}

			if (await projectService.HasDesignerWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var project = await projectService.ProjectToDeleteByIdAsync(id);

			var model = new ProjectServiceModel()
			{
				Id = id,
				Title = project.Title,
				Country = project.Country,
				Town = project.Town,
				MainImageUrl = project.MainImageUrl,
				YearDesigned = project.YearDesigned,
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(ProjectServiceModel model)
		{
			if (await projectService.ExistsByIdAsync(model.Id) == false)
			{
				return BadRequest();
			}

			if (await projectService.HasDesignerWithIdAsync(model.Id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await projectService.DeleteAsync(model.Id);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> AddImages()
		{
			var model = new ImageFormViewModel();

			return View(model);
		}

		[HttpPost]
        public async Task<IActionResult> AddImages(ImageFormViewModel model)
        {


            return RedirectToAction(nameof(Gallery));
        }

		[HttpGet]
        public async Task<IActionResult> Gallery(int id)
        {
            if (await projectService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await projectService.AllImagesByProjectIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Gallery(ProjectGalleryServiceModel model)
        {
			bool galleryChanged = false;

            //if (await projectService.ExistsByIdAsync(model.ProjectId) == false)
            //{
            //    return BadRequest();
            //}

			//if (model.UploadedImages.Count() > 0)
			//{
			//	// add uploaded images urls to database for this projectId
			//	// add uploaded images urls to current model
			//	galleryChanged = true;
   //         }

   //         if (model.DeletedImages.Count() > 0)
			//{
   //             // remove deleted images urls from database for this projectId
   //             // remove deleted images urls to current model
   //             galleryChanged = true;
   //         }

			if (galleryChanged)
			{
				// save database
			}

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImages(IFormFile file)
        {
            bool galleryChanged = false;

            //if (await projectService.ExistsByIdAsync(model.ProjectId) == false)
            //{
            //    return BadRequest();
            //}

            //if (model.UploadedImages.Count() > 0)
            //{
            //	// add uploaded images urls to database for this projectId
            //	// add uploaded images urls to current model
            //	galleryChanged = true;
            //         }

            //         if (model.DeletedImages.Count() > 0)
            //{
            //             // remove deleted images urls from database for this projectId
            //             // remove deleted images urls to current model
            //             galleryChanged = true;
            //         }

            if (galleryChanged)
            {
                // save database
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllGallery([FromQuery] AllProjectsGalleryViewModel model)
        {
            var projects = await projectService.AllProjectsGalleryAsync(
                model.Category,
                model.Sorting,
                model.CurrentPage,
                AllProjectsGalleryViewModel.ProjectsPerPage);

            model.TotalProjectsCount = projects.TotalProjectsCount;
            model.Projects = projects.Projects;
            model.Categories = await projectService.AllCategoriesNamesAsync();

            return View(model);
        }


    }
}
