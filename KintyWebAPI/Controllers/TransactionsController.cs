using KintyDatabase.Access;
using KintyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KintyWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/transactions")]
    public class TransactionsController : Controller
    {
        // Retrieve a set of transactions
        [HttpGet]
        [Route("{userId}/{limit}")]
        public IEnumerable<ViewableTransaction> Get(int userId, int limit)
        {
            var viewableTransactions = KintySearching.GetAllTransactions(userId, limit)
                .Select(t => new ViewableTransaction(t));
            return viewableTransactions;
        }

        // Update transaction
        [HttpPut]
        public void Put()
        {

        }

        // Create new transaction
        [HttpPost]
        public void Post()
        {

        }
    }
}