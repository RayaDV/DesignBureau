using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DesignBureau.Core.Constants.AdminConstants;

namespace DesignBureau.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminBaseController : Controller
    {

    }
}
