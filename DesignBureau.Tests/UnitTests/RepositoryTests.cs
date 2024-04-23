using DesignBureau.Infrastructure.Common;

namespace DesignBureau.Tests.UnitTests
{
    [TestFixture]
    public class RepositoryTests : UnitTestsBase
    {
        private IRepository repository;

        [OneTimeSetUp]
        public void SetUp()
            => this.repository = new Repository(this.context);

        //[Test]
        //public void DbSetT_ShouldReturnSetT()
        //{

        //}
    }
}
