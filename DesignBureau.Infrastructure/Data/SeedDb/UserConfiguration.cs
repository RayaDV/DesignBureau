﻿using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignBureau.Infrastructure.Data.SeedDb
{
    internal class UserConfiguration 
        : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new ApplicationUser[] 
            { 
                data.DesignerUser,
                data.GuestUser,
                data.AdminUser,
            });
        }
    }
}
