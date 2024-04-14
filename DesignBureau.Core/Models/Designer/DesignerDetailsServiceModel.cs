using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Designer
{
    public class DesignerDetailsServiceModel : DesignerServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Designer image URL")]
        public string DesignerImageUrl { get; set; } = string.Empty;

        [Display(Name = "Designer work experience in years")]
        public int? DesignExperience { get; set; }

        public int? ProjectsCount { get; set; }

        public string Discipline { get; set; } = string.Empty;
    }
}
