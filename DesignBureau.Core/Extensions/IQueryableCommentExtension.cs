using DesignBureau.Core.Models.Comment;
using DesignBureau.Infrastructure.Constants;
using DesignBureau.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQueryableCommentExtension
    {
        public static IQueryable<CommentServiceModel> ConvertToCommentServiceModel(this IQueryable<Comment> comments)
        {
            return comments
                .Select(c => new CommentServiceModel()
                {
                    Id = c.Id,
                    Content = c.Content,
                    Date = c.Date.ToString(DataConstants.DateFormat),
                    Title = c.Project.Title,
                    ProjectImageUrl = c.Project.MainImageUrl,
                    FullName = $"{c.Author.FirstName} {c.Author.LastName}",
                    Email = c.Author.Email,
                });
        }

        public static IQueryable<CommentFormViewModel> ConvertToCommentFormViewModel(this IQueryable<Comment> comments)
        {
            return comments
                .Select(c => new CommentFormViewModel()
                {
                    Content = c.Content,
                    Date = c.Date.ToString(DataConstants.DateFormat),
                    AuthorId = c.AuthorId,
                    ProjectId = c.ProjectId,
                });
        }
    }
}
