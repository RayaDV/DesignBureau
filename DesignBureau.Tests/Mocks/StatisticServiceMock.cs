using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Statistic;
using Moq;

namespace DesignBureau.Tests.Mocks
{
    public static class StatisticServiceMock
    {
        public static IStatisticService Instance
        {
            get
            {
                var statisticServiceMock = new Mock<IStatisticService>();

                statisticServiceMock.Setup( s => s.TotalAsync())
                                    .ReturnsAsync(new StatisticServiceModel()
                                    {
                                        TeamCount = 2,
                                        UsersCount = 5,
                                        TotalComments = 3,
                                        TotalProjects = 3,
                                    });

                return statisticServiceMock.Object;
            }
        }
    }
}
