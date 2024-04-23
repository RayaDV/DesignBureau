using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Core.Models.Project;
using DesignBureau.Core.Services;
using DesignBureau.Infrastructure.Constants;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Tests.Mocks;

namespace DesignBureau.Tests.UnitTests
{
    public class ProjectServiceTests : UnitTestsBase
    {
        private IUserService userService;
        private IProjectService projectService;
        private readonly UserManager<ApplicationUser> userManager = UserManagerMock.Instance;
        private readonly IWebHostEnvironment webHostEnv = WebHostEnvironmentMock.Instance;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.userService = new UserService(this.repository, this.userManager);
            this.projectService = new ProjectService(this.repository, this.webHostEnv);
        }

        [Test]
        public async Task AllCategoriesAsync_ShouldReturnCorrectCategoriesAsync()
        {
            // Arrange
            // Act
            var result = await projectService.AllCategoriesAsync();
            // Assert the categories count is correct
            int categoriesCount = repository.AllReadOnly<Category>().Count();
            Assert.That(result.Count(), Is.EqualTo(categoriesCount));
            // Assert the returned data is correct
            var category = result.ToList().First();
            Assert.That(category.Id, Is.EqualTo(Category.Id));
            Assert.That(category.Name, Is.EqualTo(Category.Name));
        }

        [Test]
        public async Task AllPhasesAsync_ShouldReturnCorrectPhasesAsync()
        {
            // Arrange
            // Act
            var result = await projectService.AllPhasesAsync();
            // Assert the phases count is correct
            int phasesCount = repository.AllReadOnly<Phase>().Count();
            Assert.That(result.Count(), Is.EqualTo(phasesCount));
            // Assert the returned data is correct
            var phase = result.ToList().First();
            Assert.That(phase.Id, Is.EqualTo(Phase.Id));
            Assert.That(phase.Name, Is.EqualTo(Phase.Name));
        }

        [Test]
        public async Task AllCategoriesNamesAsync_ShouldReturnCorrectResultAsync()
        {
            // Arrange
            // Act
            var result = await projectService.AllCategoriesNamesAsync();
            // Assert the categories count is correct
            var categoriesNames = repository.AllReadOnly<Category>().Select(c => c.Name);
            int categoriesCount = categoriesNames.Count();
            Assert.That(result.Count(), Is.EqualTo(categoriesCount));
            // Assert the returned data is correct
            var categoryName = result.ToList().First();
            Assert.That(categoryName, Is.EqualTo(Category.Name));
        }

        [Test]
        public async Task AllPhasesNamesAsync_ShouldReturnCorrectResultAsync()
        {
            // Arrange
            // Act
            var result = await projectService.AllPhasesNamesAsync();
            // Assert the phases count is correct
            var phasesNames = repository.AllReadOnly<Phase>().Select(c => c.Name);
            int phasesCount = phasesNames.Count();
            Assert.That(result.Count(), Is.EqualTo(phasesCount));
            // Assert the returned data is correct
            var phaseName = result.ToList().First();
            Assert.That(phaseName, Is.EqualTo(Phase.Name));
        }

        [Test]
        public async Task AllTownsNamesAsync_ShouldReturnCorrectResultAsync()
        {
            // Arrange
            // Act
            var result = await projectService.AllTownsNamesAsync();
            // Assert the phases count is correct
            var townsNames = repository.AllReadOnly<Project>().Select(p => p.Town).ToList();
            int townsCount = townsNames.Count();
            Assert.That(result.Count(), Is.EqualTo(townsCount));
            // Assert the returned data is correct
            var town = result.ToList().First();
            Assert.That(townsNames.Contains(town));
        }

