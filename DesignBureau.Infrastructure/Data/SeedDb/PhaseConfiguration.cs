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
    internal class PhaseConfiguration : IEntityTypeConfiguration<Phase>
    {
        public void Configure(EntityTypeBuilder<Phase> builder)
        {
            var data = new SeedData();

            builder.HasData(new Phase[]
            {
                data.Design,
                data.Construction,
                data.Use,
                data.EndOfService,
            });
        }
    }
}
