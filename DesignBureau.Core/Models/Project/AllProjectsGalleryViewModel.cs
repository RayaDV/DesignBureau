using DesignBureau.Core.Enums;

namespace DesignBureau.Core.Models.Project
{
    public class AllProjectsGalleryViewModel
    {
        public const int ProjectsPerPage = 6;

        public int CurrentPage { get; init; } = 1;

        public int TotalProjectsCount { get; set; }

        public ProjectSorting Sorting { get; init; }

        public string Category { get; init; } = null!;

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<ProjectAllGalleryServiceModel> Projects { get; set; }
            = new List<ProjectAllGalleryServiceModel>();
    }
}
