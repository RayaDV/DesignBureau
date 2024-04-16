using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Core.Models.Project;

namespace DesignBureau.Core.Contracts
{
    public interface ICommentService
    {
        Task CreateAsync(CommentFormViewModel model, int projectId);

        Task<AllCommentsViewModel> AllCommentsAsync(
                string? searchTerm = null,
                CommentSorting sorting = CommentSorting.LastAdded,
                int currentPage = 1,
                int commentsPerPage = 1);

        Task<bool> HasAuthorWithIdAsync(int commentId, string userId);
    }
}
