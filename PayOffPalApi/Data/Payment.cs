using System.ComponentModel.DataAnnotations.Schema;

namespace PayOffPalApi.Data
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }

        // Foreign key to Debt (Has a debt that the payment is made towards)
        [ForeignKey(nameof(DebtId))]
        public int DebtId { get; set; }
        public Debt Debt { get; set; }

        // Foreign key to ApplicationUser (user who made the payment)
        //public string UserId { get; set; }
        //public ApplicationUser User { get; set; }
    }

}
