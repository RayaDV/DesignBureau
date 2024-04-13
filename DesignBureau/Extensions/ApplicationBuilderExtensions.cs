using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static DesignBureau.Core.Constants.AdminConstants;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRoleName) == false)
            {
                var role = new IdentityRole(AdminRoleName);
                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync(AdminEmail);

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, AdminRoleName);
                }
            }
        }

    }
}
