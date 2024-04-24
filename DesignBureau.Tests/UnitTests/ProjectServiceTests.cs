using DesignBureau.Core.Contracts;
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
    [TestFixture]
    public class ProjectServiceTests : UnitTestsBase
    {
        private IUserService userService;
        private IProjectService projectService;
        private UserManager<ApplicationUser> userManager;
        private IWebHostEnvironment webHostEnv;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.userManager = UserManagerMock.Instance;
            this.webHostEnv = WebHostEnvironmentMock.Instance;
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
            Assert.That(exists, Is.True);
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

        [Test]
        public async Task GetProjectFormViewModelByIdAsync_ShouldReturnCorrectProjectModel_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.GetProjectFormViewModelByIdAsync(Project.Id);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo(Project.Title));
            Assert.That(result.Country, Is.EqualTo(Project.Country));
            Assert.That(result.Town, Is.EqualTo(Project.Town));
            Assert.That(result.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
            Assert.That(result.Architect, Is.EqualTo(Project.Architect));
            Assert.That(result.YearDesigned, Is.EqualTo(Project.YearDesigned));
            Assert.That(result.Description, Is.EqualTo(Project.Description));
            Assert.That(result.CategoryId, Is.EqualTo(Project.CategoryId));
            Assert.That(result.PhaseId, Is.EqualTo(Project.PhaseId));
        }

        [Test]
        public async Task GetProjectFormViewModelByIdAsync_ShouldReturnNull_WithInvalidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.GetProjectFormViewModelByIdAsync(2);
            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetProjectInformationModelByIdAsync_ShouldReturnCorrectProjectModel_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.GetProjectInformationModelByIdAsync(Project.Id);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(Project.Id));
            Assert.That(result.Title, Is.EqualTo(Project.Title));
            Assert.That(result.Country, Is.EqualTo(Project.Country));
            Assert.That(result.Town, Is.EqualTo(Project.Town));
        }

        [Test]
        public async Task GetProjectInformationModelByIdAsync_ShouldReturnNull_WithInvalidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.GetProjectInformationModelByIdAsync(2);
            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetProjectByIdAsync_ShouldReturnCorrectProject_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.GetProjectByIdAsync(Project.Id);
            // Assert project data is correct
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(Project.Id));
            Assert.That(result.Title, Is.EqualTo(Project.Title));
            Assert.That(result.Country, Is.EqualTo(Project.Country));
            Assert.That(result.Town, Is.EqualTo(Project.Town));
            Assert.That(result.Architect, Is.EqualTo(Project.Architect));
            Assert.That(result.YearDesigned, Is.EqualTo(Project.YearDesigned));
            Assert.That(result.Description, Is.EqualTo(Project.Description));
            Assert.That(result.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
            Assert.That(result.CategoryId, Is.EqualTo(Project.CategoryId));
            Assert.That(result.PhaseId, Is.EqualTo(Project.PhaseId));
            Assert.That(result.DesignerId, Is.EqualTo(Project.DesignerId));
            Assert.That(result.ImagesSerialized, Is.Not.Null);
            // Assert project comments count is correct
            int commentsCount = repository.AllReadOnly<Comment>().Where(c => c.ProjectId == Project.Id).Count();
            var resultComments = result.Comments.ToList();
            Assert.That(resultComments.Count, Is.EqualTo(commentsCount));
            // Assert the first comment data is correct
            var firstComment = resultComments.First();
            Assert.That(firstComment, Is.Not.Null);
            Assert.That(firstComment.Id, Is.EqualTo(Comment.Id));
            Assert.That(firstComment.Content, Is.EqualTo(Comment.Content));
            Assert.That(firstComment.Date, Is.EqualTo(Comment.Date));
            Assert.That(firstComment.ProjectId, Is.EqualTo(Comment.ProjectId));
            Assert.That(firstComment.AuthorId, Is.EqualTo(Comment.AuthorId));
        }

        [Test]
        public async Task GetProjectByIdAsync_ShouldReturnNull_WithInvalidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.GetProjectByIdAsync(2);
            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ProjectToDeleteByIdAsync_ShouldReturnCorrectProjectModel_WithValidIdAsync()
        {
            // Arrange
            // Act
            var result = await projectService.ProjectToDeleteByIdAsync(Project.Id);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo(Project.Title));
            Assert.That(result.Country, Is.EqualTo(Project.Country));
            Assert.That(result.Town, Is.EqualTo(Project.Town));
            Assert.That(result.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
            Assert.That(result.YearDesigned, Is.EqualTo(Project.YearDesigned));
        }

        [Test]
        public async Task AllProjectsFromLastAsync_ShouldReturnProjectsInCorrectOrder()
        {
            // Arrange
            // Act
            var result = await projectService.AllProjectsFromLastAsync();
            // Assert returned projects count is correct
            var projectsInDb = repository.AllReadOnly<Project>().OrderByDescending(p => p.Id);
            Assert.That(result.Count(), Is.EqualTo(projectsInDb.Count()));
            // Assert the projects data is correct
            var firstProject = result.FirstOrDefault();
            Assert.That(firstProject, Is.Not.Null);
            Assert.That(firstProject.Id, Is.EqualTo(Project.Id));
            Assert.That(firstProject.Title, Is.EqualTo(Project.Title));
            Assert.That(firstProject.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
            Assert.That(firstProject.Country, Is.EqualTo(Project.Country));
            Assert.That(firstProject.Town, Is.EqualTo(Project.Town));
        }

        [Test]
        public async Task AllAsync_ShouldReturnCorrectProjects()
        {
            // Arrange
            // Act
            var result = await projectService.AllAsync();
            // Assert returned projects count is correct
            int projectsCount = repository.AllReadOnly<Project>().Count();
            Assert.That(result.TotalProjectsCount, Is.EqualTo(projectsCount));
            Assert.That(result.Projects.Count(), Is.EqualTo(projectsCount));
            // Assert returned projects data is correct
            var firstProject = result.Projects.FirstOrDefault();
            Assert.That(firstProject, Is.Not.Null);
            Assert.That(firstProject.Id, Is.EqualTo(Project.Id));
            Assert.That(firstProject.Title, Is.EqualTo(Project.Title));
            Assert.That(firstProject.Country, Is.EqualTo(Project.Country));
            Assert.That(firstProject.Town, Is.EqualTo(Project.Town));
            Assert.That(firstProject.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
            Assert.That(firstProject.YearDesigned, Is.EqualTo(Project.YearDesigned));
        }

        [Test]
        public async Task AllProjectsByDesignerIdAsync_ShouldReturnCorrectProjects()
        {
            // Arrange
            int designerId = Designer.Id;
            // Act
            var result = await projectService.AllProjectsByDesignerIdAsync(designerId);
            // Assert returned projects count is correct
            int projectsCount = repository.AllReadOnly<Project>()
                .Where(p => p.DesignerId == designerId)
                .Count();
            Assert.That(result.TotalProjectsCount, Is.EqualTo(projectsCount));
            Assert.That(result.Projects.Count(), Is.EqualTo(projectsCount));
            // Assert returned projects data is correct
            var firstProject = result.Projects.FirstOrDefault();
            Assert.That(firstProject, Is.Not.Null);
            Assert.That(firstProject.Id, Is.EqualTo(Project.Id));
            Assert.That(firstProject.Title, Is.EqualTo(Project.Title));
            Assert.That(firstProject.Country, Is.EqualTo(Project.Country));
            Assert.That(firstProject.Town, Is.EqualTo(Project.Town));
            Assert.That(firstProject.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
            Assert.That(firstProject.YearDesigned, Is.EqualTo(Project.YearDesigned));
        }

        [Test]
        public async Task DeleteAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            int initialProjectsCount = repository.AllReadOnly<Project>().Count();
            // Act
            await projectService.DeleteAsync(Project.Id);
            // Assert comments count is changed
            int projectsCount = repository.AllReadOnly<Project>().Count();
            Assert.That(projectsCount, Is.EqualTo(initialProjectsCount - 1));
            // Assert the comment is deleted in db
            var deletedProject = await repository.AllReadOnly<Project>().FirstOrDefaultAsync(p => p.Id == Project.Id);
            Assert.That(deletedProject, Is.Null);
            ////Assert that project images folder is deleted if it is empty
            //var exists = Directory.Exists($"D:\\RAYA\\SoftUni\\Web\\ASP-NET-DesignBureau\\DesignBureau\\DesignBureau.Tests\\Output\\img\\Projects\\{Project.Id}");
            //Assert.That(exists, Is.True);  // because it is not empty
        }

        [Test]
        public async Task AllImagesByProjectIdAsync_ShouldReturnCorrectImages()
        {
            // Arrange
            int projectId = Project.Id;
            // Act
            var result = await projectService.AllImagesByProjectIdAsync(projectId);
            // Assert returned data is correct
            var project = await repository.AllReadOnly<Project>().FirstOrDefaultAsync(p => p.Id == projectId);
            Assert.That(project, Is.Not.Null);
            Assert.That(result.ProjectId, Is.EqualTo(projectId));
            Assert.That(result.Title, Is.EqualTo(project.Title));
            Assert.That(result.Gallery, Is.Not.Null);
            Assert.That(result.Gallery.Count(), Is.EqualTo(project.Images.Count()));
            string firstImage = result.Gallery.First();
            Assert.That(firstImage, Is.EqualTo("https://localhost:7134/img/Projects/1/ONYX-02.jpg"));
        }

        [Test]
        public async Task AllProjectsGalleryAsync_ShouldReturnCorrectProjects()
        {
            // Arrange
            // Act
            var result = await projectService.AllProjectsGalleryAsync();
            // Assert returned projects count is correct
            int projectsCount = repository.AllReadOnly<Project>().Count();
            Assert.That(result.TotalProjectsCount, Is.EqualTo(projectsCount));
            Assert.That(result.Projects.Count(), Is.EqualTo(projectsCount));
            // Assert returned projects data is correct
            var firstProject = result.Projects.FirstOrDefault();
            Assert.That(firstProject, Is.Not.Null);
            Assert.That(firstProject.ProjectId, Is.EqualTo(Project.Id));
            Assert.That(firstProject.Title, Is.EqualTo(Project.Title));
            Assert.That(firstProject.MainImageUrl, Is.EqualTo(Project.MainImageUrl));
        }

        [Test]
        public async Task AddImagesToProjectAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            int projectId = Project.Id;
            var project = await projectService.GetProjectByIdAsync(projectId);
            Assert.That(project, Is.Not.Null);
            int initialImagesCount = project.Images.Count();
            // Act
            await projectService.AddImagesToProjectAsync(new List<string>() 
            { "https://localhost:7134/img/Projects/1/ONYX-04.jpg",
              "https://localhost:7134/img/Projects/1/ONYX-05.jpg"
            }, projectId);
            //Assert that project images folder exists
            //var exists = Directory.Exists($"D:\\RAYA\\SoftUni\\Web\\ASP-NET-DesignBureau\\DesignBureau\\DesignBureau.Tests\\Output\\img\\Projects\\{projectId}");
            //Assert.That(exists, Is.True);
            // Assert project images count is changed
            int imagesCount = project.Images.Count();
            Assert.That(imagesCount, Is.EqualTo(initialImagesCount + 2));
            // Assert the new images are added in db
            Assert.That(project.Images.Contains("https://localhost:7134/img/Projects/1/ONYX-04.jpg"));
            Assert.That(project.Images.Contains("https://localhost:7134/img/Projects/1/ONYX-05.jpg"));
        }

        [Test]
        public async Task RemoveImageFromProjectAsync_ShouldReturnTrue_WithValidInputAsync()
        {
            // Arrange
            int projectId = Project.Id;
            var project = await projectService.GetProjectByIdAsync(projectId);
            Assert.That(project, Is.Not.Null);
            int initialImagesCount = project.Images.Count();
            // Act
            bool isRemoved = await projectService.RemoveImageFromProjectAsync(
                "https://localhost:7134/img/Projects/1/ONYX-03.jpg", projectId);
            // Assert project images count is changed
            int imagesCount = project.Images.Count();
            Assert.That(imagesCount, Is.EqualTo(initialImagesCount - 1));
            // Assert that the image id deleted from db
            Assert.That(isRemoved, Is.True);
            Assert.That(project.Images.Contains("https://localhost:7134/img/Projects/1/ONYX-02.jpg"));
            Assert.That(!project.Images.Contains("https://localhost:7134/img/Projects/1/ONYX-03.jpg"));
        }
    }
}
