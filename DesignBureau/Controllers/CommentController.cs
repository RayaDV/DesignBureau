using DesignBureau.Core.Contracts;
using DesignBureau.Core.Extensions;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;
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

            int newCommentId = await commentService.CreateAsync(model, projectId);

            var project = await projectService.GetProjectInformationModelByIdAsync(projectId);

            string information = project != null ? project.GetInformation() : string.Empty;

            TempData[UserMessageSuccess] = "You have successfully added a comment";

            return RedirectToAction("Details", "Project", new { id = projectId, information = information });
        }


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

            await commentService.EditAsync(id, model);

            var project = await projectService.GetProjectInformationModelByIdAsync(model.ProjectId);

            string information = project != null ? project.GetInformation() : string.Empty;

            TempData[UserMessageSuccess] = "You have successfully edited a comment";

            return Redirect($"/Project/Details/{model.ProjectId}/{information}");
        }


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

            var project = await projectService.GetProjectInformationModelByIdAsync(comment.ProjectId);

            string information = project != null ? project.GetInformation() : string.Empty;

            await commentService.DeleteAsync(id);

            TempData[UserMessageSuccess] = "You have successfully deleted a comment";

            return Redirect($"/Project/Details/{comment.ProjectId}/{information}");
        }


    }
}
