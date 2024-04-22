using DesignBureau.Core.Enums;
using DesignBureau.Core.Models.Admin.Designer;
using DesignBureau.Core.Models.Designer;

namespace DesignBureau.Core.Contracts
{
    public interface IDesignerService
    {
        Task<bool> ExistsByIdAsync(int Id);

        Task<bool> ExistsByUserIdAsync(string userId);

        Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> ExistsByEmailAsync(string email);

        Task<int> GetDesignerIdAsync(string userId);

        Task CreateAsync(DesignerFormViewModel model, string userId);

        Task<IEnumerable<DesignerDisciplineServiceModel>> AllDisciplinesAsync();

        Task<IEnumerable<string>> AllDisciplinesNamesAsync();

        Task<bool> DisciplineExistsAsync(int disciplineId);

        Task<DesignerQueryServiceModel> TeamAsync(
        string? discipline = null,
        string? searchTerm = null,
        DesignerSorting sorting = DesignerSorting.NameAlphabetically,
        int currentPage = 1,
        int designersPerPage = 1);

        Task<DesignerFormViewModel?> GetDesignerFormViewModelByIdAsync(int id);

        Task EditAsync(int designerId, DesignerFormViewModel model);

        Task DeleteAsync(int designerId);

        Task<DesignerDetailsServiceModel> DesignerToDeleteByIdAsync(int designerId);
    }
}
