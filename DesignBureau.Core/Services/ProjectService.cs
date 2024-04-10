using DesignBureau.Core.Contracts;
using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Home;
using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository repository;

        public ProjectService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ProjectQueryServiceModel> AllAsync(
            string? category = null, 
            string? phase = null, 
            string? town = null, 
            string? searchTerm = null, 
            ProjectSorting sorting = ProjectSorting.LastAdded, 
            int currentPage = 1, 
            int housesPerPage = 1)
        {
            var projects = repository.AllReadOnly<Project>();

            if (!string.IsNullOrWhiteSpace(category))
            {
                projects = projects.Where(p => p.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(phase))
            {
                projects = projects.Where(p => p.Phase.Name == phase);
            }

            if (!string.IsNullOrWhiteSpace(town))
            {
                projects = projects.Where(p => p.Town == town);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                projects = projects.Where(p => 
                    p.Title.ToLower().Contains(normalizedSearchTerm) ||
                    p.Country.ToLower().Contains(normalizedSearchTerm) ||
                    p.Town.ToLower().Contains(normalizedSearchTerm) ||
                    p.Architect.ToLower().Contains(normalizedSearchTerm) ||
                    p.Description.ToLower().Contains(normalizedSearchTerm));
            }

            projects = sorting switch
            {
                ProjectSorting.LastDesigned => projects.OrderByDescending(p => p.YearDesigned)
                                                       .ThenByDescending(p => p.Id),
                ProjectSorting.TownAlphabetically => projects.OrderBy(p => p.Town)
                                                       .ThenByDescending(p => p.Id),
                _ => projects.OrderByDescending(p => p.Id)
            };

            int totalProjectsCount = await projects.CountAsync();

            var projectsToShow = await projects
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ConvertToProjectServiceModel()
                .ToListAsync();

            return new ProjectQueryServiceModel()
            {
                TotalProjectsCount = totalProjectsCount,
                Projects = projectsToShow
            };
        }


        public async Task<IEnumerable<ProjectCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new ProjectCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectImageServiceModel>> AllImagesByProjectIdAsync(int projectId)
        {
            return await repository.AllReadOnly<Image>()
                .Where(i => i.ProjectId == projectId)
                .Select(i => new ProjectImageServiceModel()
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectPhaseServiceModel>> AllPhasesAsync()
        {
            return await repository.AllReadOnly<Phase>()
                .Select(ph => new ProjectPhaseServiceModel()
                {
                    Id = ph.Id,
                    Name = ph.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllPhasesNamesAsync()
        {
            return await repository.AllReadOnly<Phase>()
                .Select(ph => ph.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectIndexServiceModel>> AllProjectsFromLastAsync()
        {
            return await repository
                .AllReadOnly<Project>()
                .OrderByDescending(p => p.Id)
                .Select(p => new ProjectIndexServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    MainImageUrl = p.MainImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllTownsNamesAsync()
        {
            return await repository.AllReadOnly<Project>()
                .Select(p => p.Town)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExistAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(ProjectFormViewModel model, int designerId)
        {
            Project project = new Project()
            {
                Title = model.Title,
                Country = model.Country,
                Town = model.Town,
                MainImageUrl = model.MainImageUrl,
                Architect = model.Architect,
                YearDesigned = model.YearDesigned,
                Description = model.Description,
                CategoryId = model.CategoryId,
                PhaseId = model.PhaseId,
                DesignerId = designerId,
            };

            await repository.AddAsync(project);
            await repository.SaveChangesAsync();

            return project.Id;
        }

        public async Task<bool> PhaseExistAsync(int phaseId)
        {
            return await repository.AllReadOnly<Phase>()
                .AnyAsync(ph => ph.Id == phaseId);
        }
    }
}
