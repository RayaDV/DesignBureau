using DesignBureau.Core.Contracts;
using DesignBureau.Core.Services;
using DesignBureau.Infrastructure.Data.Models;
using DesignBureau.Core.Models.Admin.Designer;
using Microsoft.EntityFrameworkCore;
using DesignBureau.Core.Models.Designer;

namespace DesignBureau.Tests.UnitTests
{
    [TestFixture]
    public class DesignerServiceTests : UnitTestsBase
    {
        private IDesignerService designerService;

        [OneTimeSetUp]
        public void SetUp()
            => this.designerService = new DesignerService(this.repository);

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrue_WithValidIdAsync()
        {
            // Arrange, Act
            var result = await designerService.ExistsByIdAsync(Designer.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalse_WithInvalidIdAsync()
        {
            // Arrange, Act
            var result = await designerService.ExistsByIdAsync(20);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ExistsByUserIdAsync_ShouldReturnTrue_WithValidUserIdAsync()
        {
            // Arrange, Act
            var result = await designerService.ExistsByUserIdAsync(Designer.User.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsByUserIdAsync_ShouldReturnFalse_WithInvalidUserIdAsync()
        {
            // Arrange, Act
            var result = await designerService.ExistsByUserIdAsync("UserId");
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ExistsByPhoneNumberAsync_ShouldReturnTrue_WithValidPhoneNumberAsync()
        {
            // Arrange, Act
            var result = await designerService.ExistsByPhoneNumberAsync(Designer.PhoneNumber);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsByPhoneNumberAsync_ShouldReturnFalse_WithInvalidPhoneNumberAsync()
        {
            // Arrange, Act
            var result = await designerService.ExistsByPhoneNumberAsync("0883494948");
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ExistsByEmailAsync_ShouldReturnTrue_WithValidEmailAsync()
        {
            // Arrange, Act
            var result = await designerService.ExistsByEmailAsync(Designer.User.Email);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsByEmailAsync_ShouldReturnFalse_WithInvalidEmailAsync()
        {
            // Arrange, Act
            var result = await designerService.ExistsByEmailAsync("dimitrova_rd@abv.bg");
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetDesignerIdAsync_ShouldReturnCorrectUserIdAsync()
        {
            // Arrange, Act
            var result = await designerService.GetDesignerIdAsync(Designer.UserId);
            // Assert
            Assert.That(result, Is.EqualTo(Designer.Id));
        }

        [Test]
        public async Task CreateAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            var initialDesignersCount = repository.AllReadOnly<Designer>().Count();
            // Act
            await designerService.CreateAsync(new DesignerFormViewModel()
            {
                PhoneNumber = Designer.PhoneNumber,
                DesignExperience = Designer.DesignExperience,
                DesignerImageUrl = Designer.DesignerImageUrl,
                DisciplineId = Designer.DisciplineId,
            }, 
            GuestUser.Id);
            // Assert designers count
            var designersCount = repository.AllReadOnly<Designer>().Count();
            Assert.That(designersCount, Is.EqualTo(initialDesignersCount + 1));
            // Assert a new designer is created in db
            var newDesignerId = await designerService.GetDesignerIdAsync(GuestUser.Id);
            var newDesigner = await repository.AllReadOnly<Designer>().Include(d => d.User).FirstAsync(d => d.Id == newDesignerId);
            Assert.IsNotNull(newDesigner);
            Assert.That(newDesigner.UserId, Is.EqualTo(GuestUser.Id));
            Assert.That(newDesigner.User.FirstName, Is.EqualTo(GuestUser.FirstName));
            Assert.That(newDesigner.User.LastName, Is.EqualTo(GuestUser.LastName));
            Assert.That(newDesigner.PhoneNumber, Is.EqualTo(Designer.PhoneNumber));
            Assert.That(newDesigner.DesignExperience, Is.EqualTo(Designer.DesignExperience));
            Assert.That(newDesigner.DesignerImageUrl, Is.EqualTo(Designer.DesignerImageUrl));
            Assert.That(newDesigner.DisciplineId, Is.EqualTo(Designer.DisciplineId));
        }

        [Test]
        public async Task AllDisciplinesAsync_ShouldReturnAllDisciplinesAsync()
        {
            // Arrange, Act
            var disciplines = await designerService.AllDisciplinesAsync();
            // Assert
            var discipline = disciplines.ToList()[0];
            int expectedCount = 1;
            int expectedId = 1;
            string expectedName = "Structure";
            Assert.That(disciplines.Count(), Is.EqualTo(expectedCount));
            Assert.That(discipline.Id, Is.EqualTo(expectedId));
            Assert.That(discipline.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public async Task AllDisciplinesNamesAsync_ShouldReturnAllDisciplinesNamesAsync()
        {
            // Arrange, Act
            var disciplineNames = await designerService.AllDisciplinesNamesAsync();
            // Assert
            string disciplineName = disciplineNames.ToList()[0];
            int expectedCount = 1;
            string expectedName = "Structure";
            Assert.That(disciplineNames.Count(), Is.EqualTo(expectedCount));
            Assert.That(disciplineName, Is.EqualTo(expectedName));
        }

        [Test]
        public async Task DisciplineExistsAsync_ShouldReturnTrue_WithValidDisciplineIdAsync()
        {
            // Arrange, Act
            var result = await designerService.DisciplineExistsAsync(Discipline.Id);
            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task DisciplineExistsAsync_ShouldReturnFalse_WithInvalidDisciplineIdAsync()
        {
            // Arrange, Act
            var result = await designerService.DisciplineExistsAsync(2);
            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetDesignerFormViewModelByIdAsync_ShouldReturnCorrectDesignerModelAsync()
        {
            // Arrange, Act
            var result = await designerService.GetDesignerFormViewModelByIdAsync(Designer.Id);
            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Email, Is.EqualTo(Designer.User.Email));
            Assert.That(result.FirstName, Is.EqualTo(Designer.User.FirstName));
            Assert.That(result.LastName, Is.EqualTo(Designer.User.LastName));
            Assert.That(result.PhoneNumber, Is.EqualTo(Designer.PhoneNumber));
            Assert.That(result.DesignExperience, Is.EqualTo(Designer.DesignExperience));
            Assert.That(result.DesignerImageUrl, Is.EqualTo(Designer.DesignerImageUrl));
            Assert.That(result.DisciplineId, Is.EqualTo(Designer.DisciplineId));
        }

        [Test]
        public async Task EditAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            var initialDesignersCount = repository.AllReadOnly<Designer>().Count();
            // Act
            await designerService.EditAsync(Designer.Id, new DesignerFormViewModel()
            {
                Email = GuestUser.Email,
                FirstName = GuestUser.FirstName,
                LastName = GuestUser.LastName,
                PhoneNumber = "+359883030303",
                DesignExperience = 2,
                DesignerImageUrl = "",
                DisciplineId = Discipline.Id,
            });
            // Assert designers count is unchanged
            var designersCount = repository.AllReadOnly<Designer>().Count();
            Assert.That(designersCount, Is.EqualTo(initialDesignersCount));
            // Assert the designer is edited in db
            var editedDesigner = await repository.AllReadOnly<Designer>().Include(d => d.User).FirstAsync(d => d.Id == Designer.Id);
            Assert.IsNotNull(editedDesigner);
            Assert.That(editedDesigner.User.FirstName, Is.EqualTo(GuestUser.FirstName));
            Assert.That(editedDesigner.User.LastName, Is.EqualTo(GuestUser.LastName));
            Assert.That(editedDesigner.PhoneNumber, Is.EqualTo("+359883030303"));
            Assert.That(editedDesigner.DesignExperience, Is.EqualTo(2));
            Assert.That(editedDesigner.DesignerImageUrl, Is.EqualTo(""));
            Assert.That(editedDesigner.DisciplineId, Is.EqualTo(Discipline.Id));
        }

        [Test]
        public async Task DeleteAsync_ShouldWorkCorrectlyAsync()
        {
            // Arrange
            var initialDesignersCount = repository.AllReadOnly<Designer>().Count();
            // Act
            await designerService.DeleteAsync(Designer.Id);
            // Assert designers count is changed
            var designersCount = repository.AllReadOnly<Designer>().Count();
            Assert.That(designersCount, Is.EqualTo(initialDesignersCount - 1));
            // Assert the designer is deleted in db
            var editedDesigner = await repository.AllReadOnly<Designer>().FirstOrDefaultAsync(d => d.Id == Designer.Id);
            Assert.IsNull(editedDesigner);
        }

        [Test]
        public async Task DesignerToDeleteByIdAsync_ShouldReturnDesignerToDeleteAsync()
        {
            // Arrange
            // Act
            var designer = await designerService.DesignerToDeleteByIdAsync(Designer.Id);
            // Assert
            var expectedDesigner = new DesignerDetailsServiceModel
            {
                Id = Designer.Id,
                DesignerImageUrl = Designer.DesignerImageUrl,
                DesignExperience = Designer.DesignExperience,
                Discipline = Designer.Discipline.Name,
                ProjectsCount = Designer.Projects.Count(),
                Email = Designer.User.Email,
                PhoneNumber = Designer.PhoneNumber,
                FullName = $"{Designer.User.FirstName} {Designer.User.LastName}",
            };
            Assert.That(designer.Id, Is.EqualTo(expectedDesigner.Id));
            Assert.That(designer.DesignerImageUrl, Is.EqualTo(expectedDesigner.DesignerImageUrl));
            Assert.That(designer.DesignExperience, Is.EqualTo(expectedDesigner.DesignExperience));
            Assert.That(designer.Discipline, Is.EqualTo(expectedDesigner.Discipline));
            Assert.That(designer.ProjectsCount, Is.EqualTo(expectedDesigner.ProjectsCount));
            Assert.That(designer.Email, Is.EqualTo(expectedDesigner.Email));
            Assert.That(designer.PhoneNumber, Is.EqualTo(expectedDesigner.PhoneNumber));
            Assert.That(designer.FullName, Is.EqualTo(expectedDesigner.FullName));
        }



    }
}
