using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace DesignBureau.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
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

        public Project FirstProject { get; set; }
        public Project SecondProject { get; set; }

        public Image FirstProjectFirstImage { get; set; }
        public Image FirstProjectSecondImage { get; set; }
        public Image SecondProjectFirstImage { get; set; }
        public Image SecondProjectSecondImage { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedDisciplines();
            SeedDesigners();
            SeedCategories();
            SeedProjects();
            SeedImages();
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

            DesignerUser.PasswordHash =
                 hasher.HashPassword(DesignerUser, "raya123");

            GuestUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "dimitar@mail.com",
                NormalizedUserName = "DIMITAR@MAIL.COM",
                Email = "dimitar@mail.com",
                NormalizedEmail = "DIMITAR@MAIL.COM",
                FirstName = "Dimitar",
                LastName = "Dimitrov",
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "dimitar123");
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

        private void SeedProjects()
        {
            FirstProject = new Project()
            {
                Id = 1,
                Title = "Multi-purpose building ONYX",
                Country = "Bulgaria",
                Town = "Sofia",
                MainImageUrl = "https://localhost:7134/img/ONYX/ONYX-01.jpg",
                Architect = "ProArch",
                Phase = Models.Enums.PhaseType.Construction,
                YearDesigned = 2019,
                Description = "Total Build Up Area: 12 236,60 m2. Structural design: monolithic reinforced concrete and steel structure. Post-tensioning of the RC plates above lvl.+14.500. At lvl.+11.000 the building is cantilevered over three X-shaped steel columns. 3-dimensional modelling of the structure with Revit Structure. 3D FEM Analysis model with Robot Structural Analysis. Workshop drawings of the steel structure.",
                CategoryId = OfficeAndResidentialBuildingsCategory.Id,
                DesignerId = FirstDesigner.Id
            };

            SecondProject = new Project()
            {
                Id = 2,
                Title = "Multi-purpose building SEG",
                Country = "Bulgaria",
                Town = "Krivina",
                MainImageUrl = "https://localhost:7134/img/SEG/SEG-01.jpg",
                Architect = "Ivo Petrov Architects",
                Phase = Models.Enums.PhaseType.Use,
                YearDesigned = 2018,
                Description = "Total Build Up Area: 5 632 m2. Structural design: monolithic reinforced concrete and steel structure with post-tensioned concrete floors. BIM modeling, 3-dimensional modelling of the structure with Revit Structure. Advanced building simulation and analysis with Robot Structural Analysis. Workshop drawings of the steel structure. Тhis building is a participant in The National Contest „Building Of The Year 2019“ and has won a special award in the „Manufacturing and Logistics Buildings” category.",
                CategoryId = IndustrialBuildingsCategory.Id,
                DesignerId = FirstDesigner.Id
            };
        }

        private void SeedImages()
        {
            FirstProjectFirstImage =
                new Image()
                {
                    Id = 1,
                    ImageUrl = "https://localhost:7134/img/ONYX/ONYX-02.jpg",
                    ProjectId = FirstProject.Id
                };
            FirstProjectSecondImage =
                new Image()
                {
                    Id = 2,
                    ImageUrl = "https://localhost:7134/img/ONYX/ONYX-03.jpg",
                    ProjectId = FirstProject.Id
                };
            SecondProjectFirstImage =
                new Image()
                {
                    Id = 3,
                    ImageUrl = "https://localhost:7134/img/SEG/SEG-02.jpg",
                    ProjectId = SecondProject.Id
                };
            SecondProjectSecondImage =
                new Image()
                {
                    Id = 4,
                    ImageUrl = "https://localhost:7134/img/SEG/SEG-03.jpg",
                    ProjectId = SecondProject.Id
                };

            //FirstProjectImages = new List<Image>() {
            //    new Image()
            //    {
            //        Id = 1,
            //        ImageUrl = "https://localhost:7134/img/ONYX/ONYX-02.jpg",
            //        ProjectId = FirstProject.Id
            //    },
            //    new Image()
            //    {
            //        Id = 2,
            //        ImageUrl = "https://localhost:7134/img/ONYX/ONYX-03.jpg",
            //        ProjectId = FirstProject.Id
            //    }
            //};
            //SecondProjectImages = new List<Image>() {
            //    new Image()
            //    {
            //        Id = 3,
            //        ImageUrl = "https://localhost:7134/img/SEG/SEG-02.jpg",
            //        ProjectId = SecondProject.Id
            //    },
            //    new Image()
            //    {
            //        Id = 4,
            //        ImageUrl = "https://localhost:7134/img/SEG/SEG-03.jpg",
            //        ProjectId = SecondProject.Id
            //    }
            // };
        }
    }
}
