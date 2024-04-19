using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.User
{
    public class UserAllServiceModel
    {
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Comments Count")]
        public int CommentsCount { get; set; }

        [Display(Name = "Is Designer")]
        public bool IsDesigner { get; set; }

        [Display(Name = "Projects Count")]
        public int ProjectsCount { get; set; }
    }
}
