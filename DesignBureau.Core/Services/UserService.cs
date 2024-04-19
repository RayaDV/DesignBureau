using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.User;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DesignBureau.Infrastructure.Constants.CustomClaims;

namespace DesignBureau.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<UserAllServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Include(u => u.Designer)
                .Select(u => new UserAllServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.Designer != null ? u.Designer.PhoneNumber : null,
                    IsDesigner = u.Designer != null,
                    CommentsCount = u.Comments.Count(),
                })
                .ToListAsync();
        }

        public async Task<string> CreateAsync(UserServiceModel model)
        {
            string id = Guid.NewGuid().ToString();

            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                UserName = model.Email,
                NormalizedUserName = model.Email.ToUpper(),
                Id = id,
            };

            //var pass = PasswordGenerator.Generate();
            var pass = $"{user.FirstName.ToLower()}{user.LastName.ToLower()}123";
            var hasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = hasher.HashPassword(user, pass);

            var userClaim = new IdentityUserClaim<string>()
            {
                ClaimType = UserFullNameClaim,
                ClaimValue = $"{model.FirstName} {model.LastName}",
                UserId = id
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            return id;
        }

        public async Task DeleteAsync(string userId)
        {
            await repository.DeleteAsync<ApplicationUser>(userId);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .AnyAsync(u => u.Id == userId);
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            return await repository.GetByEmailAsync<ApplicationUser>(email);
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            return await repository.GetByIdAsync<ApplicationUser>(userId);
        }

        public async Task<string> UserFullNameAsync(string userId)  // never used in nav bar, because it is made with claim
        {
            string result = string.Empty;
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }


    }
}
