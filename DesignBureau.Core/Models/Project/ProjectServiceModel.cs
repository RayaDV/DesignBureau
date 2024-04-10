using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DesignBureau.Core.Models.Project
{
    public class ProjectServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Town { get; set; } = string.Empty;

        [Display(Name = "Project main image URL")]
        public string MainImageUrl { get; set; } = string.Empty;

        [Display(Name = "Architect of the project")]
        public string Architect { get; set; } = string.Empty;

        [Display(Name = "Project year of design")]
        public int YearDesigned { get; set; }

        [Display(Name = "Project description")]
        public string Description { get; set; } = string.Empty;

    }
}