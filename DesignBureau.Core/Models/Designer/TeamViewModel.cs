using DesignBureau.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Designer
{
    public class TeamViewModel
    {
        public const int DesignersPerPage = 3;

        public string Discipline { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public DesignerSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalTeamCount { get; set; }

        public IEnumerable<string> Disciplines { get; set; } = null!;

        public IEnumerable<DesignerServiceModel> Team { get; set; }
            = new List<DesignerServiceModel>();
    }
}
