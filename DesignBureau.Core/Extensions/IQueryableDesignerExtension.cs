using DesignBureau.Core.Models.Admin.Designer;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQueryableDesignerExtension
    {
        public static IQueryable<DesignerDetailsServiceModel> ConvertToDesignerDetailsServiceModel(this IQueryable<Designer> designers)
        {
            return designers
                .Select(d => new DesignerDetailsServiceModel()
                {
                    Id = d.Id,
                    FullName = $"{d.User.FirstName} {d.User.LastName}",
                    Email = d.User.Email,
                    PhoneNumber = d.PhoneNumber,
                    DesignerImageUrl = d.DesignerImageUrl,
                    DesignExperience = d.DesignExperience,
                    Discipline = d.Discipline.Name,
                    ProjectsCount = d.Projects.Count()
                });
        }

        public static IQueryable<DesignerFormViewModel> ConvertToDesignerFormViewModel(this IQueryable<Designer> designers)
        {
            return designers
                .Select(d => new DesignerFormViewModel()
                {
                    Email = d.User.Email,
                    FirstName = d.User.FirstName,
                    LastName = d.User.LastName,
                    PhoneNumber = d.PhoneNumber,
                    DesignExperience = d.DesignExperience,
                    DesignerImageUrl = d.DesignerImageUrl,
                    DisciplineId = d.DisciplineId
                });
        }
    }
}
