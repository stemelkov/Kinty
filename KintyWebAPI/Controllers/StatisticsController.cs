using KintyDatabase.Access;
using Microsoft.AspNetCore.Mvc;

namespace KintyWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/statistics")]
    public class StatisticsController : Controller
    {
        [HttpGet]
        [Route("balance")]
        public decimal GetBalance()
        {
            var balance = KintyStats.GetBalance();
            return balance;
        }
    }
}