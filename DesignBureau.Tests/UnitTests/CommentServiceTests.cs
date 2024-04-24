using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Admin.Designer;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Core.Services;
using DesignBureau.Infrastructure.Constants;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Tests.UnitTests
{
    [TestFixture]
    public class CommentServiceTests : UnitTestsBase
    {
        private ICommentService commentService;

        [OneTimeSetUp]
        public void SetUp()
            => this.commentService = new CommentService(this.repository);

        [Test, Order(1)]
        public async Task ExistsByIdAsync_ShouldReturnTrue_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await commentService.ExistsByIdAsync(Comment.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test, Order(2)]
        public async Task ExistsByIdAsync_ShouldReturnFalse_WithInvalidIdAsync()
        {
            // Arrange
            // Act
            var result = await commentService.ExistsByIdAsync(2);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test, Order(3)]
        public async Task HasAuthorWithIdAsync_ShouldReturnTrue_WithValidAuthorIdAsync()
        {
            // Arrange
            // Act
            var result = await commentService.HasAuthorWithIdAsync(Comment.Id, GuestUser.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test, Order(4)]
        public async Task HasAuthorWithIdAsync_ShouldReturnFalse_WithInvalidAuthorIdAsync()
        {
            // Arrange
            // Act
            var result = await commentService.HasAuthorWithIdAsync(Comment.Id, "InvalidUserId");
            // Assert
            Assert.That(result, Is.False);
        }

        [Test, Order(5)]
        public async Task HasAuthorWithIdAsync_ShouldReturnFalse_WithWrongIdAsync()
        {
            // Arrange
            // Act
            var result = await commentService.HasAuthorWithIdAsync(2, GuestUser.Id);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test, Order(6)]
        public async Task GetCommentFormViewModelByIdAsync_ShouldReturnCorrectCommentModel_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await commentService.GetCommentFormViewModelByIdAsync(Comment.Id);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo(Comment.Content));
            Assert.That(result.Date, Is.EqualTo(Comment.Date.ToString(DataConstants.DateFormat)));
            Assert.That(result.ProjectId, Is.EqualTo(Comment.ProjectId));
            Assert.That(result.AuthorId, Is.EqualTo(Comment.AuthorId));
        }

        [Test, Order(7)]
        public async Task GetCommentFormViewModelByIdAsync_ShouldReturnNull_WithInvalidIdAsync()
        {
            // Arrange
            // Act
            var result = await commentService.GetCommentFormViewModelByIdAsync(2);
            // Assert
            Assert.That(result, Is.Null);
        }

        [Test, Order(11)]
        public async Task CreateAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            int initialCommentsCount = repository.AllReadOnly<Comment>().Count();
            // Act
            int newCommentId = await commentService.CreateAsync(new CommentFormViewModel()
            {
                Content = "It's me again!",
                Date = DateTime.Now.ToString(DataConstants.DateFormat),
                ProjectId = Project.Id,
                AuthorId = GuestUser.Id,
            },
            Project.Id);
            // Assert comments count is changed
            int commentsCount = repository.AllReadOnly<Comment>().Count();
            Assert.That(commentsCount, Is.EqualTo(initialCommentsCount + 1));
            // Assert a new comment is created in db
            var newComment = await repository.AllReadOnly<Comment>()
                .Include(c => c.Project)
                .Include(c => c.Author)
                .FirstAsync(c => c.Id == newCommentId);
            Assert.That(newComment, Is.Not.Null);
            Assert.That(newComment.Id, Is.EqualTo(2));
            Assert.That(newComment.Content, Is.EqualTo("It's me again!"));
            Assert.That(newComment.ProjectId, Is.EqualTo(Project.Id));
            Assert.That(newComment.AuthorId, Is.EqualTo(GuestUser.Id));
        }

        [Test, Order(10)]
        public async Task EditAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            var initialCommentsCount = repository.AllReadOnly<Designer>().Count();
            // Act
            await commentService.EditAsync(Comment.Id, new CommentFormViewModel()
            {
                Content = "It's me again!",
                Date = DateTime.Now.ToString(DataConstants.DateFormat),
            });
            // Assert comments count is changed
            var commentsCount = repository.AllReadOnly<Comment>().Count();
            Assert.That(commentsCount, Is.EqualTo(initialCommentsCount));
            // Assert the comment is edited in db
            var editedComment = await repository.AllReadOnly<Comment>()
                .Include(c => c.Project)
                .Include(c => c.Author)
                .FirstAsync(c => c.Id == Comment.Id);
            Assert.That(editedComment, Is.Not.Null);
            Assert.That(editedComment.Content, Is.EqualTo("It's me again!"));
            Assert.That(editedComment.ProjectId, Is.EqualTo(Project.Id));
            Assert.That(editedComment.AuthorId, Is.EqualTo(GuestUser.Id));
        }

        [Test, Order(12)]
        public async Task DeleteAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            int initialCommentsCount = repository.AllReadOnly<Comment>().Count();
            // Act
            await commentService.DeleteAsync(Comment.Id);
            // Assert comments count is changed
            int commentsCount = repository.AllReadOnly<Comment>().Count();
            Assert.That(commentsCount, Is.EqualTo(initialCommentsCount - 1));
            // Assert the comment is deleted in db
            var deletedComment = await repository.AllReadOnly<Comment>().FirstOrDefaultAsync(c => c.Id == Comment.Id);
            Assert.That(deletedComment, Is.Null);
        }

        [Test, Order(9)]
        public async Task CommentToDeleteByIdAsync_ShouldReturnCommentToDeleteAsync()
        {
            // Arrange
            // Act
            var comment = await commentService.CommentToDeleteByIdAsync(Comment.Id);
            // Assert
            Assert.That(comment.Id, Is.EqualTo(Comment.Id));
            Assert.That(comment.Content, Is.EqualTo(Comment.Content));
            Assert.That(comment.Date, Is.EqualTo(Comment.Date));
            Assert.That(comment.ProjectId, Is.EqualTo(Comment.ProjectId));
            Assert.That(comment.AuthorId, Is.EqualTo(Comment.AuthorId));
        }

        [Test, Order(8)]
        public async Task AllAsync_ShouldReturnCorrectComments()
        {
            // Arrange
            // Act
            var result = await commentService.AllAsync();
            // Assert returned comments count is correct
            int commentsCount = repository.AllReadOnly<Comment>().Count();
            Assert.That(result.TotalCommentsCount, Is.EqualTo(commentsCount));
            Assert.That(result.Comments.Count(), Is.EqualTo(commentsCount));
            // Assert returned comments data is correct
            var firstComment = result.Comments.FirstOrDefault();
            Assert.That(firstComment, Is.Not.Null);
            Assert.That(firstComment.Id, Is.EqualTo(Comment.Id));
            Assert.That(firstComment.Content, Is.EqualTo(Comment.Content));
            Assert.That(firstComment.Date, Is.EqualTo(Comment.Date.ToString(DataConstants.DateFormat)));
            Assert.That(firstComment.ProjectId, Is.EqualTo(Comment.ProjectId));
            Assert.That(firstComment.AuthorId, Is.EqualTo(Comment.AuthorId));
        }
    }
}
