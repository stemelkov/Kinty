using KintyDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KintyDatabase.Access
{
    public class KintySearching
    {
        // Implement paging and filtering
        public static IEnumerable<Transaction> GetAllTransactions(int userId, int limit)
        {
            using (var context = new KintyContext())
            {
                var transactions = context.Transactions
                    .Include(t => t.User)
                    .Include(t => t.Category)
                    .Include(t => t.CreditDetails)
                    .Include(t => t.PaymentType)
                    .Where(t => t.UserId == userId)
                    .OrderByDescending(t => t.TransactionId)
                    .Take(limit)
                    .ToList();
                return transactions;
            }
        }

        public static IEnumerable<Category> GetAllCategories()
        {
            using (var context = new KintyContext())
            {
                var categories = context.Categories.ToList();
                return categories;
            }
        }
    }
}
