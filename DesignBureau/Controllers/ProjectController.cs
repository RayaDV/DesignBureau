using DesignBureau.Core.Models.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
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
		public async Task<IActionResult> Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProjectFormViewModel model)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
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
