
using Microsoft.EntityFrameworkCore;
using PayOffPalApi.Contracts;
using PayOffPalApi.Data;

namespace PayOffPalApi.Repository
{
    public class DebtCategoriesRepository : GenericRepository<DebtCategory>, IDebtCategoryRepository
    {
        private readonly PayOffPalDbContext _context;

        public DebtCategoriesRepository(PayOffPalDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<DebtCategory> GetDetails(int id)
        {
            return await _context.DebtCategories.Include(q => q.Debts).FirstOrDefaultAsync(q => q.DebtCategoryId == id);
        }
    }
}
