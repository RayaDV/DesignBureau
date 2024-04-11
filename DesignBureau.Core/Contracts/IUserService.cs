using DesignBureau.Core.Models.User;

namespace DesignBureau.Core.Contracts
{
    public interface IUserService
    {
        Task<string> CreateAsync(RegisterUserViewModel model);

        Task<string> UserFullNameAsync(string userId);

        Task<bool> ExistsByIdAsync(string userId);

    }
}
