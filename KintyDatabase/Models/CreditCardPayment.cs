using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KintyDatabase.Models
{
    public class CreditCardPayment
    {
        // Primary key
        public int CreditCardPaymentId { get; set; }

        // Date of pay off (if paid off)
        [Column(TypeName = "Date")]
        public DateTime? PaidOffDate { get; set; }

        public bool IsPaidOff
        {
            get
            {
                return PaidOffDate.HasValue;
            }
        }
    }
}
