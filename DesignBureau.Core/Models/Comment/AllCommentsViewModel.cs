using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Designer;
using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Comment
{
    public class AllCommentsViewModel
    {
        public const int CommentsPerPage = 5;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public CommentSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCommentsCount { get; set; }

        public IEnumerable<CommentServiceModel> Comments { get; set; }
            = new List<CommentServiceModel>();
    }
}
