using DesignBureau.Core.Models.Home;
using DesignBureau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesignBureau.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
