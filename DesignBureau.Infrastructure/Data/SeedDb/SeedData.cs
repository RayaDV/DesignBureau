﻿using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace DesignBureau.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser DesignerUser { get; set; }
        public IdentityUser GuestUser { get; set; }

        public Discipline ArchitectureDiscipline { get; set; }
        public Discipline StructureDiscipline { get; set; }
        public Discipline ElectroDiscipline { get; set; }
        public Discipline WssDiscipline { get; set; }
        public Discipline HvacDiscipline { get; set; }
        public Discipline GeodesyDiscipline { get; set; }
        public Discipline LandscapingDiscipline { get; set; }

        public Designer Architect { get; set; }
        public Designer StructuralEngineer { get; set; }

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
            var hasher = new PasswordHasher<IdentityUser>();

            DesignerUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "designer@mail.com",
                NormalizedUserName = "designer@mail.com",
                Email = "designer@mail.com",
                NormalizedEmail = "designer@mail.com"
            };

            DesignerUser.PasswordHash =
                 hasher.HashPassword(DesignerUser, "designer123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "guest123");
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
            Architect = new Designer()
            {
                Id = 1,
                Name = "Dipl.Arch. Christina Kroumova",
                Email = "kristina.krumova@e.kroumov.com",
                DesignExperience = 18,
                DesignerImageUrl = "",
                DisciplineId = ArchitectureDiscipline.Id,
                UserId = DesignerUser.Id
            };

            StructuralEngineer = new Designer()
            {
                Id = 2,
                Name = "Dipl.Eng. Raya Velichkova",
                Email = "raya@e.kroumov.com",
                DesignExperience = 13,
                DesignerImageUrl = "",
                DisciplineId = StructureDiscipline.Id,
                UserId = DesignerUser.Id
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
                DesignerId = StructuralEngineer.Id
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
                DesignerId = StructuralEngineer.Id
            };
        }

        private void SeedImages()
        {
            FirstProjectFirstImage = new Image() 
            { 
                Id = 1, 
                ImageUrl = "https://localhost:7134/img/ONYX/ONYX-02.jpg", 
                ProjectId = FirstProject.Id 
            };
            FirstProjectSecondImage = new Image() 
            { Id = 2, 
                ImageUrl = "https://localhost:7134/img/ONYX/ONYX-03.jpg", 
                ProjectId = FirstProject.Id 
            };
            SecondProjectFirstImage = new Image() 
            { 
                Id = 3, 
                ImageUrl = "https://localhost:7134/img/SEG/SEG-02.jpg", 
                ProjectId = SecondProject.Id 
            };
            SecondProjectSecondImage = new Image() 
            { 
                Id = 4, 
                ImageUrl = "https://localhost:7134/img/SEG/SEG-03.jpg", 
                ProjectId = SecondProject.Id 
            };
        }

    }
}
