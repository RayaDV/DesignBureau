using DesignBureau.Core.Contracts;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Controllers
{
    public class CommentController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        public CommentController(UserManager<ApplicationUser> userManager, 
                                 IUserService userService, 
                                 ICommentService commentService)
        {
            this.userService = userService;
            this.commentService = commentService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
