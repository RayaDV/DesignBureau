using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Infrastructure.Data.Models
{
    [Comment("Designer discipline")]
    public class Discipline
    {
        public Discipline()
        {
            this.Designers = new List<Designer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Discipline identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DisciplineNameMaxLength)]
        [Comment("Discipline name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Designers from one discipline")]
        public virtual IEnumerable<Designer> Designers { get; set; }
    }
}
