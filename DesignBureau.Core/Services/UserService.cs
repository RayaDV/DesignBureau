using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Admin.User;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.User;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static DesignBureau.Infrastructure.Constants.CustomClaims;

namespace DesignBureau.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
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
                    ProjectsCount = u.Designer != null ? u.Designer.Projects.Count() : 0,
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
            var pass = $"{user.FirstName.ToLower()}123";
            var hasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = hasher.HashPassword(user, pass);

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            await userManager.AddClaimAsync(user, new Claim(
                UserFullNameClaim, $"{user.FirstName} {user.LastName}"));
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

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            return await repository.GetByIdAsync<ApplicationUser>(userId);
        }

        public async Task<string> UserFullNameAsync(string userId)  
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
