using System.ComponentModel.DataAnnotations;
using static DesignBureau.Core.Constants.MessageConstants;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Core.Models.Project
{
    public class ProjectFormViewModel
	{
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProjectTitleMaxLength, MinimumLength = ProjectTitleMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Project Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProjectCountryMaxLength, MinimumLength = ProjectCountryMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Project Country")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProjectTownMaxLength, MinimumLength = ProjectTownMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Project Town")]
        public string Town { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Project Main Image URL")]
        public string MainImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProjectArchitectMaxLength)]
        [Display(Name = "Architect of the Project")]
        public string Architect { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredMessage)]
        [Range(ProjectYearMinValue, ProjectYearMaxValue)]
        [Display(Name = "Project Year of Design")]
        public int YearDesigned { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProjectDescriptionMaxLength, MinimumLength = ProjectDescriptionMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Project Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Phase")]
        public int PhaseId { get; set; }

        public IEnumerable<ProjectCategoryServiceModel> Categories { get; set; } 
            = new List<ProjectCategoryServiceModel>();

        public IEnumerable<ProjectPhaseServiceModel> Phases { get; set; }
            = new List<ProjectPhaseServiceModel>();

        public IEnumerable<ProjectImageServiceModel> Gallery {  get; set; } 
            = new List<ProjectImageServiceModel>();
    }
}
