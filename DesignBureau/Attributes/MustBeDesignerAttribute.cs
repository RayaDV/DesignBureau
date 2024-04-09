using DesignBureau.Controllers;
using DesignBureau.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace DesignBureau.Attributes
{
    public class MustBeDesignerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IDesignerService? designerService = context.HttpContext.RequestServices.GetService<IDesignerService>();

            if (designerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (designerService != null && designerService.ExistsByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(DesignerController.Create), "Designer", null);
            }
        }
    }
}
