using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Globalization;
using System.Security.Claims;
using static DesignBureau.Core.Constants.MessageConstants;

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
                Date = DateTime.Now.ToString(DataConstants.DateFormat),
                AuthorId = User.Id(),
                ProjectId = projectId,
            };

            return View("_PartialAddComment", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int projectId, CommentFormViewModel model)
        {
            if (await projectService.ExistsByIdAsync(projectId) == false)
            {
                return BadRequest();
            };

            await commentService.CreateAsync(model, projectId);

            return RedirectToAction("Details", "Project", new { id = projectId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (await commentService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            };

            if (await commentService.HasAuthorWithIdAsync(id, User.Id()) == false
                    && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await commentService.GetCommentFormViewModelByIdAsync(id);

            return View("_PartialAddComment", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CommentFormViewModel model)
        {

            if (await commentService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            };

            if (await commentService.HasAuthorWithIdAsync(id, User.Id()) == false
                    && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await commentService.EditAsync(id, model);

            return RedirectToAction("Details", "Project", new { id = model.ProjectId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await commentService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            if (await commentService.HasAuthorWithIdAsync(id, User.Id()) == false
                    && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var comment = await commentService.CommentToDeleteByIdAsync(id);

            await commentService.DeleteAsync(id);

            return RedirectToAction("Details", "Project", new { id = comment.ProjectId });
        }


    }
}
