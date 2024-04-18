using DesignBureau.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Project
{
    public class ProjectServiceModel : IProjectModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Town { get; set; } = string.Empty;

        [Display(Name = "Project main image URL")]
        public string MainImageUrl { get; set; } = string.Empty;

        [Display(Name = "Project year of design")]
        public int YearDesigned { get; set; }
    }
}