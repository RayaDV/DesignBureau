using DesignBureau.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Infrastructure.Data.Models
{
    [Comment("Comment of a project")]
    public class Comment
    {
        [Key]
        [Comment("Comment identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CommentContentMaxLength)]
        [Comment("Comment content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Date and time when the comment is send")]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey(nameof(Author))]
        [Comment("Author identifier")]
        public virtual string AuthorId { get; set; } = string.Empty;

        public virtual ApplicationUser Author { get; set; } = null!;

        [Required]
        [Comment("Project identifier")]
        [ForeignKey(nameof(Project))]
        public virtual int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;

    }
}
