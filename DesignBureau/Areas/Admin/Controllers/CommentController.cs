﻿using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Admin.Comment;
using DesignBureau.Core.Models.Comment;
using Microsoft.AspNetCore.Mvc;
using static DesignBureau.Core.Constants.MessageConstants;

namespace DesignBureau.Areas.Admin.Controllers
{
    public class CommentController : AdminBaseController
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
        public async Task<IActionResult> All([FromQuery] AllCommentsViewModel model)
        {
            var comments = await commentService.AllAsync(
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                AllCommentsViewModel.CommentsPerPage);

            model.TotalCommentsCount = comments.TotalCommentsCount;
            model.Comments = comments.Comments;

            return View(model);
        }


        public async Task<IActionResult> Edit(int id, CommentFormViewModel model)
        {

            if (await commentService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            };

            await commentService.EditAsync(id, model);

            TempData[UserMessageSuccess] = "You have successfully edited a comment";

            return RedirectToAction("All", "Comment", new { Area = "Admin" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (await commentService.ExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            await commentService.DeleteAsync(id);

            TempData[UserMessageSuccess] = "You have successfully deleted a comment";

            return RedirectToAction("All", "Comment", new { Area = "Admin" });
        }


    }
}
