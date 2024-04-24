using DesignBureau.Core.Contracts;

namespace DesignBureau.Core.Models.Project
{
    public class ProjectInformationModel : IProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Town { get; set; } = string.Empty;
    }
}
