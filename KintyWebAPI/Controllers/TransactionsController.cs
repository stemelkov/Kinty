using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KintyDatabase.Access;
using KintyDatabase.Models;
using KintyWebAPI.Models;

namespace KintyWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {
        [HttpGet]
        public IEnumerable<ViewableTransaction> Get()
        {
            var viewableTransactions = KintySearching.GetAllTransactions(1, 100)
                .Select(t => new ViewableTransaction(t));
            return viewableTransactions;
        }
    }
}