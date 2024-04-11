using DesignBureau.Core.Models.Designer;
using System.ComponentModel.DataAnnotations;

namespace DesignBureau.Core.Models.Project
{
    public class ProjectDetailsServiceModel : ProjectServiceModel
	{
		public string Architect { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Phase { get; set; } = string.Empty;

        public DesignerServiceModel Designer { get; set; } = null!;

		public IEnumerable<ProjectImageServiceModel> Gallery { get; set; }
				= new List<ProjectImageServiceModel>();
	}
}
