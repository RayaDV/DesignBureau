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
        private readonly IUserService userService;

        public HomeController(IProjectService projectService, IUserService userService)
        {
            this.projectService = projectService;
            this.userService = userService; 
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
