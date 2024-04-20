using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Data.Models;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.Comment;
using DesignBureau.Infrastructure.Constants;

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
                    Comments = p.Comments.Select(c => new ProjectCommentServiceModel()
                    {
                        Id = c.Id,
                        ProjectId = c.ProjectId,
                        AuthorId = c.AuthorId,
                        Content = c.Content,
                        Date = c.Date.ToString(DataConstants.DateFormat),
                        FullName = $"{c.Author.FirstName} {c.Author.LastName}",
                    }),
                }); ;
		}

        public static IQueryable<ProjectFormViewModel> ConvertToProjectFormViewModel(this IQueryable<Project> projects)
        {
            return projects
                .Select(p => new ProjectFormViewModel()
                {
                    Title = p.Title,
                    Country = p.Country,
                    Town = p.Town,
                    MainImageUrl = p.MainImageUrl,
                    YearDesigned = p.YearDesigned,
                    Architect = p.Architect,
                    Description = p.Description,
                    CategoryId  = p.CategoryId,
                    PhaseId = p.PhaseId,
                });
        }

        public static IQueryable<ProjectAllGalleryServiceModel> ConvertToProjectAllGalleryServiceModel(this IQueryable<Project> projects)
        {
            return projects
                .Select(p => new ProjectAllGalleryServiceModel()
                {
                    ProjectId = p.Id,
                    Title = p.Title,
                    MainImageUrl = p.MainImageUrl,
                });
        }

        public static IQueryable<ProjectGalleryServiceModel> ConvertToProjectGalleryServiceModel(this IQueryable<Project> projects)
        {
            return projects
                .Select(p => new ProjectGalleryServiceModel()
                {
                    ProjectId = p.Id,
                    Title = p.Title,
                    Gallery = p.Images,
                });
        }

        public static IQueryable<ProjectInformationModel> ConvertToProjectInformationModel(this IQueryable<Project> projects)
        {
            return projects
                .Select(p => new ProjectInformationModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Country = p.Country,
                    Town = p.Town,
                });
        }
    }
}
