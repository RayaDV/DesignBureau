using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Data.Models;
using DesignBureau.Core.Models.Designer;

namespace System.Linq
{
    public static class IQueryableProjectExtension
    {
        public static IQueryable<ProjectServiceModel> ConvertToProjectServiceModel(this IQueryable<Project> projects)
        {
            return projects
                .Select(p => new ProjectServiceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Country = p.Country,
                    Town = p.Town,
                    MainImageUrl = p.MainImageUrl,
                    YearDesigned = p.YearDesigned,
                });
        }

		public static IQueryable<ProjectDetailsServiceModel> ConvertToProjectDetailsServiceModel(this IQueryable<Project> projects)
		{
            return projects
                .Select(p => new ProjectDetailsServiceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Country = p.Country,
                    Town = p.Town,
                    MainImageUrl = p.MainImageUrl,
                    YearDesigned = p.YearDesigned,
                    Architect = p.Architect,
                    Description = p.Description,
                    Category = p.Category.Name,
                    Phase = p.Phase.Name,
                    Designer = new DesignerServiceModel()
                    {
                        PhoneNumber = p.Designer.PhoneNumber,
                        Email = p.Designer.User.Email,
						FullName = $"{p.Designer.User.FirstName} {p.Designer.User.LastName}",
					},
                    
                });
		}
	}
}
