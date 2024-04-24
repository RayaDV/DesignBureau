using DesignBureau.Areas.Admin.Controllers;
using DesignBureau.Core.Models.Statistic;
using DesignBureau.Tests.Mocks;

namespace DesignBureau.Tests.IntegrationTests
{
    public class StatisticApiControllerTests
    {
        private StatisticApiController statisticController;

        [OneTimeSetUp]
        public void SetUp()
            => this.statisticController = new StatisticApiController(StatisticServiceMock.Instance);

        [Test]
        public async Task GetStatistic_ShouldReturnCorrectCountsAsync()
        {
            // Arrange
            // Act
            var result = await this.statisticController.GetStatistic();
            // Assert
            Assert.That(result, Is.Not.Null);
            var resultValue = result.Value as StatisticServiceModel;
            Assert.That(resultValue.TotalProjects, Is.EqualTo(3));
            Assert.That(resultValue.TotalComments, Is.EqualTo(3));
            Assert.That(resultValue.TeamCount, Is.EqualTo(2));
            Assert.That(resultValue.UsersCount, Is.EqualTo(5));
        }
    }
}
