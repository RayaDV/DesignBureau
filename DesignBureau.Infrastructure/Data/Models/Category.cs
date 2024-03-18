using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Infrastructure.Data.Models
{
    [Comment("Project category")]
    public class Category
    {
        public Category()
        {
            this.Projects = new List<Project>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
