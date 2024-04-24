using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Infrastructure.Data.Models
{
    [Comment("Rate of a project")]
    public class Rate
    {
        [Key]
        [Comment("Rate identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier if the rate is positive")]
        public bool IsPositive { get; set; }

        [Required]
        [Comment("Author identifier")]
        [ForeignKey(nameof(Author))]
        public virtual string AuthorId { get; set; } = string.Empty;

        public virtual ApplicationUser Author { get; set; } = null!;

        [Required]
        [Comment("Project identifier")]
        [ForeignKey(nameof(Project))]
        public virtual int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;

    }
}
