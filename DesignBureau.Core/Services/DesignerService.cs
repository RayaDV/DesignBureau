using DesignBureau.Core.Contracts;
using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Admin.Designer;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.Project;
using DesignBureau.Core.Models.User;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Core.Services
{
    public class DesignerService : IDesignerService
    {
        private readonly IRepository repository;

        public DesignerService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(DesignerFormViewModel model, string userId)
        {
            Designer designer = new Designer()
            {
                UserId = userId,
                PhoneNumber = model.PhoneNumber,
                DesignExperience = model.DesignExperience,
                DesignerImageUrl = model.DesignerImageUrl,
                DisciplineId = model.DisciplineId,
            };

            await repository.AddAsync(designer);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Designer>()
                .AnyAsync(d => d.PhoneNumber == phoneNumber);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await repository.AllReadOnly<Designer>()
                .AnyAsync(d => d.User.Email == email);
        }

        public async Task<bool> ExistsByUserIdAsync(string userId)
        {
            return await repository.AllReadOnly<Designer>()
                .AnyAsync(d => d.UserId == userId);
        }

        public async Task<int> GetDesignerIdAsync(string userId)
        {
            var designer = await repository.AllReadOnly<Designer>()
                .FirstAsync(d => d.UserId == userId);
            return designer.Id;
        }

        public async Task<IEnumerable<DesignerDisciplineServiceModel>> AllDisciplinesAsync()
        {
            return await repository
                .AllReadOnly<Discipline>()
                .Select(d => new DesignerDisciplineServiceModel
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

        public async Task<bool> DisciplineExistsAsync(int disciplineId)
        {
            return await repository.AllReadOnly<Discipline>()
                .AnyAsync(d => d.Id == disciplineId);
        }

        public async Task<DesignerQueryServiceModel> AllAsync(
            string? discipline = null, 
            string? searchTerm = null, 
            DesignerSorting sorting = DesignerSorting.NameAlphabetically, 
            int currentPage = 1, 
            int designersPerPage = 1)
        {
            var team = repository.AllReadOnly<Designer>();

            if (!string.IsNullOrWhiteSpace(discipline))
            {
                team = team.Where(d => d.Discipline.Name == discipline);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                team = team.Where(d => 
                    d.User.FirstName.ToLower().Contains(normalizedSearchTerm) ||
                    d.User.LastName.ToLower().Contains(normalizedSearchTerm));
            }

            team = sorting switch
            {
                DesignerSorting.MostExperienced => team.OrderByDescending(d => d.DesignExperience)
                                                       .ThenBy(d => d.User.FirstName)
                                                       .ThenBy(d => d.User.LastName),
                DesignerSorting.MostProjects => team.OrderByDescending(d => d.Projects.Count())
                                                    .ThenBy(d => d.User.FirstName)
                                                    .ThenBy(d => d.User.LastName),
                _ => team.OrderBy(d => d.User.FirstName)
                         .ThenBy(d => d.User.LastName)
                         .ThenByDescending(d => d.DesignExperience)
                         .ThenByDescending(d => d.Projects.Count())
            };

            int totalTeamCount = await team.CountAsync();

            var teamToShow = await team
                .Skip((currentPage - 1) * designersPerPage)
                .Take(designersPerPage)
                .ConvertToDesignerDetailsServiceModel()
                .ToListAsync();

            return new DesignerQueryServiceModel()
            {
                TotalTeamCount = totalTeamCount,
                Team = teamToShow
            };
        }

        public async Task<IEnumerable<string>> AllDisciplinesNamesAsync()
        {
            return await repository.AllReadOnly<Discipline>()
                .Select(d => d.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Designer>()
                .AnyAsync(d => d.Id == id);
        }

        public async Task<DesignerFormViewModel?> GetDesignerFormViewModelByIdAsync(int id)
        {
            var designer = await repository.AllReadOnly<Designer>()
                .Where(d => d.Id == id)
                .ConvertToDesignerFormViewModel()
                .FirstOrDefaultAsync();

            if (designer != null)
            {
                designer.Disciplines = await AllDisciplinesAsync();
            }

            return designer;
        }

        public async Task EditAsync(int designerId, DesignerFormViewModel model)
        {
            var designer = await repository.GetByIdAsync<Designer>(designerId);

            if (designer != null)
            {
                var user = await repository.GetByIdAsync<ApplicationUser>(designer.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.NormalizedEmail = model.Email.ToUpper();
                    user.NormalizedUserName = model.Email.ToUpper();
                }

                designer.PhoneNumber = model.PhoneNumber;
                designer.DesignerImageUrl = model.DesignerImageUrl;
                designer.DesignExperience = model.DesignExperience;
                designer.DisciplineId = model.DisciplineId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int designerId)
        {
            var designer = repository.GetByIdAsync<Designer>(designerId);
            if (designer != null)
            {
                string userId = designer.Result.UserId;
                await repository.DeleteAsync<ApplicationUser>(userId);
            }
            await repository.DeleteAsync<Designer>(designerId);
            await repository.SaveChangesAsync();
        }

        public async Task<DesignerDetailsServiceModel> DesignerToDeleteByIdAsync(int designerId)
        {
            return await repository.AllReadOnly<Designer>()
                .Where(d => d.Id == designerId)
                .ConvertToDesignerDetailsServiceModel()
                .FirstAsync();
        }
    }
}