        [Test]
        public async Task CategoryExistAsync_ShouldReturnTrue_WithValidCategoryIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.CategoryExistAsync(Category.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task CategoryExistAsync_ShouldReturnFalse_WithInvalidCategoryIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.CategoryExistAsync(2);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task PhaseExistAsync_ShouldReturnTrue_WithValidPhaseIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.PhaseExistAsync(Phase.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task PhaseExistAsync_ShouldReturnFalse_WithInvalidPhaseIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.PhaseExistAsync(2);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrue_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.ExistsByIdAsync(Project.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalse_WithInvalidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.ExistsByIdAsync(20);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task HasDesignerWithIdAsync_ShouldReturnTrue_WithValidDesignerIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.HasDesignerWithIdAsync(Project.Id, Designer.User.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task HasDesignerWithIdAsync_ShouldReturnFalse_WithInvalidDesignerIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.HasDesignerWithIdAsync(Project.Id, GuestUser.Id);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task HasDesignerWithIdAsync_ShouldReturnFalse_WithInvalidProjectIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.HasDesignerWithIdAsync(2, Designer.User.Id);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ProjectDetailsByIdAsync_ShouldReturnCorrectProjectDataAsync()
        {
            // Arrange
            int projectId = Project.Id;
            // Act
            var result = await projectService.ProjectDetailsByIdAsync(projectId);
            // Assert project data is correct
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(Project.Id));
            Assert.That(result.Title, Is.EqualTo(Project.Title));
            Assert.That(result.Country, Is.EqualTo(Project.Country));
            Assert.That(result.Town, Is.EqualTo(Project.Town));
            Assert.That(result.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
            Assert.That(result.YearDesigned, Is.EqualTo(Project.YearDesigned));
            Assert.That(result.Architect, Is.EqualTo(Project.Architect));
            Assert.That(result.Description, Is.EqualTo(Project.Description));
            Assert.That(result.Category, Is.EqualTo(Project.Category.Name));
            Assert.That(result.Phase, Is.EqualTo(Project.Phase.Name));
            // Assert project's designer data is correct
            Assert.That(result.Designer, Is.Not.Null);
            Assert.That(result.Designer.Email, Is.EqualTo(Project.Designer.User.Email));
            Assert.That(result.Designer.PhoneNumber, Is.EqualTo(Project.Designer.PhoneNumber));
            Assert.That(result.Designer.FullName, Is.EqualTo($"{Project.Designer.User.FirstName} {Project.Designer.User.LastName}"));
            // Assert project's comments data is correct
            var comments = repository.AllReadOnly<Comment>().Where(c => c.ProjectId == projectId);
            var firstCommentResult = result.Comments.First();
            Assert.That(firstCommentResult.Id, Is.EqualTo(Comment.Id));
            Assert.That(firstCommentResult.AuthorId, Is.EqualTo(Comment.Author.Id));
            Assert.That(firstCommentResult.ProjectId, Is.EqualTo(Comment.Project.Id));
            Assert.That(firstCommentResult.Content, Is.EqualTo(Comment.Content));
            Assert.That(firstCommentResult.Date, Is.EqualTo(Comment.Date.ToString(DataConstants.DateFormat)));
            Assert.That(firstCommentResult.FullName, Is.EqualTo($"{Comment.Author.FirstName} {Comment.Author.LastName}"));
        }

        [Test]
        public async Task CreateAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            int initialProjectsCount = repository.AllReadOnly<Project>().Count();
            // Act
            int newProjectId = await projectService.CreateAsync(new ProjectFormViewModel()
            {
                Title = Project.Title,
                Country = Project.Country,
                Town = Project.Town,
                MainImageUrl = Project.MainImageUrl,
                Architect = Project.Architect,
                YearDesigned = Project.YearDesigned,
                Description = Project.Description,
                CategoryId = Project.CategoryId,
                PhaseId = Project.PhaseId,
            },
            Designer.Id);
            //Assert that project images folder exists
            var exists = Directory.Exists($"D:\\RAYA\\SoftUni\\Web\\ASP-NET-DesignBureau\\DesignBureau\\DesignBureau.Tests\\Output\\img\\Projects\\{newProjectId}");
            Assert.That( exists, Is.True );
            // Assert projects count is changed
            int projectsCount = repository.AllReadOnly<Project>().Count();
            Assert.That(projectsCount, Is.EqualTo(initialProjectsCount + 1));
            // Assert a new project is created in db
            var newProject = await repository.AllReadOnly<Project>()
                .Include(p => p.Category)
                .Include(p => p.Phase)
                .FirstAsync(c => c.Id == newProjectId);
            Assert.That(newProject, Is.Not.Null);
            Assert.That(newProject.Id, Is.EqualTo(2));
            Assert.That(newProject.Title, Is.EqualTo(Project.Title));
            Assert.That(newProject.Country, Is.EqualTo(Project.Country));
            Assert.That(newProject.Town, Is.EqualTo(Project.Town));
            Assert.That(newProject.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
            Assert.That(newProject.Architect, Is.EqualTo(Project.Architect));
            Assert.That(newProject.YearDesigned, Is.EqualTo(Project.YearDesigned));
            Assert.That(newProject.Description, Is.EqualTo(Project.Description));
            Assert.That(newProject.CategoryId, Is.EqualTo(Project.CategoryId));
            Assert.That(newProject.PhaseId, Is.EqualTo(Project.PhaseId));
        }

        [Test]
        public async Task EditAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            var initialProjectsCount = repository.AllReadOnly<Project>().Count();
            // Act
            await projectService.EditAsync(Project.Id, new ProjectFormViewModel()
            {
                Title = "SEG",
                Country = "Macedonia",
                Town = "Krivina",
                MainImageUrl = "https://localhost:7134/img/Projects/2/SEG-01.jpg",
                Architect = "Ivo Petrov Architects",
                YearDesigned = 2018,
                Description = "Total Build Up Area: 5 632 m2.",
                CategoryId = Category.Id,
                PhaseId = Phase.Id,
            });
            // Assert projects count is changed
            var projectsCount = repository.AllReadOnly<Comment>().Count();
            Assert.That(projectsCount, Is.EqualTo(initialProjectsCount));
            // Assert the project is edited in db
            var editedProject = await repository.AllReadOnly<Project>()
                .Include(p => p.Category)
                .Include(p => p.Phase)
                .FirstAsync(p => p.Id == Project.Id);
            Assert.That(editedProject, Is.Not.Null);
            Assert.That(editedProject.Title, Is.EqualTo("SEG"));
            Assert.That(editedProject.Country, Is.EqualTo("Macedonia"));
            Assert.That(editedProject.Town, Is.EqualTo("Krivina"));
            Assert.That(editedProject.MainImageUrl, Is.EqualTo("https://localhost:7134/img/Projects/2/SEG-01.jpg"));
            Assert.That(editedProject.Architect, Is.EqualTo("Ivo Petrov Architects"));
            Assert.That(editedProject.YearDesigned, Is.EqualTo(2018));
            Assert.That(editedProject.CategoryId, Is.EqualTo(Category.Id));
            Assert.That(editedProject.PhaseId, Is.EqualTo(Phase.Id));
        }
    }
}
