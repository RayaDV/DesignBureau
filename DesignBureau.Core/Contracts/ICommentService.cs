using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Admin.Comment;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Data.Models;

namespace DesignBureau.Core.Contracts
{
    public interface ICommentService
    {
        Task<int> CreateAsync(CommentFormViewModel model, int projectId);

        Task<AllCommentsViewModel> AllAsync(
                string? searchTerm = null,
                CommentSorting sorting = CommentSorting.LastAdded,
                int currentPage = 1,
                int commentsPerPage = 1);

        Task<bool> HasAuthorWithIdAsync(int commentId, string userId);

        Task<CommentFormViewModel?> GetCommentFormViewModelByIdAsync(int id);

        Task EditAsync(int id, CommentFormViewModel model);

        Task<bool> ExistsByIdAsync(int id);

        Task DeleteAsync(int id);

        Task<Comment> CommentToDeleteByIdAsync(int id);

    }
}
