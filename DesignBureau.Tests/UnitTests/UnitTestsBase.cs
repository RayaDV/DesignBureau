using DesignBureau.Data;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using DesignBureau.Tests.Mocks;

namespace DesignBureau.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected DesignBureauDbContext context;
        protected IRepository repository;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            this.context = DatabaseMock.Instance;
            this.repository = new Repository(this.context);

            SeedDatabase();
        }

        [OneTimeTearDown]
        public void TearDownBase() => this.context.Dispose();


        public ApplicationUser GuestUser { get; private set; } = null!;
        public Discipline Discipline { get; private set; } = null!;
        public Designer Designer { get; private set; } = null!;
        public Category Category { get; private set; } = null!;
        public Phase Phase { get; private set; } = null!;
        public Project Project { get; private set; } = null!;
        public Comment Comment { get; private set; } = null!;

        private void SeedDatabase()
        {
            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Email = "dimitar@gmail.com",
                FirstName = "Dimitar",
                LastName = "Dimitrov",
            };
            this.context.Users.Add(GuestUser);

            Discipline = new Discipline() { Id = 1, Name = "Structure" };
            this.context.Disciplines.Add(Discipline);

            Designer = new Designer()
            {
                PhoneNumber = "+359883494948",
                DesignExperience = 13,
                DesignerImageUrl = "https://localhost:7134/img/Designers/Raya.jpg",
                Discipline = Discipline,
                User = new ApplicationUser()
                {
                    Id = "2f08c4b6-7afe-4bba-beaa-36d800c03e44",
                    Email = "raya@e.kroumov.com",
                    FirstName = "Raya",
                    LastName = "Dimitrova",
                }
            };
            this.context.Designers.Add(Designer);

            Category = new Category() { Id = 1, Name = "Office And Residential Buildings" };
            this.context.Categories.Add(Category);
            Phase = new Phase() { Id = 1, Name = "Construction" };
            this.context.Phases.Add(Phase);

            Project = new Project()
            {
                Title = "Multi-purpose building ONYX",
                Country = "Bulgaria",
                Town = "Sofia",
                Architect = "ProArch",
                YearDesigned = 2019,
                Description = "Total Build Up Area: 12 236,60 m2. Structural design: monolithic reinforced concrete and steel structure. Post-tensioning of the RC plates above lvl.+14.500. At lvl.+11.000 the building is cantilevered over three X-shaped steel columns. 3-dimensional modelling of the structure with Revit Structure. 3D FEM Analysis model with Robot Structural Analysis. Workshop drawings of the steel structure.",
                Category = Category,
                Phase = Phase,
                Designer = Designer,
                MainImageUrl = "https://localhost:7134/img/Projects/1/ONYX-01.jpg",
                Images = new List<string>() { "https://localhost:7134/img/Projects/1/ONYX-02.jpg",
                                              "https://localhost:7134/img/Projects/1/ONYX-03.jpg"}
            };
            this.context.Projects.Add(Project);

            Comment = new Comment()
            {
                Content = "This is a very difficult project!",
                Date = DateTime.Now,
                Author = GuestUser,
                Project = Project,
            };
            this.context.Comments.Add(Comment);

            this.context.SaveChanges();
        }
    }
}
