using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Core.Models.Project;
using DesignBureau.Core.Services;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace DesignBureau.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly IProjectService projectService;
        public CommentController(ICommentService commentService,
                                 IProjectService projectService)
        {
            this.commentService = commentService;
            this.projectService = projectService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllCommentsViewModel model)
        {
            var comments = await commentService.AllCommentsAsync(
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                AllCommentsViewModel.CommentsPerPage);

            model.TotalCommentsCount = comments.TotalCommentsCount;
            model.Comments = comments.Comments;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int projectId)
        {
            if (await projectService.ExistsByIdAsync(projectId) == false)
            {
                return BadRequest();
            };

            var model = new CommentFormViewModel
            {
                Date = DateTime.UtcNow,
                ProjectId = projectId,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int projectId, CommentFormViewModel model)
        {
            if (await projectService.ExistsByIdAsync(projectId) == false)
            {
                return BadRequest();
            };

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await commentService.CreateAsync(model, projectId);

            return RedirectToAction(nameof(All));
        }




    }
}
