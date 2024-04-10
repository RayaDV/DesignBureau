namespace DesignBureau.Core.Models.Project
{
    public class MyProjectsViewModel
    {
        public const int HousesPerPage = 3;

        public int CurrentPage { get; init; } = 1;

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectServiceModel> Projects { get; set; }
            = new List<ProjectServiceModel>();
    }
}
