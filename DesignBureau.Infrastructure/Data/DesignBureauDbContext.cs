using DesignBureau.Infrastructure.Data.Models;
using DesignBureau.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Data
{
    public class DesignBureauDbContext : IdentityDbContext<ApplicationUser>
    {
        public DesignBureauDbContext(DbContextOptions<DesignBureauDbContext> options)
            : base(options)
        {
        }

        public DbSet<Discipline> Disciplines { get; set; } = null!;
        public DbSet<Designer> Designers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Phase> Phases { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Rate> Rates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new DisciplineConfiguration());
            builder.ApplyConfiguration(new DesignerConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new PhaseConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new RateConfiguration());

            base.OnModelCreating(builder);
        }

    }
}
