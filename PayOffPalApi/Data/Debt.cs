using System.ComponentModel.DataAnnotations.Schema;

namespace PayOffPalApi.Data
{
    public class Debt
    {
        public int DebtId { get; set; }
        public string DebtName { get; set; }
        public decimal AmountOwed { get; set; }
        public decimal MonthlyPayment { get; set; }
        public double InterestRate { get; set; }
        public DateTime DateAdded { get; set; }

        // Foreign key to DebtCategory (Has a category of..)
        [ForeignKey(nameof(DebtCategoryId))]
        public int DebtCategoryId { get; set; }
        public DebtCategory DebtCategory { get; set; }

        // Foreign key to ApplicationUser
        //public string UserId { get; set; }
        //public ApplicationUser User { get; set; }

        // Navigation property for payments (Has a list of payments for the debt)
        public IList<Payment> Payments { get; set; }
    }
}
