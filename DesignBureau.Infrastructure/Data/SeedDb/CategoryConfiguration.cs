﻿using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignBureau.Infrastructure.Data.SeedDb
{
    internal class CategoryConfiguration 
        : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[]
            {
                data.InternationalProjectsCategory,
                data.PublicBuildingsCategory,
                data.OfficeAndResidentialBuildingsCategory,
                data.CommercialBuildingsCategory,
                data.IndustrialBuildingsCategory,
                data.FamilyHousesCategory,
                data.ReconstructionsAndRebuildingsCategory
            });
        }
    }
}
