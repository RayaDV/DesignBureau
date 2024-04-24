using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.User;
using DesignBureau.Core.Services;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Tests.Mocks;

namespace DesignBureau.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;
        private UserManager<ApplicationUser> userManager;


        [OneTimeSetUp]
        public void Setup()
        {
            this.userManager = UserManagerMock.Instance;
            this.userService = new UserService(this.repository, this.userManager);
        }
          
        [Test]
        public async Task UserFullNameAsync_ShouldReturnCorrectResult()
        {
            // Arrange
            // Act
            string result = await userService.UserFullNameAsync(GuestUser.Id);
            // Assert
            string expectedResult = $"{GuestUser.FirstName} {GuestUser.LastName}";
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrue_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await userService.ExistsByIdAsync(GuestUser.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalse_WithInvalidIdAsync()
        {
            // Arrange
            // Act
            var result = await userService.ExistsByIdAsync("UserId");
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldReturnCorrectUser_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await userService.GetUserByIdAsync(GuestUser.Id);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(GuestUser.Id));
            Assert.That(result.FirstName, Is.EqualTo(GuestUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(GuestUser.LastName));
            Assert.That(result.Email, Is.EqualTo(GuestUser.Email));
            Assert.That(result.Designer, Is.Null);
            Assert.That(result.Comments.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldReturnNullUser_WithInvalidIdAsync()
        {
            // Arrange
            // Act
            var result = await userService.GetUserByIdAsync("UserId");
            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task CreateAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            var initialUsersCount = repository.AllReadOnly<ApplicationUser>().Count();
            // Act
            string newUserId = await userService.CreateAsync(new UserServiceModel()
            {
                FirstName = "Neli",
                LastName = "Dimitrova",
                Email = "neli@gmail.com",
            });
            // Assert users count
            var usersCount = repository.AllReadOnly<ApplicationUser>().Count();
            Assert.That(usersCount, Is.EqualTo(initialUsersCount + 1));
            // Assert that the user is correct user
            var newUser = await userService.GetUserByIdAsync(newUserId);
            Assert.That(newUser, Is.Not.Null);
            Assert.That(newUser.FirstName, Is.EqualTo("Neli"));
            Assert.That(newUser.LastName, Is.EqualTo("Dimitrova"));
            Assert.That(newUser.Email, Is.EqualTo("neli@gmail.com"));
            Assert.That(newUser.UserName, Is.EqualTo("neli@gmail.com"));
            Assert.That(newUser.NormalizedEmail, Is.EqualTo("neli@gmail.com".ToUpper()));
            Assert.That(newUser.NormalizedUserName, Is.EqualTo("neli@gmail.com".ToUpper()));
        }

        [Test]
        public async Task DeleteAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            int initialUsersCount = repository.AllReadOnly<ApplicationUser>().Count();
            // Act
            await userService.DeleteAsync(GuestUser.Id);
            // Assert users count is changed
            int usersCount = repository.AllReadOnly<ApplicationUser>().Count();
            Assert.That(usersCount, Is.EqualTo(initialUsersCount - 1));
            // Assert the user is deleted in db
            var deletedUser = await repository.AllReadOnly<ApplicationUser>().FirstOrDefaultAsync(u => u.Id == GuestUser.Id);
            Assert.That(deletedUser, Is.Null);
        }

        [Test]
        public async Task AllAsync_ShouldReturnCorrectUsers()
        {
            // Arrange
            // Act
            var result = await userService.AllAsync();
            // Assert users count is correct
            int usersCount = repository.AllReadOnly<ApplicationUser>().Count();
            var resultUsers = result.ToList();
            Assert.That(resultUsers.Count(), Is.EqualTo(usersCount));
            // Assert designers count is correct
            int designersCount = repository.AllReadOnly<ApplicationUser>().Where(u => u.Designer != null).Count();
            int resultDesignersCount = resultUsers.Where(u => u.IsDesigner).Count();
            Assert.That(resultDesignersCount, Is.EqualTo(designersCount));
            // Assert the designer's data is correct
            var designerUser = resultUsers.FirstOrDefault(u => u.Email == Designer.User.Email);
            Assert.That(designerUser, Is.Not.Null);
            Assert.That(designerUser.PhoneNumber, Is.EqualTo(Designer.PhoneNumber));
            Assert.That(designerUser.FullName, Is.EqualTo($"{Designer.User.FirstName} {Designer.User.LastName}"));
            Assert.That(designerUser.ProjectsCount, Is.EqualTo(Designer.Projects.Count()));
            Assert.That(designerUser.CommentsCount, Is.EqualTo(Designer.User.Comments.Count()));
        }
    }
}
