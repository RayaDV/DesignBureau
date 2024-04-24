using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Project;
using DesignBureau.Core.Services;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProjectHub.Tests.Mocks;

namespace DesignBureau.Tests.UnitTests
{
    [TestFixture]
    public class FileServiceTests : UnitTestsBase
    {
        private IWebHostEnvironment webHostEnv;
        private IFileService fileService;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.webHostEnv = WebHostEnvironmentMock.Instance;
            this.fileService = new FileService(this.webHostEnv);
        }

        [Test]
        public async Task CopyFileToRoot_ShouldWorkCorrectlyAsync()
        {
            //Arrange
            int projectId = Project.Id;
            var formFile = new FormFile(new MemoryStream(), 0, 0, null, "ONYX-04");
            // Act
            fileService.CopyFileToRoot(projectId, formFile, "Projects");
            //Assert
            var folderExists = Directory.Exists($"D:\\RAYA\\SoftUni\\Web\\ASP-NET-DesignBureau\\DesignBureau\\DesignBureau.Tests\\Output\\img\\Projects\\{projectId}");
            Assert.That(folderExists, Is.True);
            var fileExists = File.Exists($"D:\\RAYA\\SoftUni\\Web\\ASP-NET-DesignBureau\\DesignBureau\\DesignBureau.Tests\\Output\\img\\Projects\\{projectId}\\ONYX-04");
            Assert.That(fileExists, Is.True);
        }
    }
}
