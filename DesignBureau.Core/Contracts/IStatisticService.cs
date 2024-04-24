using DesignBureau.Core.Models.Statistic;

namespace DesignBureau.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
