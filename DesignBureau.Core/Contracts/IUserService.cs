using DesignBureau.Core.Models.Admin.User;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.User;
using DesignBureau.Infrastructure.Data.Models;

namespace DesignBureau.Core.Contracts
{
    public interface IUserService
    {
        Task<string> CreateAsync(UserServiceModel model);

        Task<string> UserFullNameAsync(string userId);

        Task<bool> ExistsByIdAsync(string userId);

        Task<ApplicationUser?> GetUserByIdAsync(string userId);

        Task<ApplicationUser?> GetUserByEmailAsync(string email);

        Task DeleteAsync(string userId);

        Task<IEnumerable<UserAllServiceModel>> AllAsync();

    }
}
