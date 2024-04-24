using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignBureau.Infrastructure.Data.SeedDb
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder
                .HasOne(r => r.Author)
                .WithMany(r => r.Rates)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(r => r.Project)
                .WithMany(p => p.Rates)
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Rate[]
            {
                data.FirstProjectRate,
                data.SecondProjectRate
            });
        }
    }
}
