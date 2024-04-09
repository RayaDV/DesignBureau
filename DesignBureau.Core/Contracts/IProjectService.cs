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



    }
}
