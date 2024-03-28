using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Home;
using DesignBureau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesignBureau.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService projectService;

        public HomeController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await projectService.AllProjectsFromBack();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
