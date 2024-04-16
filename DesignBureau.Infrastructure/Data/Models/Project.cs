using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Infrastructure.Data.Models
{
    [Comment("A project to describe")]
    public class Project
    {
        public Project()
        {
            this.Images = new List<Image>();
            this.Comments = new List<Comment>();
            this.Rates = new List<Rate>();
        }

        [Key]
        [Comment("Project identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProjectTitleMaxLength)]
        [Comment("Project title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProjectCountryMaxLength)]
        [Comment("Project country")]
        public string Country { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProjectTownMaxLength)]
        [Comment("Project town")]
        public string Town { get; set; } = string.Empty;

        [Required]
        [Comment("Project main image URL")]
        public string MainImageUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProjectArchitectMaxLength)]
        [Comment("Architect of the project")]
        public string Architect { get; set; } = string.Empty;

        [Required]
        [Comment("Project year of design")]
        //[Range(ProjectYearMinValue, ProjectYearMaxValue)] 
        public int YearDesigned { get; set; }

        [Required]
        [MaxLength(ProjectDescriptionMaxLength)]
        [Comment("Project description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Category identifier")]
        [ForeignKey(nameof(Category))]
        public virtual int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        [Required]
        [Comment("Phase identifier")]
        [ForeignKey(nameof(Phase))]
        public virtual int PhaseId { get; set; }

        public virtual Phase Phase { get; set; } = null!;

        [Required]
        [Comment("Designer identifier")]
        [ForeignKey(nameof(Designer))]
        public virtual int DesignerId { get; set; }

        public virtual Designer Designer { get; set; } = null!;

        [Required]
        [Comment("Project collection of images")]
        public virtual IEnumerable<Image> Images { get; set; }

        [Comment("Project collection of comments")]
        public virtual IEnumerable<Comment> Comments { get; set; }

        [Comment("Project collection of rates")]
        public virtual IEnumerable<Rate> Rates { get; set; }
    }
}
