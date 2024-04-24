using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
