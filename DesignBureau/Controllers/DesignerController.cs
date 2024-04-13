using DesignBureau.Attributes;
using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DesignBureau.Core.Constants.MessageConstants;

namespace DesignBureau.Controllers
{
	public class DesignerController : BaseController
	{
		private readonly IDesignerService designerService;
		private readonly IUserService userService;
        public DesignerController(IDesignerService designerService, IUserService userService)
        {
			this.designerService = designerService;
			this.userService = userService;
        }

        [HttpGet]
		[NotDesigner]
		public async Task<IActionResult> Add()
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
        public async Task<IActionResult> Add(DesignerFormViewModel model)
		{
			if (await designerService.ExistsByEmailAsync(model.Email))
			{
				ModelState.AddModelError(nameof(model.Email), EmailExists);
			}

            if (await designerService.ExistsByPhoneNumberAsync(model.Email))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneNumberExists);
            }

            if (await designerService.DisciplineExistsAsync(model.DisciplineId) == false)
            {
                ModelState.AddModelError(nameof(model.DisciplineId), DisciplineDoesNotExist);
            }

			if (!ModelState.IsValid)
			{
				model.Disciplines = await designerService.AllDisciplinesAsync();

				return View(model);
			}

			var userModel = new RegisterUserViewModel()
			{
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
			};

			string id = await userService.CreateAsync(userModel);

            await designerService.CreateAsync(model, id);

			return RedirectToAction(nameof(ProjectController.All), "Project");
		}
	}
}
