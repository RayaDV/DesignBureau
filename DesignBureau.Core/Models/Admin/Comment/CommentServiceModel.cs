using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Admin.Comment
{
    public class CommentServiceModel
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty;

        public string AuthorId { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        [Display(Name = "Author full name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Author email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Project Title")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Project main image URL")]
        public string ProjectImageUrl { get; set; } = string.Empty;
    }
}
