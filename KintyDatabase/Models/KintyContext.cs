using Microsoft.EntityFrameworkCore;

namespace KintyDatabase.Models
{
    public class KintyContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CreditCardPayment> CreditCardPayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=kinty;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // check whether this is the best way to require uniqueness!
            modelBuilder.Entity<Category>()
                .HasAlternateKey(category => category.Name);

            // check whether this is the best way to require uniqueness!
            modelBuilder.Entity<User>()
                .HasAlternateKey(user => user.Username);
        }
    }
}
