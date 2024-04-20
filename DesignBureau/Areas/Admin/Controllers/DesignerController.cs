using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Admin.Designer;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using static DesignBureau.Core.Constants.MessageConstants;

namespace DesignBureau.Areas.Admin.Controllers
{
    public class DesignerController : AdminBaseController
    {
        private readonly IDesignerService designerService;
        private readonly IUserService userService;
        public DesignerController(IDesignerService designerService, IUserService userService)
        {
            this.designerService = designerService;
            this.userService = userService;
        }

        [HttpGet]
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
        public async Task<IActionResult> Add(DesignerFormViewModel model)
        {
            if (await designerService.ExistsByEmailAsync(model.Email))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), EmailExists);
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

            var userModel = new UserServiceModel()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            string id = await userService.CreateAsync(userModel);

            await designerService.CreateAsync(model, id);

            TempData[UserMessageSuccess] = "You have successfully added a new designer";

            return RedirectToAction(nameof(DesignBureau.Controllers.DesignerController.Team), new { Area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await designerService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await designerService.GetDesignerFormViewModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DesignerFormViewModel model)
        {
            if (await designerService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            if (await designerService.DisciplineExistsAsync(model.DisciplineId) == false)
            {
                ModelState.AddModelError(nameof(model.DisciplineId), DisciplineDoesNotExist);
            }

            if (ModelState.IsValid == false)
            {
                model.Disciplines = await designerService.AllDisciplinesAsync();

                return View(model);
            }

            await designerService.EditAsync(id, model);

            TempData[UserMessageSuccess] = "You have successfully edited a designer";

            return RedirectToAction(nameof(DesignBureau.Controllers.DesignerController.Team), new { Area = ""});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await designerService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var designer = await designerService.DesignerToDeleteByIdAsync(id);

            var model = new DesignerDetailsServiceModel()
            {
                Id = id,
                DesignerImageUrl = designer.DesignerImageUrl,
                DesignExperience = designer.DesignExperience,
                ProjectsCount = designer.ProjectsCount,
                Discipline = designer.Discipline,
                FullName = designer.FullName,
                PhoneNumber = designer.PhoneNumber,
                Email = designer.Email,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DesignerDetailsServiceModel model)
        {
            if (await designerService.ExistsByIdAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await designerService.DeleteAsync(model.Id);

            TempData[UserMessageSuccess] = "You have successfully deleted the designer";

            return RedirectToAction(nameof(DesignBureau.Controllers.DesignerController.Team), new { Area = "" });
        }
    }
}
