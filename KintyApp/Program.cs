using KintyDatabase.Access;
using KintyDatabase.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace KintyApp
{
    class Program
    {
        static IEnumerable<string> ReadAsLines(string filename)
        {
            using (var reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }

        static void ImportFromFile()
        {
            var filename = @"d:\rawft.txt";
            var reader = ReadAsLines(filename);
            foreach (var record in reader)
            {
                // Split the line into an array
                string[] cols = record.Split('\t');

                // Read all fields
                var amount = cols[0] != string.Empty 
                    ? decimal.Parse(cols[0], System.Globalization.NumberStyles.Currency) 
                    : -decimal.Parse(cols[1], System.Globalization.NumberStyles.Currency);
                var category = cols[2].Trim();
                var description = cols[3].Trim();
                var date = cols[4].Trim();
                var payment = cols[5].Trim();
                var liquidation = cols[6].Trim();

                // Related fields
                var db_payment = KintyInput.AddPaymentType(payment);

                // Create a new transaction
                var transaction = new Transaction
                {
                    UserId = 1,
                    Amount = amount,
                    CategoryId = KintyInput.AddCategory(category, amount > 0).CategoryId,
                    Description = description,
                    Date = Convert.ToDateTime(date).Date,
                    PaymentTypeId = db_payment.PaymentTypeId
                };

                if (db_payment.IsCreditCard && amount < 0)
                {
                    transaction.CreditDetails = new CreditCardPayment
                    {
                        PaidOffDate = liquidation != string.Empty ? Convert.ToDateTime(liquidation).Date : (DateTime?)null
                    };
                }

                KintyInput.AddTransaction(transaction);
            }
        }

        static void Main(string[] args)
        {
            KintyInput.AddUser("stancho", "temelkov@gmail.com", "Stanislav Temelkov");
            ImportFromFile();
        }
    }
}
