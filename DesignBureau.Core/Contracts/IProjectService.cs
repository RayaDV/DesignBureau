using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Home;
using DesignBureau.Core.Models.Project;

namespace DesignBureau.Core.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectIndexServiceModel>> AllProjectsFromLastAsync();

        Task<IEnumerable<ProjectCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistAsync(int categoryId);

        Task<IEnumerable<ProjectPhaseServiceModel>> AllPhasesAsync();

        Task<bool> PhaseExistAsync(int phaseId);

        Task<int> CreateAsync(ProjectFormViewModel model, int designerId);

        Task<IEnumerable<ProjectImageServiceModel>> AllImagesByProjectIdAsync(int projectId);

        Task<ProjectQueryServiceModel> AllAsync(
                string? category = null,
                string? phase = null,
                string? town = null,
                string? searchTerm = null,
                ProjectSorting sorting = ProjectSorting.LastAdded,
                int currentPage = 1,
                int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<string>> AllPhasesNamesAsync();

        Task<IEnumerable<string>> AllTownsNamesAsync();


    }
}
