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
    internal class DisciplineConfiguration 
        : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            var data = new SeedData();

            builder.HasData(new Discipline[] 
            { data.ArchitectureDiscipline, 
                data.StructureDiscipline, 
                data.WssDiscipline, 
                data.HvacDiscipline, 
                data.GeodesyDiscipline, 
                data.LandscapingDiscipline 
            });
        }
    }
}
