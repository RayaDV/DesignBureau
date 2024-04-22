using DesignBureau.Data;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static DesignBureauDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<DesignBureauDbContext>()
                    .UseInMemoryDatabase("DesignBureauInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new DesignBureauDbContext(dbContextOptions, false);
            }
        }
    }
}
