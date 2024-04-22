using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static DesignBureau.Infrastructure.Constants.CustomClaims;

namespace DesignBureau.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUserClaim<string> AdminUserClaim { get; set; }
        public IdentityUserClaim<string> DesignerUserClaim { get; set; }
        public IdentityUserClaim<string> GuestUserClaim { get; set; }

        public ApplicationUser AdminUser { get; set; }
        public ApplicationUser DesignerUser { get; set; }
        public ApplicationUser GuestUser { get; set; }

        public Discipline ArchitectureDiscipline { get; set; }
        public Discipline StructureDiscipline { get; set; }
        public Discipline ElectroDiscipline { get; set; }
        public Discipline WssDiscipline { get; set; }
        public Discipline HvacDiscipline { get; set; }
        public Discipline GeodesyDiscipline { get; set; }
        public Discipline LandscapingDiscipline { get; set; }

        public Designer FirstDesigner { get; set; }

        public Category InternationalProjectsCategory { get; set; }
        public Category PublicBuildingsCategory { get; set; }
        public Category OfficeAndResidentialBuildingsCategory { get; set; }
        public Category CommercialBuildingsCategory { get; set; }
        public Category IndustrialBuildingsCategory { get; set; }
        public Category FamilyHousesCategory { get; set; }
        public Category ReconstructionsAndRebuildingsCategory { get; set; }

        public Phase Design { get; set; }
        public Phase Construction { get; set; }
        public Phase Use { get; set; }
        public Phase EndOfService { get; set; }

        public Project FirstProject { get; set; }
        public Project SecondProject { get; set; }

        public Comment FirstProjectComment { get; set; }
        public Comment SecondProjectComment { get; set; }

        public Rate FirstProjectRate { get; set; }
        public Rate SecondProjectRate { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedDisciplines();
            SeedDesigners();
            SeedCategories();
            SeedPhases();
            SeedProjects();
            SeedComments();
            SeedRates();
        }


        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            DesignerUser = new ApplicationUser()
            {
                Id = "2f08c4b6-7afe-4bba-beaa-36d800c03e44",
                UserName = "raya@e.kroumov.com",
                NormalizedUserName = "RAYA@E.KROUMOV.COM",
                Email = "raya@e.kroumov.com",
                NormalizedEmail = "RAYA@E.KROUMOV.COM",
                FirstName = "Raya",
                LastName = "Dimitrova",
            };

            DesignerUserClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Raya Dimitrova",
                UserId = "2f08c4b6-7afe-4bba-beaa-36d800c03e44"
            };

            DesignerUser.PasswordHash =
                 hasher.HashPassword(DesignerUser, "raya123");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "dimitar@gmail.com",
                NormalizedUserName = "DIMITAR@GMAIL.COM",
                Email = "dimitar@gmail.com",
                NormalizedEmail = "DIMITAR@GMAIL.COM",
                FirstName = "Dimitar",
                LastName = "Dimitrov",
            };

            GuestUserClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Dimitar Dimitrov",
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "dimitar123");

            AdminUser = new ApplicationUser()
            {
                Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Master",
                LastName = "Admin"
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                ClaimType = UserFullNameClaim,
                UserId = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                ClaimValue = "Master Admin"
            };

            AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedDisciplines()
        {
            ArchitectureDiscipline = new Discipline() { Id = 1, Name = "Architecture" };
            StructureDiscipline = new Discipline() { Id = 2, Name = "Structure" };
            ElectroDiscipline = new Discipline() { Id = 3, Name = "Electro" };
            WssDiscipline = new Discipline() { Id = 4, Name = "WS&S" };
            HvacDiscipline = new Discipline() { Id = 5, Name = "HVAC" };
            GeodesyDiscipline = new Discipline() { Id = 6, Name = "Geodesy" };
            LandscapingDiscipline = new Discipline() { Id = 7, Name = "Landscaping" };
        }
        private void SeedDesigners()
        {
            FirstDesigner = new Designer()
            {
                Id = 1,
                PhoneNumber = "+359883494948",
                DesignExperience = 13,
                DesignerImageUrl = "https://localhost:7134/img/Designers/Raya.jpg",
                DisciplineId = StructureDiscipline.Id,
                UserId = DesignerUser.Id,
            };

        }
        private void SeedCategories()
        {
            InternationalProjectsCategory = new Category() { Id = 1, Name = "International Projects" };
            PublicBuildingsCategory = new Category() { Id = 2, Name = "Public Buildings" };
            OfficeAndResidentialBuildingsCategory = new Category() { Id = 3, Name = "Office And Residential Buildings" };
            CommercialBuildingsCategory = new Category() { Id = 4, Name = "Commercial Buildings" };
            IndustrialBuildingsCategory = new Category() { Id = 5, Name = "Industrial Buildings" };
            FamilyHousesCategory = new Category() { Id = 6, Name = "Family Houses" };
            ReconstructionsAndRebuildingsCategory = new Category() { Id = 7, Name = "Reconstructions And Rebuildings" };
        }

        private void SeedPhases()
        {
            Design = new Phase() { Id = 1, Name = "Design" };
            Construction = new Phase() { Id = 2, Name = "Construction" };
            Use = new Phase() { Id = 3, Name = "Use" };
            EndOfService = new Phase() { Id = 4, Name = "End Of Service" };
        }

        private void SeedProjects()
        {
            FirstProject = new Project()
            {
                Id = 1,
                Title = "Multi-purpose building ONYX",
                Country = "Bulgaria",
                Town = "Sofia",
                Architect = "ProArch",
                YearDesigned = 2019,
                Description = "Total Build Up Area: 12 236,60 m2. Structural design: monolithic reinforced concrete and steel structure. Post-tensioning of the RC plates above lvl.+14.500. At lvl.+11.000 the building is cantilevered over three X-shaped steel columns. 3-dimensional modelling of the structure with Revit Structure. 3D FEM Analysis model with Robot Structural Analysis. Workshop drawings of the steel structure.",
                CategoryId = OfficeAndResidentialBuildingsCategory.Id,
                PhaseId = Construction.Id,
                DesignerId = FirstDesigner.Id,
                MainImageUrl = "https://localhost:7134/img/Projects/1/ONYX-01.jpg",
                Images = new List<string>() { "https://localhost:7134/img/Projects/1/ONYX-02.jpg",
                                              "https://localhost:7134/img/Projects/1/ONYX-03.jpg"}
            };

            SecondProject = new Project()
            {
                Id = 2,
                Title = "Multi-purpose building SEG",
                Country = "Bulgaria",
                Town = "Krivina",
                Architect = "Ivo Petrov Architects",
                YearDesigned = 2018,
                Description = "Total Build Up Area: 5 632 m2. Structural design: monolithic reinforced concrete and steel structure with post-tensioned concrete floors. BIM modeling, 3-dimensional modelling of the structure with Revit Structure. Advanced building simulation and analysis with Robot Structural Analysis. Workshop drawings of the steel structure. Тhis building is a participant in The National Contest „Building Of The Year 2019“ and has won a special award in the „Manufacturing and Logistics Buildings” category.",
                CategoryId = IndustrialBuildingsCategory.Id,
                PhaseId = Use.Id,
                DesignerId = FirstDesigner.Id,
                MainImageUrl = "https://localhost:7134/img/Projects/2/SEG-01.jpg",
                Images = new List<string>() { "https://localhost:7134/img/Projects/2/SEG-02.jpg",
                                              "https://localhost:7134/img/Projects/2/SEG-03.jpg"}
            };
        }
        
        private void SeedComments()
        {
            FirstProjectComment = new Comment()
            {
                Id = 1,
                Content = "This is a very difficult project!",
                Date = DateTime.Now,
                AuthorId = GuestUser.Id,
                ProjectId = FirstProject.Id,
            };
            SecondProjectComment = new Comment()
            {
                Id = 2,
                Content = "Pipe System made wonderful construction following the workshops. Great job!",
                Date = DateTime.Now.AddMonths(-1),
                AuthorId = GuestUser.Id,
                ProjectId = SecondProject.Id,
            };
        }

        private void SeedRates()
        {
            FirstProjectRate = new Rate()
            {
                Id = 1,
                IsPositive = true,
                AuthorId = GuestUser.Id,
                ProjectId = FirstProject.Id,
            };
            SecondProjectRate = new Rate()
            {
                Id = 2,
                IsPositive = true,
                AuthorId = GuestUser.Id,
                ProjectId = SecondProject.Id,
            };
        }
    }
}
