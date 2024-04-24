using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Home;
using DesignBureau.Core.Models.Project;
using DesignBureau.Infrastructure.Data.Models;

namespace DesignBureau.Core.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectIndexServiceModel>> AllProjectsFromLastAsync();

        Task<IEnumerable<ProjectCategoryServiceModel>> AllCategoriesAsync();

        Task<IEnumerable<ProjectPhaseServiceModel>> AllPhasesAsync();

        Task<bool> CategoryExistAsync(int categoryId);

        Task<bool> PhaseExistAsync(int phaseId);

        Task<int> CreateAsync(ProjectFormViewModel model, int designerId);

        Task<ProjectQueryServiceModel> AllAsync(
                string? category = null,
                string? phase = null,
                string? town = null,
                string? searchTerm = null,
                ProjectSorting sorting = ProjectSorting.LastAdded,
                int currentPage = 1,
                int projectsPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<string>> AllPhasesNamesAsync();

        Task<IEnumerable<string>> AllTownsNamesAsync();

        Task<ProjectQueryServiceModel> AllProjectsByDesignerIdAsync(
                int designerId,
                int currentPage = 1,
                int housesPerPage = 1);

		Task<bool> ExistsByIdAsync(int id);

		Task<ProjectDetailsServiceModel> ProjectDetailsByIdAsync(int id);

        Task<bool> HasDesignerWithIdAsync(int projectId, string userId);

        Task EditAsync(int projectId, ProjectFormViewModel model);

        Task<ProjectFormViewModel?> GetProjectFormViewModelByIdAsync(int id);

        Task DeleteAsync(int projectId);

		Task<ProjectServiceModel> ProjectToDeleteByIdAsync(int id);

        Task<ProjectGalleryServiceModel> AllImagesByProjectIdAsync(int projectId);

        Task<AllProjectsGalleryViewModel> AllProjectsGalleryAsync(
            string? category = null,
            ProjectSorting sorting = ProjectSorting.LastAdded,
            int currentPage = 1,
            int projectsPerPage = 1);

        Task<ProjectInformationModel?> GetProjectInformationModelByIdAsync(int id);

        Task<Project?> GetProjectByIdAsync(int id);

        Task AddImagesToProjectAsync(List<string> images, int projectId);

        Task<bool> RemoveImageFromProjectAsync(string image, int projectId);
    }
}
