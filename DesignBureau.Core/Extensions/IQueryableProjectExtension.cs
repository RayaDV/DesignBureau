using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Data.Models;

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
                    Architect = p.Architect,
                    YearDesigned = p.YearDesigned,
                    Description = p.Description,
                });
        }
    }
}
