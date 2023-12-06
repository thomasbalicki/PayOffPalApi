
using PayOffPalApi.Models.Debt;

namespace PayOffPalApi.Models.DebtCategory
{
    public class DebtCategoryDto : BaseDebtCategoryDto
    {
        public int DebtCategoryId { get; set; }
        public List<DebtDto> Debts { get; set; }
    }
}
