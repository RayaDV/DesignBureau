using DesignBureau.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Project
{
    public class AllProjectsViewModel
    {
        public const int HousesPerPage = 3;

        public string Category { get; init; } = null!;

        public string Phase { get; init; } = null!;

        public string Town { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public ProjectSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProjectsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<string> Phases { get; set; } = null!;

        public IEnumerable<string> Towns { get; set; } = null!;

        public IEnumerable<ProjectServiceModel> Projects { get; set; } 
            = new List<ProjectServiceModel>();
    }
}
