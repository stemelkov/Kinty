using KintyDatabase.Models;
using System.Linq;

namespace KintyDatabase.Access
{
    public class KintyStats
    {
        public static decimal GetBalance()
        {
            using (var context = new KintyContext())
            {
                var balance = context.Transactions.Sum(t => t.Amount);
                return balance;
            }
        }
    }
}
