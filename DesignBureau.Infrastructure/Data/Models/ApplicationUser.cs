using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DesignBureau.Infrastructure.Constants.DataConstants;

namespace DesignBureau.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [PersonalData]
        [Comment("User First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [PersonalData]
        [Comment("User Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Url]
        [PersonalData]
        [Comment("User Facebook Page")]
        public string FacebookPage { get; set; } = string.Empty;

        [Url]
        [PersonalData]
        [Comment("User LinkedIn Page")]
        public string LinkedInPage { get; set; } = string.Empty;

        [Url]
        [PersonalData]
        [Comment("User Skype Profile")]
        public string SkypeProfile { get; set; } = string.Empty;
    }
}
