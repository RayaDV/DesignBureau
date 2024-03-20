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
    internal class DesignerConfiguration 
        : IEntityTypeConfiguration<Designer>
    {
        public void Configure(EntityTypeBuilder<Designer> builder)
        {
            builder
                .HasOne(d => d.Discipline)
                .WithMany(dis => dis.Designers)
                .HasForeignKey(d => d.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Designer[]
            {
                data.Architect,
                data.StructuralEngineer
            });
        }
    }
}
