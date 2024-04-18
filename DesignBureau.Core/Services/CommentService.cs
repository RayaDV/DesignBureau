using DesignBureau.Core.Contracts;
using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;

        public CommentService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AllCommentsViewModel> AllCommentsAsync(
            string? searchTerm = null, 
            CommentSorting sorting = CommentSorting.LastAdded, 
            int currentPage = 1, 
            int commentsPerPage = 1)
        {
            var comments = repository.AllReadOnly<Comment>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                comments = comments.Where(c =>
                    c.Project.Title.ToLower().Contains(normalizedSearchTerm) ||
                    c.Content.ToLower().Contains(normalizedSearchTerm));
            }

            comments = sorting switch
            {
                CommentSorting.MostCommentsByProject => comments.OrderByDescending(c => c.Project.Comments.Count())
                                                       .ThenByDescending(c => c.Date),
                _ => comments.OrderByDescending(c => c.Date)
            };

            int totalCommentsCount = await comments.CountAsync();

            var commentsToShow = await comments
                .Skip((currentPage - 1) * commentsPerPage)
                .Take(commentsPerPage)
                .ConvertToCommentServiceModel()
                .ToListAsync();

            return new AllCommentsViewModel()
            {
                TotalCommentsCount = totalCommentsCount,
                Comments = commentsToShow,
            };
        }

        public async Task<Comment> CommentToDeleteByIdAsync(int id)
        {
            return await repository.AllReadOnly<Comment>()
                .Where(c => c.Id == id)
                .FirstAsync();
        }

        public async Task CreateAsync(CommentFormViewModel model, int projectId)
        {
            Comment comment = new Comment()
            {
                Content = model.Content,
                Date = DateTime.Now,
                AuthorId = model.AuthorId,
                ProjectId = projectId,
            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync<Comment>(id);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CommentFormViewModel model)
        {
            var comment = await repository.GetByIdAsync<Comment>(id);

            if (comment != null)
            {
                comment.Content = model.Content;
                comment.Date = DateTime.Now;
                comment.AuthorId = model.AuthorId;
                comment.ProjectId = model.ProjectId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Comment>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<CommentFormViewModel?> GetCommentFormViewModelByIdAsync(int id)
        {
            return await repository.AllReadOnly<Comment>()
                .Where(c => c.Id == id)
                .ConvertToCommentFormViewModel()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> HasAuthorWithIdAsync(int commentId, string userId)
        {
            return await repository.AllReadOnly<Comment>()
                .AnyAsync(c => c.Id == commentId && c.AuthorId == userId);
        }

    }
}
