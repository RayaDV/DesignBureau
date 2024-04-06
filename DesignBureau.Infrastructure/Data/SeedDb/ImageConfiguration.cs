using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignBureau.Infrastructure.Data.SeedDb
{
    internal class ImageConfiguration 
        : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasOne(i => i.Project)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Image[]
            {
                data.FirstProjectFirstImage,
                data.FirstProjectSecondImage,
                data.SecondProjectFirstImage,
                data.SecondProjectSecondImage,
            });
        }
    }
}
