using DesignBureau.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Tests.IntegrationTests
{
    public class HomeControllerTests
    {
        private HomeController homeController;

        [OneTimeSetUp]
        public void SetUp()
            => this.homeController = new HomeController(null);

        [Test]
        public async Task Error_SholdReturnCorrectView()
        {
            // Arrange
            int statusCode = 500;
            // Act
            var result = await this.homeController.Error(statusCode);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result as ViewResult, Is.Not.Null);
        }

        [Test]
        public async Task Error400_SholdReturnCorrectView()
        {
            // Arrange
            int statusCode = 400;
            // Act
            var result = await this.homeController.Error(statusCode);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result as ViewResult, Is.Not.Null);
        }

        [Test]
        public async Task Error401_SholdReturnCorrectView()
        {
            // Arrange
            int statusCode = 401;
            // Act
            var result = await this.homeController.Error(statusCode);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result as ViewResult, Is.Not.Null);
        }

        [Test]
        public async Task Error404_SholdReturnCorrectView()
        {
            // Arrange
            int statusCode = 404;
            // Act
            var result = await this.homeController.Error(statusCode);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result as ViewResult, Is.Not.Null);
        }
    }
}
