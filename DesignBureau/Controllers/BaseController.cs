using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
