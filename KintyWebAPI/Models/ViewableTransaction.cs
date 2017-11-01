using KintyDatabase.Models;
using System;

namespace KintyWebAPI.Models
{
    public class ViewableTransaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public string PaymentType { get; set; }

        public ViewableTransaction(Transaction transaction)
        {
            TransactionId = transaction.TransactionId;
            Amount = transaction.Amount;
            Category = transaction.Category.Name;
            Description = transaction.Description;
            Date = transaction.Date;
            PaymentType = transaction.PaymentType.Name;
        }
    }
}
