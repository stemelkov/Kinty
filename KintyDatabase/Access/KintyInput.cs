using KintyDatabase.Models;
using System.Linq;
using System;

namespace KintyDatabase.Access
{
    public class KintyInput
    {
        public static void AddTransaction(Transaction transaction)
        {
            using (var db = new KintyContext())
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }

        public static Category AddCategory(string categoryName, bool isIncome, string parentCategoryName = "")
        {
            Category parentCategory = null;
            if (parentCategoryName != string.Empty)
                parentCategory = AddCategory(parentCategoryName, isIncome);

            using (var db = new KintyContext())
            {
                var existingCategory = db.Categories.SingleOrDefault(c => c.Name == categoryName);
                if (existingCategory != null)
                    return existingCategory;

                var category = new Category {
                    Name = categoryName,
                    IsIncome = isIncome
                };

                if (parentCategory != null)
                    category.Parent = parentCategory;

                db.Categories.Add(category);
                db.SaveChanges();
                return category;
            }
        }

        public static User AddUser(string username, string email, string fullname)
        {
            var user = new User
            {
                Email = email,
                FullName = fullname,
                Username = username
            };
            using (var db = new KintyContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
        }

        public static PaymentType AddPaymentType(string paymentName)
        {
            using (var db = new KintyContext())
            {
                var existingPayment = db.PaymentTypes.SingleOrDefault(p => p.Name == paymentName);
                if (existingPayment != null)
                    return existingPayment;
                var payment = new PaymentType {
                    Name = paymentName,
                    IsCreditCard = paymentName == "кредитна карта"
                };

                db.PaymentTypes.Add(payment);
                db.SaveChanges();
                return payment;
            }
        }
    }
}
