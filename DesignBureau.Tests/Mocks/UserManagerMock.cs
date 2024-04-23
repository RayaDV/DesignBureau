using DesignBureau.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;

namespace ProjectHub.Tests.Mocks
{
    public static class UserManagerMock
    {
        public static UserManager<ApplicationUser> Instance
        {
            get
            {
                var store = new Mock<IUserStore<ApplicationUser>>();
                var userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);

                userManager.Setup(um => um.AddClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>())).Returns(Task.FromResult(IdentityResult.Success));

                return userManager.Object;
            }
        }

    }
}
