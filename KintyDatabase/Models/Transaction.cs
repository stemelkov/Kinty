using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KintyDatabase.Models
{
    public class Transaction
    {
        // Primary Key
        public int TransactionId { get; set; }

        // Owner - Foreign key and navigation property
        public int UserId { get; set; }
        public virtual User User { get; set; }

        // Transaction amount; positive for income, negative for all payments
        public decimal Amount { get; set; }

        // Transaction category - Foreign key and navigation property 
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Free-text description of the transaction
        public string Description { get; set; }

        // Date of the transaction
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        // Type of payment - Foreign key and navigation property
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        // Credit details (optional) - Foreign key and navigation property
        public int? CreditCardPaymentId { get; set; }
        public virtual CreditCardPayment CreditDetails { get; set; }
    }
}
