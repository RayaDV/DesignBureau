using Microsoft.AspNetCore.Hosting;
using Moq;

namespace ProjectHub.Tests.Mocks
{
    public static class WebHostEnvironmentMock
    {
        public static IWebHostEnvironment Instance
        {
            get
            {
                var webHostEnv = new Mock<IWebHostEnvironment>();

                webHostEnv.Setup(whe => whe.WebRootPath).Returns("D:\\RAYA\\SoftUni\\Web\\ASP-NET-DesignBureau\\DesignBureau\\DesignBureau.Tests\\Output");

                return webHostEnv.Object;
            }
        }

    }
}
