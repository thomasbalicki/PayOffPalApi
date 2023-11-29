using Microsoft.EntityFrameworkCore;

namespace PayOffPalApi.Data
{
    public class PayOffPalDbContext : DbContext
    {
        public PayOffPalDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Debt> Debts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DebtCategory> DebtCategories { get; set; }
        //TODO: Add application user 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DebtCategory>().HasData(
                new DebtCategory
                {
                    DebtCategoryId = 1,
                    Name = "Student Loans"
                },
                new DebtCategory
                {
                    DebtCategoryId = 2,
                    Name = "Credit Card"
                },
                new DebtCategory
                {
                    DebtCategoryId = 3,
                    Name = "Vehicle Loan"
                }
            );

            modelBuilder.Entity<Debt>().HasData(
                new Debt
                {
                    DebtId = 1,
                    DebtName = "Discover Student Loan",
                    AmountOwed = 40000.00M,
                    MonthlyPayment = 300.00M,
                    InterestRate = 10.00,
                    DateAdded = DateTime.Now,
                    DebtCategoryId = 1
                },
                new Debt
                {
                    DebtId = 2,
                    DebtName = "Apple Credit Card",
                    AmountOwed = 2500.00M,
                    MonthlyPayment = 100.00M,
                    InterestRate = 20.00,
                    DateAdded = DateTime.Now,
                    DebtCategoryId = 2
                },
                new Debt
                {
                    DebtId = 3,
                    DebtName = "Landmark Credit Union Loan",
                    AmountOwed = 6000.00M,
                    MonthlyPayment = 270.00M,
                    InterestRate = 20.00,
                    DateAdded = DateTime.Now,
                    DebtCategoryId = 3
                }
            );
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentId = 1,
                    AmountPaid = 100.00M,
                    PaymentDate = DateTime.Now,
                    DebtId = 2
                },
                new Payment
                {
                    PaymentId = 2,
                    AmountPaid = 300.00M,
                    PaymentDate = DateTime.Now,
                    DebtId = 1
                },
                new Payment
                {
                    PaymentId = 3,
                    AmountPaid = 270.00M,
                    PaymentDate = DateTime.Now,
                    DebtId = 3
                }
            );
        }
    }
}
