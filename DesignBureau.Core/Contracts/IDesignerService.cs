using DesignBureau.Core.Models.Designer;

namespace DesignBureau.Core.Contracts
{
    public interface IDesignerService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> ExistsByEmailAsync(string email);

        Task CreateAsync(DesignerFormViewModel model, string userId);

        Task<int> GetDesignerIdAsync(string userId);

        Task<IEnumerable<DesignerDisciplineViewModel>> AllDisciplinesAsync();

        Task<bool> DisciplineExistsAsync(int disciplineId);
    }
}
