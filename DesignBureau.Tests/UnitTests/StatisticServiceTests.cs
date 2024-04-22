using DesignBureau.Core.Contracts;
using DesignBureau.Core.Services;
using DesignBureau.Infrastructure.Data.Models;

namespace DesignBureau.Tests.UnitTests
{
    [TestFixture]
    public class StatisticServiceTests : UnitTestsBase
    {
        private IStatisticService statisticService;

        [OneTimeSetUp]
        public void SetUp()
            => this.statisticService = new StatisticService(this.repository);

        [Test]
        public async Task TotalAsync_ShouldReturnCorrectCounts()
        {
            // Arrange
            // Act
            var result = await this.statisticService.TotalAsync();
            // Assert the result is not null
            Assert.IsNotNull(result);
            // Assert the returned counts are correct
            var expectedProjectsCount = repository.AllReadOnly<Project>().Count();
            var expectedCommentsCount = repository.AllReadOnly<Comment>().Count();
            var expectedTeamCount = repository.AllReadOnly<Designer>().Count();
            var expectedUsersCount = repository.AllReadOnly<ApplicationUser>().Count();
            Assert.That(result.TotalProjects, Is.EqualTo(expectedProjectsCount));
            Assert.That(result.TotalComments, Is.EqualTo(expectedCommentsCount));
            Assert.That(result.TeamCount, Is.EqualTo(expectedTeamCount));
            Assert.That(result.UsersCount, Is.EqualTo(expectedUsersCount));
        }
    }
}
