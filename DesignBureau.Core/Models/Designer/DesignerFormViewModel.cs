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
        [EmailAddress]
        [Display(Name = "Designer Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Designer First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Designer Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DesignerPhoneNumberMaxLength, MinimumLength = DesignerPhoneNumberMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Designer Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

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

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("User identifier")]
        public virtual string UserId { get; set; } = string.Empty;

    }
}
