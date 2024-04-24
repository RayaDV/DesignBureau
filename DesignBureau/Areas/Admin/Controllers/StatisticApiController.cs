using DesignBureau.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DesignBureau.Areas.Admin.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticService statisticService;

        public StatisticApiController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        [HttpGet]
        public async Task<OkObjectResult> GetStatistic()
        {
            var result = await statisticService.TotalAsync();

            return Ok(result);
        }
    }
}
