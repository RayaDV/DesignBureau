using DesignBureau.Core.Models.Comment;
using DesignBureau.Core.Models.Designer;

namespace DesignBureau.Core.Models.Project
{
    public class ProjectDetailsServiceModel : ProjectServiceModel
	{
		public string Architect { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Phase { get; set; } = string.Empty;

        public DesignerServiceModel Designer { get; set; } = null!;

        public IEnumerable<CommentServiceModel> Comments { get; set; } = new List<CommentServiceModel>();

	}
}
