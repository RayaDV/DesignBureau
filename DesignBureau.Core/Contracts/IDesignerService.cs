using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Designer;

namespace DesignBureau.Core.Contracts
{
    public interface IDesignerService
    {
        Task<bool> ExistsByUserIdAsync(string userId);

        Task<bool> ExistsByPhoneNumberAsync(string email);

        Task<bool> ExistsByEmailAsync(string email);

        Task CreateAsync(DesignerFormViewModel model, string userId);

        Task<int> GetDesignerIdAsync(string userId);

        Task<IEnumerable<DesignerDisciplineServiceModel>> AllDisciplinesAsync();

        Task<bool> DisciplineExistsAsync(int disciplineId);

        Task<DesignerQueryServiceModel> TeamAsync(
        string? discipline = null,
        string? searchTerm = null,
        DesignerSorting sorting = DesignerSorting.NameAlphabetically,
        int currentPage = 1,
        int designersPerPage = 1);

        Task<IEnumerable<string>> AllDisciplinesNamesAsync();

        Task<bool> ExistsByIdAsync(int Id);

        Task<DesignerFormViewModel?> GetDesignerFormViewModelByIdAsync(int id);

        Task EditAsync(int designerId, DesignerFormViewModel model);

        Task DeleteAsync(int designerId);

        Task<DesignerDetailsServiceModel> DesignerToDeleteByIdAsync(int designerId);
    }
}
