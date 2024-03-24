using DesignBureau.Core.Models.Designer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Controllers
{
	[Authorize]
	public class DesignerController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var model = new CreateDesignerFormModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateDesignerFormModel model)
		{
			return RedirectToAction(nameof(ProjectController.All), "Projects");
		}
	}
}
