using System;

namespace Expense_Tracker.Common.Models
{
    public class ExpenseDTO
    {
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    }
}
