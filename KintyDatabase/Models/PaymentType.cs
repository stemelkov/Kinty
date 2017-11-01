using System;

namespace KintyDatabase.Models
{
    public class PaymentType
    {
        // Primary key
        public int PaymentTypeId { get; set; }

        // Name of the payment type
        public string Name { get; set; }

        // Indication whether this payment type is a credit card
        public bool IsCreditCard { get; set; }
    }
}
