using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DesignBureau.Infrastructure.Constants.DataConstants;
using static DesignBureau.Core.Constants.MessageConstants;

namespace DesignBureau.Core.Models.Designer
{
    public class DesignerFormViewModel
	{
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DesignerNameMaxLength, MinimumLength = DesignerNameMinLength, 
            ErrorMessage = LengthMessage)]
        [Display(Name = "Designer Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(DesignerMinExperience, DesignerMaxExperience, 
            ConvertValueInInvariantCulture = true, 
            ErrorMessage = "Work experience must be not a negative number less than {2} years")]
        [Display(Name = "Work experience in years")]
        public int DesignExperience { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Designer Image URL")]
        public string DesignerImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Discipline")]
        [ForeignKey(nameof(Discipline))]
        public int DisciplineId { get; set; }

        public IEnumerable<DesignerDisciplineViewModel> Disciplines { get; set; }
            = new List<DesignerDisciplineViewModel>();
    }
}
