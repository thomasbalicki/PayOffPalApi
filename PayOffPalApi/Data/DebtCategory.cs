namespace PayOffPalApi.Data
{
    public class DebtCategory
    {
        public int DebtCategoryId { get; set; }
        public string Name { get; set; }

        // Navigation property (Has a list of debts associated with category)
        public IList<Debt> Debts { get; set; }
    }

}
