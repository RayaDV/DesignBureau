using DesignBureau.Core.Contracts;

namespace DesignBureau.Core.Models.Home
{
    public class ProjectIndexServiceModel : IProjectModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string MainImageUrl { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Town { get; set; } = string.Empty;
    }
}
