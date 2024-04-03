using DesignBureau.Attributes;
using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Infrastructure.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static DesignBureau.Core.Constants.MessageConstants;

namespace DesignBureau.Controllers
{
    [Authorize]
	public class DesignerController : Controller
	{
		private readonly IDesignerService designerService;
        public DesignerController(IDesignerService designerService)
        {
			this.designerService = designerService;	
        }

        [HttpGet]
		[NotDesigner]
		public async Task<IActionResult> Create()
		{
			var disciplines = await this.designerService.AllDisciplinesAsync();

			var model = new DesignerFormViewModel()
			{
				Disciplines = disciplines
			};

			return View(model);
		}

		[HttpPost]
        [NotDesigner]
        public async Task<IActionResult> Create(DesignerFormViewModel model)
		{
			if (await designerService.ExistsByEmailAsync(model.Email))
			{
				ModelState.AddModelError(nameof(model.Email), EmailExists);
			}

            if (await designerService.DisciplineExistsAsync(model.DisciplineId) == false)
            {
                ModelState.AddModelError(nameof(model.DisciplineId), DisciplineNotExists);
            }

            if (!ModelState.IsValid)
            {
                model.Disciplines = await designerService.AllDisciplinesAsync();

                return View(model);
            }

			var pass = PasswordGenerator.Generate();
			var passHash = PasswordGenerator.GetHash(pass);

			var user = new IdentityUser()
			{
				Email = model.Email,
				PasswordHash = passHash
			};

			int userId = await designerService.GetDesignerIdAsync(User.Id());

			//int newDesignerId = await designerService.CreateAsync(model, userId);

            return RedirectToAction(nameof(ProjectController.All), "Project");
		}
	}
}
