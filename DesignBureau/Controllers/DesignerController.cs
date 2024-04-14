using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Designer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Controllers
{
    public class DesignerController : BaseController
	{
		private readonly IDesignerService designerService;
        public DesignerController(IDesignerService designerService)
        {
			this.designerService = designerService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Team([FromQuery] TeamViewModel model)
        {
            var designers = await designerService.TeamAsync(
                model.Discipline,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                TeamViewModel.DesignersPerPage);

            model.TotalTeamCount = designers.TotalTeamCount;
            model.Team = designers.Team;
            model.Disciplines = await designerService.AllDisciplinesNamesAsync();

            return View(model);
        }

    }
}
