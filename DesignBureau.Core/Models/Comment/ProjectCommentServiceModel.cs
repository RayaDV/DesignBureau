

using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Comment
{
    public class ProjectCommentServiceModel
    {
        public int Id { get; set; }

        public string AuthorId { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public string Content { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty;

        [Display(Name = "Author full name")]
        public string FullName { get; set; } = string.Empty;
    }
}
