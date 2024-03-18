using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Data
{
    public class DesignBureauDbContext : IdentityDbContext
    {
        public DesignBureauDbContext(DbContextOptions<DesignBureauDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Discipline> Disciplines { get; set; } = null!;
        public DbSet<Designer> Designers { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
                .HasOne(p => p.Designer)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.DesignerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Image>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Designer>()
                .HasOne(d => d.Discipline)
                .WithMany(dis => dis.Designers)
                .HasForeignKey(d => d.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
