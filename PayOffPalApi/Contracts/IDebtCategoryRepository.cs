using PayOffPalApi.Data;

namespace PayOffPalApi.Contracts
{
    public interface IDebtCategoryRepository : IGenericRepository<DebtCategory>
    {
        Task<DebtCategory> GetDetails(int id);
    }
}
