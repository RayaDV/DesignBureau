using System.ComponentModel.DataAnnotations;
using static DesignBureau.Core.Constants.MessageConstants;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Core.Models.Comment
{
    public class CommentFormViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CommentContentMaxLength, MinimumLength = CommentContentMinLength, ErrorMessage = LengthMessage)]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Date and Time")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Author")]
        public virtual string AuthorId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Project")]
        public virtual int ProjectId { get; set; }

    }
}
