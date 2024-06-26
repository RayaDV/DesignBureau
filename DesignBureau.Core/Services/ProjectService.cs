﻿using DesignBureau.Core.Contracts;
using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Home;
using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository repository;
        private readonly IWebHostEnvironment webHostEnv;

        public ProjectService(IRepository repository, IWebHostEnvironment webHostEnv)
        {
            this.repository = repository;
            this.webHostEnv = webHostEnv;
        }

        public async Task<ProjectQueryServiceModel> AllAsync(
            string? category = null,
            string? phase = null,
            string? town = null,
            string? searchTerm = null,
            ProjectSorting sorting = ProjectSorting.LastAdded,
            int currentPage = 1,
            int projectsPerPage = 1)
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
                .Skip((currentPage - 1) * projectsPerPage)
                .Take(projectsPerPage)
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

        public async Task<ProjectQueryServiceModel> AllProjectsByDesignerIdAsync(
            int designerId,
            int currentPage = 1,
            int housesPerPage = 1)
        {
            var projects = repository.AllReadOnly<Project>()
                .Where(p => p.DesignerId == designerId);

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

        public async Task<IEnumerable<ProjectIndexServiceModel>> AllProjectsFromLastAsync()
        {
            return await repository
                .AllReadOnly<Project>()
                .OrderByDescending(p => p.Id)
                .Select(p => new ProjectIndexServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    MainImageUrl = p.MainImageUrl,
                    Country = p.Country,
                    Town = p.Town,
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

            Directory.CreateDirectory(this.webHostEnv.WebRootPath + $"/img/Projects/{project.Id}");

            return project.Id;
        }

        public async Task<bool> PhaseExistAsync(int phaseId)
        {
            return await repository.AllReadOnly<Phase>()
                .AnyAsync(ph => ph.Id == phaseId);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Project>()
                .AnyAsync(p => p.Id == id);
        }

        public async Task<ProjectDetailsServiceModel> ProjectDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Project>()
                .Where(p => p.Id == id)
                .ConvertToProjectDetailsServiceModel()
                .FirstAsync();
        }

        public async Task<bool> HasDesignerWithIdAsync(int projectId, string userId)
        {
            return await repository.AllReadOnly<Project>()
                .AnyAsync(p => p.Id == projectId && p.Designer.UserId == userId);
        }

        public async Task EditAsync(int projectId, ProjectFormViewModel model)
        {
            var project = await repository.GetByIdAsync<Project>(projectId);

            if (project != null)
            {
                project.Title = model.Title;
                project.Country = model.Country;
                project.Town = model.Town;
                project.MainImageUrl = model.MainImageUrl;
                project.Architect = model.Architect;
                project.YearDesigned = model.YearDesigned;
                project.Description = model.Description;
                project.CategoryId = model.CategoryId;
                project.PhaseId = model.PhaseId;

                await repository.SaveChangesAsync();
            }

        }

        public async Task<ProjectFormViewModel?> GetProjectFormViewModelByIdAsync(int id)
        {
            var project = await repository.AllReadOnly<Project>()
                .Where(h => h.Id == id)
                .ConvertToProjectFormViewModel()
                .FirstOrDefaultAsync();

            if (project != null)
            {
                project.Categories = await AllCategoriesAsync();
                project.Phases = await AllPhasesAsync();
            }

            return project;
        }

        public async Task DeleteAsync(int projectId)
        {
            await repository.DeleteAsync<Project>(projectId);
            await repository.SaveChangesAsync();

            //Directory.Delete(this.webHostEnv.WebRootPath + $"/img/Projects/{projectId}");
        }

        public async Task<ProjectServiceModel> ProjectToDeleteByIdAsync(int id)
        {
            return await repository.AllReadOnly<Project>()
                .Where(p => p.Id == id)
                .ConvertToProjectServiceModel()
                .FirstAsync();
        }

        public async Task<ProjectGalleryServiceModel> AllImagesByProjectIdAsync(int projectId)
        {
            var project = await repository.AllReadOnly<Project>()
                .Where(p => p.Id == projectId)
                .FirstAsync();

            return new ProjectGalleryServiceModel()
            {
                ProjectId = projectId,
                Title = project.Title,
                Gallery = project.Images,
            };
        }

        public async Task<AllProjectsGalleryViewModel> AllProjectsGalleryAsync(
            string? category = null,
            ProjectSorting sorting = ProjectSorting.LastAdded,
            int currentPage = 1,
            int projectsPerPage = 1)
        {
            var projects = repository.AllReadOnly<Project>();

            if (!string.IsNullOrWhiteSpace(category))
            {
                projects = projects.Where(p => p.Category.Name == category);
            }

            projects = sorting switch
            {
                ProjectSorting.LastDesigned => projects.OrderByDescending(p => p.YearDesigned)
                                                       .ThenByDescending(p => p.Id),
                ProjectSorting.TownAlphabetically => projects.OrderBy(p => p.Town)
                                                       .ThenByDescending(p => p.Id),
                _ => projects.OrderByDescending(p => p.Id)
            };

            var projectsToShow = await projects
                .Skip((currentPage - 1) * projectsPerPage)
                .Take(projectsPerPage)
                .ConvertToProjectAllGalleryServiceModel()
                .ToListAsync();

            return new AllProjectsGalleryViewModel()
            {
                Projects = projectsToShow,
                TotalProjectsCount = projects.Count()
            };
        }

        public async Task<ProjectInformationModel?> GetProjectInformationModelByIdAsync(int id)
        {
            return await repository.AllReadOnly<Project>()
                .Where(h => h.Id == id)
                .ConvertToProjectInformationModel()
                .FirstOrDefaultAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await repository.GetByIdAsync<Project>(id);
        }

        public async Task AddImagesToProjectAsync(List<string> images, int projectId)
        {
            var project = await repository.GetByIdAsync<Project>(projectId);
            if (project != null)
            {
                var projectImages = project.Images.ToHashSet();
                foreach (var image in images)
                {
                    projectImages.Add(image);
                }
                project.Images = projectImages;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> RemoveImageFromProjectAsync(string image, int projectId)
        {
            bool result = false;
            var project = await repository.GetByIdAsync<Project>(projectId);

            if (project != null)
            {
                var projectImages = project.Images.ToList();
                var removed = projectImages.Remove(image);

                if (removed)
                {
                    project.Images = projectImages;

                    await repository.SaveChangesAsync();
                    result = removed;
                }
            }

            return result;
        }
    }
}
