using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Designer
{
    public class DesignerServiceModel
    {

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

    }
}
