namespace Expense_Tracker.Common.Models
{
    // DTO used for both adding and updating budgets
    public class BudgetDTO
    {
        public int? Month { get; set; }     // Nullable to allow partial updates
        public int? Year { get; set; }      // Nullable to allow partial updates
        public decimal LimitAmount { get; set; }
    }
}
