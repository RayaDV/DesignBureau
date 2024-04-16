using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Infrastructure.Data.Models
{
    [Comment("Designer of a project")]
    public class Designer
    {
        public Designer()
        {
            this.Projects = new List<Project>();
        }

        [Key]
        [Comment("Designer identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DesignerPhoneNumberMaxLength)] 
        [Comment("Designer phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Designer work experience in years")]
        public int? DesignExperience { get; set; }

        [Required]
        [Comment("Designer image URL")]
        public string DesignerImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Discipline identifier")]
        [ForeignKey(nameof(Discipline))]
        public int DisciplineId { get; set; }

        public virtual Discipline Discipline { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("User identifier")]
        public virtual string UserId { get; set; } = string.Empty;

        public virtual ApplicationUser User { get; set; } = null!;

        [Comment("Designer collection of projects")]
        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
