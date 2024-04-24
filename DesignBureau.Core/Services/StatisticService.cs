using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Statistic;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalProjects = await repository.AllReadOnly<Project>().CountAsync();
            int teamCount = await repository.AllReadOnly<Designer>().CountAsync();
            int totalComments = await repository.AllReadOnly<Comment>().CountAsync();
            int usersCount = await repository.AllReadOnly<ApplicationUser>().CountAsync();

            return new StatisticServiceModel() 
            { 
                TotalProjects = totalProjects, 
                TeamCount = teamCount, 
                TotalComments = totalComments, 
                UsersCount = usersCount 
            };
        }
    }
}
