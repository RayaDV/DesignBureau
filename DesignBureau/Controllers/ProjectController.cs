using DesignBureau.Attributes;
using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static DesignBureau.Core.Constants.MessageConstants;

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
        public async Task<IActionResult> All()
        {
            var model = new AllProjectsViewModel();
            return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			var model = new AllProjectsViewModel();
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = new ProjectDetailsViewModel();
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
			var model = new ProjectFormViewModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, ProjectFormViewModel model)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
		}


		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var model = new ProjectDetailsViewModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id, ProjectDetailsViewModel model)
		{
			return RedirectToAction(nameof(All));
		}

	}
}
