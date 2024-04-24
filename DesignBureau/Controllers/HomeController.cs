using DesignBureau.Core.Contracts;
using DesignBureau.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using static DesignBureau.Core.Constants.AdminConstants;

namespace DesignBureau.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProjectService projectService;

        public HomeController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            var model = await projectService.AllProjectsFromLastAsync();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }
    }
}
