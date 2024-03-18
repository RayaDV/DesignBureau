using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Infrastructure.Data.Models
{
    [Comment("Project image")]
    public class Image
    {
        [Key]
        [Comment("Image identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Project Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(Project))]
        [Comment("Project identifier")]
        public virtual int ProjectId {  get; set; }

        public virtual Project Project { get; set; } = null!;

    }
}
