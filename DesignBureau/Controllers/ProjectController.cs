﻿using DesignBureau.Attributes;
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
        public async Task<IActionResult> All([FromQuery] AllProjectsViewModel model)
        {
			var projects = await projectService.AllProjectsAsync(
                model.Category,
                model.Phase,
                model.Town,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                AllProjectsViewModel.HousesPerPage);

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

			if (await designerService.ExistsByIdAsync(userId) && User.IsAdmin() == false)
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
			var model = new ProjectDetailsServiceModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id, ProjectDetailsServiceModel model)
		{
			return RedirectToAction(nameof(All));
		}

	}
}
