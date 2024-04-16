using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Infrastructure.Data.Models
{
    [Comment("Project phase")]
    public class Phase
    {
        public Phase()
        {
            this.Projects = new List<Project>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Phase identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PhaseNameMaxLength)]
        [Comment("Phase name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Projects in same phase")]
        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
